// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.OneToManyRelationshipMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "OneToManyRelationshipMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "OneToManyRelationshipMetadata", LogicalCollectionName = "OneToManyRelationshipDefinitions")]
  public sealed class OneToManyRelationshipMetadata : RelationshipMetadataBase
  {
    private AssociatedMenuConfiguration _associatedMenuConfiguration;
    private CascadeConfiguration _cascadeConfiguration;
    private string _referencedAttribute;
    private string _referencedEntity;
    private string _referencedEntityNavigationPropertyName;
    private string _referencingAttribute;
    private string _referencingEntity;
    private string _referencingEntityNavigationPropertyName;
    private bool? _isHierarchical;
    private bool? _isDenormalizedLookup;
    private string _denormalizedAttributeName;
    private bool? _isRelationshipAttributeDenormalized;
    private string _entityKey;
    private Collection<RelationshipAttribute> _relationshipAttributes;
    private int? _relationshipBehavior;

    public OneToManyRelationshipMetadata()
      : base(RelationshipType.OneToManyRelationship)
    {
    }

    [DataMember]
    public AssociatedMenuConfiguration AssociatedMenuConfiguration
    {
      get => _associatedMenuConfiguration;
      set => _associatedMenuConfiguration = value;
    }

    [DataMember]
    public CascadeConfiguration CascadeConfiguration
    {
      get => _cascadeConfiguration;
      set => _cascadeConfiguration = value;
    }

    [DataMember]
    public string ReferencedAttribute
    {
      get => _referencedAttribute;
      set => _referencedAttribute = value;
    }

    [DataMember]
    public string ReferencedEntity
    {
      get => _referencedEntity;
      set => _referencedEntity = value;
    }

    [DataMember]
    public string ReferencingAttribute
    {
      get => _referencingAttribute;
      set => _referencingAttribute = value;
    }

    [DataMember]
    public string ReferencingEntity
    {
      get => _referencingEntity;
      set => _referencingEntity = value;
    }

    [DataMember]
    public bool? IsHierarchical
    {
      get => _isHierarchical;
      set => _isHierarchical = value;
    }

    [DataMember]
    public string EntityKey
    {
      get => _entityKey;
      set => _entityKey = value;
    }

    [DataMember]
    public Collection<RelationshipAttribute> RelationshipAttributes
    {
      get => _relationshipAttributes;
      set => _relationshipAttributes = value;
    }

    [DataMember]
    public bool? IsRelationshipAttributeDenormalized
    {
      get => _isRelationshipAttributeDenormalized;
      set => _isRelationshipAttributeDenormalized = value;
    }

    [DataMember]
    public string ReferencedEntityNavigationPropertyName
    {
      get => _referencedEntityNavigationPropertyName;
      set => _referencedEntityNavigationPropertyName = value;
    }

    [DataMember]
    public string ReferencingEntityNavigationPropertyName
    {
      get => _referencingEntityNavigationPropertyName;
      set => _referencingEntityNavigationPropertyName = value;
    }

    [DataMember]
    public int? RelationshipBehavior
    {
      get => _relationshipBehavior;
      set => _relationshipBehavior = value;
    }

    [DataMember]
    public bool? IsDenormalizedLookup
    {
      get => _isDenormalizedLookup;
      set => _isDenormalizedLookup = value;
    }

    [DataMember]
    public string DenormalizedAttributeName
    {
      get => _denormalizedAttributeName;
      set => _denormalizedAttributeName = value;
    }
  }
}
