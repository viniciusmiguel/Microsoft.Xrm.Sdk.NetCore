// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.AliasedValue
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// AliasedValue used by CRM to return aggregate, group by and aliased values from a query
  /// </summary>
  [KnownType("GetKnownAliasedValueTypes")]
  [DataContract(Name = "AliasedValue", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class AliasedValue : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.AliasedValue" /> class.
    /// constructor
    /// </summary>
    public AliasedValue()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.AliasedValue" /> class.
    /// constructor to allow specifying values
    /// </summary>
    /// <param name="entityLogicalName">Name of entity that the attribute belongs to.</param>
    /// <param name="attributeLogicalName">Name of the attribute the value is based on.</param>
    /// <param name="value">Value</param>
    public AliasedValue(string entityLogicalName, string attributeLogicalName, object value)
    {
      AttributeLogicalName = attributeLogicalName;
      EntityLogicalName = entityLogicalName;
      Value = value;
    }

    /// <summary>
    /// Gets name of the attribute on which the aggregate, group by or select was performed.
    /// </summary>
    [DataMember]
    public string AttributeLogicalName { get; internal set; }

    /// <summary>Gets name of entity the attribute belongs to.</summary>
    [DataMember]
    public string EntityLogicalName { get; internal set; }

    /// <summary>Gets value returned by the query.</summary>
    [DataMember]
    public object Value { get; internal set; }

    /// <summary>
    /// Gets or sets a value indicating whether determines if value needs additional formatting, for internal use
    /// </summary>
    [DataMember]
    internal bool NeedFormatting { get; set; }

    /// <summary>Gets or sets value's return type, for internal use</summary>
    [DataMember]
    internal int ReturnType { get; set; }

    private static IEnumerable<Type> GetKnownAliasedValueTypes()
    {
      var knownTypes = new List<Type>();
      KnownTypesProvider.AddKnownAttributeTypes(knownTypes);
      return knownTypes;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
