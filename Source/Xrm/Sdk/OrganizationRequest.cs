// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.OrganizationRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Makes a request to XRM services to perform a specific action.
  /// </summary>
  [DataContract(Name = "OrganizationRequest", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public class OrganizationRequest : IExtensibleDataObject
  {
    private ParameterCollection _propertyBag;
    private string _messageName;
    private Guid? _requestId;
    private ExtensionDataObject _extensionDataObject;

    public OrganizationRequest()
    {
    }

    public OrganizationRequest(string requestName) => _messageName = requestName;

    /// <summary>
    /// Gets or sets name of the message represented by the request.
    /// </summary>
    [DataMember]
    public string RequestName
    {
      get => _messageName;
      set => _messageName = value;
    }

    /// <summary>Indexer property for the Parameters collection</summary>
    /// <param name="parameterName">Name of the parameter</param>
    /// <returns>Parameter stored in the Parameters collection with the given parameter name</returns>
    public object this[string parameterName]
    {
      get => Parameters[parameterName];
      set => Parameters[parameterName] = value;
    }

    /// <summary>Gets or sets parameters for the request.</summary>
    [DataMember]
    public ParameterCollection Parameters
    {
      get
      {
        if (_propertyBag == null)
          _propertyBag = new ParameterCollection();
        return _propertyBag;
      }
      set => _propertyBag = value;
    }

    /// <summary>
    /// Gets or sets provides tracking mechanism for actions resulting from a request.
    /// </summary>
    [DataMember]
    public Guid? RequestId
    {
      get => _requestId;
      set => _requestId = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
