// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.LookupEntityInfo
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  /// <summary>Client Look up query for getting data and metadata</summary>
  [DataContract(Name = "LookupEntityInfo", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class LookupEntityInfo : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>The entity logical name</summary>
    [DataMember]
    public string EntityLogicalName { get; set; }

    /// <summary>The View id</summary>
    [DataMember]
    public Guid? ViewId { get; set; }

    /// <summary>The custom Filter</summary>
    [DataMember]
    public string CustomFilter { get; set; }

    /// <summary>The Relationship Name</summary>
    [DataMember]
    public string RelationshipName { get; set; }

    /// <summary>The Fetch Xml</summary>
    [DataMember]
    public string FetchXml { get; set; }

    /// <summary>The Layout Json</summary>
    [DataMember]
    public string LayoutJson { get; set; }

    /// <summary>The Paging Cookie</summary>
    [DataMember]
    public PagingInfo PagingInfo { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
