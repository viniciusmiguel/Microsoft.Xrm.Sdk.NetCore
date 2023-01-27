// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.KnownTypesFactory
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.JsonConverters;
using System;
using System.Reflection;
using System.Security;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Factory class used to create concrete instances of known types
  /// </summary>
  internal class KnownTypesFactory
  {
    /// <summary>
    /// Creates instance of typeName and initializes properties from propertiesJson
    /// </summary>
    /// <param name="typeName"></param>
    /// <param name="propertiesJson"></param>
    /// <returns></returns>
    public object Create(string typeName, string propertiesJson = null)
    {
      if (typeName == null)
        throw new ArgumentNullException(nameof (typeName));
      Type type;
      if (!KnownTypesProvider.KnownOrganizationRequestResponseTypesByTypeName.TryGetValue(typeName, out type))
        throw new ApplicationException("Unable to find response type");
      return Create(type, propertiesJson);
    }

    /// <summary>
    /// Creates instance of typeName and initializes properties from propertiesJson
    /// </summary>
    /// <param name="typeName"></param>
    /// <param name="instance"></param>
    /// <param name="propertiesJson"></param>
    /// <returns></returns>
    public bool TryCreate(string typeName, out object instance, string propertiesJson = null)
    {
      instance = null;
      if (typeName == null)
        throw new ArgumentNullException(nameof (typeName));
      Type type;
      if (!KnownTypesProvider.KnownOrganizationRequestResponseTypesByTypeName.TryGetValue(typeName, out type))
        return false;
      instance = Create(type, propertiesJson);
      return instance != null;
    }

    /// <summary>
    /// Creates instance of type and initializes properties from propertiesJson
    /// </summary>
    /// <param name="type"></param>
    /// <param name="propertiesJson"></param>
    /// <returns></returns>
    [SecuritySafeCritical]
    public object Create(Type type, string propertiesJson = null)
    {
      var obj = (object) type != null ? Activator.CreateInstance(type) : throw new ArgumentNullException(nameof (type));
      if (!string.IsNullOrWhiteSpace(propertiesJson) && obj is OrganizationResponse)
      {
        var organizationResponse = obj as OrganizationResponse;
        var rootElement = JsonDocument.Parse(propertiesJson, new JsonDocumentOptions()).RootElement;
        foreach (var property in type.GetProperties())
        {
          object propertyValue;
          if (!(property.DeclaringType == typeof (OrganizationResponse)) && TryGetPropertyValue(rootElement, property, out propertyValue))
            organizationResponse.Results.Add(property.Name, propertyValue);
        }
        organizationResponse.ResponseName = type.Name;
      }
      return obj;
    }

    /// <summary>Try getting property value from jsonElement</summary>
    /// <param name="jsonElement"></param>
    /// <param name="property"></param>
    /// <param name="propertyValue"></param>
    /// <returns></returns>
    [SecuritySafeCritical]
    private bool TryGetPropertyValue(
      JsonElement jsonElement,
      PropertyInfo property,
      out object propertyValue)
    {
      propertyValue = null;
      JsonElement jsonElement1;
      if (!jsonElement.TryGetProperty(property.Name, out jsonElement1))
        return false;
      if (property.PropertyType == typeof (bool))
      {
        bool result;
        if (!bool.TryParse(jsonElement1.ToString(), out result))
          return false;
        propertyValue = result;
        return true;
      }
      var rawText = jsonElement1.GetRawText();
      var serializerOptions1 = new JsonSerializerOptions();
      serializerOptions1.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, true));
      serializerOptions1.Converters.Add(new EndpointCollectionConverter());
      serializerOptions1.Converters.Add(new DictionaryConverter<string, string>());
      var serializerOptions2 = serializerOptions1;
      propertyValue = JsonSerializer.Deserialize(rawText, property.PropertyType, serializerOptions2);
      return true;
    }
  }
}
