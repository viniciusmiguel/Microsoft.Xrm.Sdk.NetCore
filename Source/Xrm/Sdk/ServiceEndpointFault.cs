// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.ServiceEndpointFault
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Fault contract for ITwoWayServiceEndpointPlugin, IWebHttpServiceEndpointPlugin service contract.
  /// Use the ServiceEndpointFault contract to return specific errors back to CRM.
  /// </summary>
  [DataContract(Name = "ServiceEndpointFault", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [Serializable]
  public sealed class ServiceEndpointFault : IExtensibleDataObject
  {
    private string _message;
    private ErrorDetailCollection _details;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    public ServiceEndpointFault()
    {
    }

    public ServiceEndpointFault(string message) => _message = message;

    /// <summary>
    /// Gets or sets contains the error message included by CRM platform. This string is always in English.
    /// </summary>
    [DataMember]
    public string Message
    {
      get => _message;
      set => _message = value;
    }

    /// <summary>
    /// Gets or sets additional data returned from CRM. The contents of this property is error specific.
    /// </summary>
    [DataMember]
    public ErrorDetailCollection ErrorDetails
    {
      get
      {
        if (_details == null)
          _details = new ErrorDetailCollection();
        return _details;
      }
      set => _details = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
