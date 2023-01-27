// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.OrganizationResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Returns results from performing an action using a Request object.
  /// </summary>
  [SuppressMessage("Microsoft.Security", "CA9881:ClassesShouldBeSealed", Justification = "This class need to be instantiated by clients and be able to derive from it.")]
  [DataContract(Name = "OrganizationResponse", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public class OrganizationResponse : IExtensibleDataObject
  {
    private ParameterCollection _propertyBag;
    private string _messageName;
    private ExtensionDataObject _extensionDataObject;

    /// <summary>
    /// Gets or sets name of the message represented by the request that was processed.
    /// </summary>
    [DataMember]
    public string ResponseName
    {
      get => _messageName;
      set => _messageName = value;
    }

    /// <summary>Indexer property for the Results collection</summary>
    /// <param name="parameterName">Name of the parameter</param>
    /// <returns>Parameter stored in the Results collection with the given parameter name</returns>
    public object this[string parameterName]
    {
      get => Results[parameterName];
      set => Results[parameterName] = value;
    }

    /// <summary>Gets or sets results from processing a request.</summary>
    [DataMember]
    public ParameterCollection Results
    {
      get
      {
        if (_propertyBag == null)
          _propertyBag = new ParameterCollection();
        return _propertyBag;
      }
      set => _propertyBag = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
