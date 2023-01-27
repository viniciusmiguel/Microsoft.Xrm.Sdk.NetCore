// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.EntityKeyMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "EntityKeyMetadata", Namespace = "http://schemas.microsoft.com/xrm/7.1/Metadata")]
  [MetadataName(LogicalName = "EntityKeyMetadata", LogicalCollectionName = "EntityKeyDefinitions")]
  public sealed class EntityKeyMetadata : MetadataBase
  {
    private Label _displayName;
    private string _logicalName;
    private string _schemaName;
    private string _entityLogicalName;
    private string[] _keyAttributes;
    private BooleanManagedProperty _isCustomizable;
    private bool? _isManaged;
    private bool? _isSynchronous;
    private bool? _isExportKey;
    private string _introducedVersion;
    private EntityKeyIndexStatus _entityKeyIndexStatus;
    private EntityReference _asyncJob;
    private bool? _isSecondaryKey;

    [DataMember]
    public Label DisplayName
    {
      get => _displayName;
      set => _displayName = value;
    }

    [DataMember]
    [Alternatekey]
    public string LogicalName
    {
      get => _logicalName;
      set => _logicalName = value;
    }

    [DataMember]
    public string SchemaName
    {
      get => _schemaName;
      set => _schemaName = value;
    }

    [DataMember]
    public string EntityLogicalName
    {
      get => _entityLogicalName;
      internal set => _entityLogicalName = value;
    }

    [DataMember]
    public string[] KeyAttributes
    {
      get => _keyAttributes;
      set => _keyAttributes = value;
    }

    [DataMember]
    public BooleanManagedProperty IsCustomizable
    {
      get => _isCustomizable;
      internal set => _isCustomizable = value;
    }

    [DataMember]
    public bool? IsManaged
    {
      get => _isManaged;
      internal set => _isManaged = value;
    }

    [DataMember]
    public string IntroducedVersion
    {
      get => _introducedVersion;
      internal set => _introducedVersion = value;
    }

    [DataMember]
    public EntityKeyIndexStatus EntityKeyIndexStatus
    {
      get => _entityKeyIndexStatus;
      internal set => _entityKeyIndexStatus = value;
    }

    [DataMember]
    public EntityReference AsyncJob
    {
      get => _asyncJob;
      internal set => _asyncJob = value;
    }

    [DataMember]
    public bool? IsSynchronous
    {
      get => _isSynchronous;
      internal set => _isSynchronous = value;
    }

    [DataMember]
    public bool? IsExportKey
    {
      get => _isExportKey;
      internal set => _isExportKey = value;
    }

    [DataMember]
    public bool? IsSecondaryKey
    {
      get => _isSecondaryKey;
      set => _isSecondaryKey = value;
    }
  }
}
