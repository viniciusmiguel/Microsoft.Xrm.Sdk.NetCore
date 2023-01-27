// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.RelationshipMetadataBase
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "RelationshipMetadataBase", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [KnownType(typeof (OneToManyRelationshipMetadata))]
  [KnownType(typeof (ManyToManyRelationshipMetadata))]
  [MetadataName(LogicalName = "RelationshipMetadataBase", LogicalCollectionName = "RelationshipDefinitions")]
  public abstract class RelationshipMetadataBase : MetadataBase
  {
    private bool? _isCustomRelationship;
    private bool? _isValidForAdvancedFind;
    private string _schemaName;
    private SecurityTypes? _securityTypes;
    private bool? _isManaged;
    private BooleanManagedProperty _isCustomizable;
    private RelationshipType _type;
    private string _introducedVersion;

    protected RelationshipMetadataBase()
    {
    }

    protected RelationshipMetadataBase(RelationshipType type) => _type = type;

    [DataMember]
    public bool? IsCustomRelationship
    {
      get => _isCustomRelationship;
      set => _isCustomRelationship = value;
    }

    [DataMember]
    public BooleanManagedProperty IsCustomizable
    {
      get => _isCustomizable;
      set => _isCustomizable = value;
    }

    [DataMember]
    public bool? IsValidForAdvancedFind
    {
      get => _isValidForAdvancedFind;
      set => _isValidForAdvancedFind = value;
    }

    [DataMember]
    [Alternatekey]
    public string SchemaName
    {
      get => _schemaName;
      set => _schemaName = value;
    }

    [DataMember]
    public SecurityTypes? SecurityTypes
    {
      get => _securityTypes;
      set => _securityTypes = value;
    }

    [DataMember]
    public bool? IsManaged
    {
      get => _isManaged;
      internal set => _isManaged = value;
    }

    [DataMember(Order = 60)]
    public RelationshipType RelationshipType
    {
      get => _type;
      internal set => _type = value;
    }

    [DataMember(Order = 60)]
    public string IntroducedVersion
    {
      get => _introducedVersion;
      internal set => _introducedVersion = value;
    }
  }
}
