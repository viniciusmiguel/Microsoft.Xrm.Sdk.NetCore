// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.BusinessEntityChanges
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// BusinessEntityChanges that holds the Token and the Collection of Entities or EntityReferances
  /// </summary>
  [DataContract(Name = "BusinessEntityChanges", Namespace = "http://schemas.microsoft.com/xrm/7.1/Contracts")]
  public sealed class BusinessEntityChanges : IExtensibleDataObject
  {
    private string _dataToken;
    private BusinessEntityChangesCollection _changes;
    private bool _moreRecords;
    private string _pagingCookie;
    private string _globalMetadataVersion;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    /// <summary>
    /// Gets or sets a value indicating whether flag to indicate whether there are more records at server side
    /// </summary>
    [DataMember]
    public bool MoreRecords
    {
      get => _moreRecords;
      set => _moreRecords = value;
    }

    [DataMember]
    public string PagingCookie
    {
      get => _pagingCookie;
      set => _pagingCookie = value;
    }

    /// <summary>Gets or sets last version synced by client</summary>
    [DataMember]
    public string DataToken
    {
      get => _dataToken;
      set => _dataToken = value;
    }

    /// <summary>
    /// Gets or sets holds the collection of Entities and EntityReferences that are INSERTED/UPDATED or DELETED at the server side
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    [DataMember]
    public BusinessEntityChangesCollection Changes
    {
      get => _changes;
      set => _changes = value;
    }

    /// <summary>
    /// Gets or sets global metadata version
    /// This value is same as MetadataCache.Timestamp
    /// </summary>
    [DataMember]
    public string GlobalMetadataVersion
    {
      get => _globalMetadataVersion;
      set => _globalMetadataVersion = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
