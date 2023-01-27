// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.BaseServiceFault
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Fault contract for IOrganizationService service contract.
  /// Use the OrganizationServiceFault contract to handle CRM specific errors in SDK client.
  /// </summary>
  [DataContract(Name = "BaseServiceFault", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [KnownType(typeof (DiscoveryServiceFault))]
  [KnownType(typeof (OrganizationServiceFault))]
  [KnownType(typeof (ExecuteTransactionFault))]
  [Serializable]
  public abstract class BaseServiceFault : IExtensibleDataObject
  {
    private DateTime _timestamp;
    private string _message;
    private int _errorCode;
    private string _helpLink;
    private ErrorDetailCollection _details;
    private BaseServiceFault _innerServiceFault;
    private Guid _activityId;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

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
    /// Gets or sets predefined error code returned by CRM. Refer to SDK helpers and documentation for list of codes.
    /// </summary>
    [DataMember]
    public int ErrorCode
    {
      get => _errorCode;
      set => _errorCode = value;
    }

    /// <summary>
    /// Gets or sets url that points to a knowledgebase article or similar content to help with the error raised.
    /// </summary>
    [DataMember]
    public string HelpLink
    {
      get => _helpLink;
      set => _helpLink = value;
    }

    /// <summary>
    /// Gets or sets server time in UTC when the error occured.
    /// </summary>
    [DataMember]
    public DateTime Timestamp
    {
      get => _timestamp;
      set => _timestamp = value;
    }

    /// <summary>
    /// Gets or sets telemetry ActivityId when the error occurred
    /// </summary>
    [DataMember]
    public Guid ActivityId
    {
      get => _activityId;
      set => _activityId = value;
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

    internal virtual BaseServiceFault InnerServiceFault
    {
      get => _innerServiceFault;
      set => _innerServiceFault = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
