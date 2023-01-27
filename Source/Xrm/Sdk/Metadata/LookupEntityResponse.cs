// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.LookupEntityResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  /// <summary>Lookup Entity Response</summary>
  [DataContract(Name = "LookupEntityResponse", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class LookupEntityResponse : IExtensibleDataObject
  {
    private LookupMetadata _metadata;
    private EntityCollection _data;
    private ExtensionDataObject _extensionDataObject;

    /// <summary>The Lookup Metadata</summary>
    [DataMember]
    public LookupMetadata Metadata
    {
      get
      {
        if (_metadata == null)
          _metadata = new LookupMetadata();
        return _metadata;
      }
      set => _metadata = value;
    }

    /// <summary>The Entity Logical Name</summary>
    [DataMember]
    public string EntityLogicalName { get; set; }

    /// <summary>The Data</summary>
    [DataMember]
    public EntityCollection Data
    {
      get
      {
        if (_data == null)
          _data = new EntityCollection();
        return _data;
      }
      set => _data = value;
    }

    /// <summary>The Total Record Count</summary>
    [DataMember]
    public int TotalRecordCount { get; set; }

    /// <summary>The Entity Logical Name</summary>
    [DataMember]
    public string PagingCookie { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
