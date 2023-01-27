// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.MetadataQuery
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  /// <summary>Client Metadata Query for getting dependencies</summary>
  [DataContract(Name = "MetadataQuery", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class MetadataQuery : IExtensibleDataObject
  {
    private string _metadataType;
    private string _metadataSubtype;
    private string _entityLogicalName;
    private Guid? _metadataId;
    private string _metadataName;
    private string[] _metadataNames;
    private bool _getDefault;
    private DependencyDepth _dependencyDepth;
    private string _changedAfter;
    private Guid?[] _exclude;
    private Guid? _appId;
    private string _systemMetadataDelta;
    private string _userMetadataDelta;
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Gets or sets the metadata type that need to be synced</summary>
    [DataMember]
    public string MetadataType
    {
      get => _metadataType;
      set => _metadataType = value;
    }

    /// <summary>
    /// Gets or sets the metadata subtype that need to be synced
    /// </summary>
    [DataMember]
    public string MetadataSubtype
    {
      get => _metadataSubtype;
      set => _metadataSubtype = value;
    }

    /// <summary>Gets or sets the entity logical name</summary>
    [DataMember]
    public string EntityLogicalName
    {
      get => _entityLogicalName;
      set => _entityLogicalName = value;
    }

    /// <summary>Gets or sets the metadata id that need to be synced</summary>
    [DataMember]
    public Guid? MetadataId
    {
      get => _metadataId;
      set => _metadataId = value;
    }

    /// <summary>
    /// Gets or sets tODO # 689663 remove it
    /// The metadataName that need to be synced
    /// </summary>
    [DataMember]
    public string MetadataName
    {
      get => _metadataName;
      set => _metadataName = value;
    }

    /// <summary>Gets or sets the metadatanames that need to be synced</summary>
    [DataMember]
    public string[] MetadataNames
    {
      get => _metadataNames;
      set => _metadataNames = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether the field indicates if default is needed or not
    /// </summary>
    [DataMember]
    public bool GetDefault
    {
      get => _getDefault;
      set => _getDefault = value;
    }

    /// <summary>Gets or sets the dependency depth for the sync</summary>
    [DataMember]
    public DependencyDepth DependencyDepth
    {
      get => _dependencyDepth;
      set => _dependencyDepth = value;
    }

    /// <summary>
    /// Gets or sets tODO # 689663 remove it
    /// The changed after indicates sync after this time
    /// </summary>
    [DataMember]
    public string ChangedAfter
    {
      get => _changedAfter;
      set => _changedAfter = value;
    }

    /// <summary>
    /// Gets or sets the exclude indicates don't sync given ids
    /// </summary>
    [DataMember]
    public Guid?[] Exclude
    {
      get => _exclude;
      set => _exclude = value;
    }

    /// <summary>Gets or sets the app id</summary>
    [DataMember]
    public Guid? AppId
    {
      get => _appId;
      set => _appId = value;
    }

    /// <summary>
    /// Gets or sets the Over all user metadata version
    /// We want to sync changes after this metadata version
    /// </summary>
    [DataMember]
    public string UserMetadataDelta
    {
      get => _userMetadataDelta;
      set => _userMetadataDelta = value;
    }

    /// <summary>
    /// Gets or sets the Over all System metadata version
    /// We want to sync changes after this metadata version
    /// </summary>
    [DataMember]
    public string SystemMetadataDelta
    {
      get => _systemMetadataDelta;
      set => _systemMetadataDelta = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
