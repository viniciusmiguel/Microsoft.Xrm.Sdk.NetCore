// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ManyToManyRelationshipMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "ManyToManyRelationshipMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "ManyToManyRelationshipMetadata", LogicalCollectionName = "ManyToManyRelationshipDefinitions")]
  public sealed class ManyToManyRelationshipMetadata : RelationshipMetadataBase
  {
    private AssociatedMenuConfiguration _entity1AssociatedMenuConfiguration;
    private AssociatedMenuConfiguration _entity2AssociatedMenuConfiguration;
    private string _entity1LogicalName;
    private string _entity2LogicalName;
    private string _intersectEntityName;
    private string _entity1IntersectAttribute;
    private string _entity2IntersectAttribute;
    private string _entity1NavigationPropertyName;
    private string _entity2NavigationPropertyName;

    public ManyToManyRelationshipMetadata()
      : base(RelationshipType.ManyToManyRelationship)
    {
    }

    [DataMember]
    public AssociatedMenuConfiguration Entity1AssociatedMenuConfiguration
    {
      get => _entity1AssociatedMenuConfiguration;
      set => _entity1AssociatedMenuConfiguration = value;
    }

    [DataMember]
    public AssociatedMenuConfiguration Entity2AssociatedMenuConfiguration
    {
      get => _entity2AssociatedMenuConfiguration;
      set => _entity2AssociatedMenuConfiguration = value;
    }

    [DataMember]
    public string Entity1LogicalName
    {
      get => _entity1LogicalName;
      set => _entity1LogicalName = value;
    }

    [DataMember]
    public string Entity2LogicalName
    {
      get => _entity2LogicalName;
      set => _entity2LogicalName = value;
    }

    [DataMember]
    public string IntersectEntityName
    {
      get => _intersectEntityName;
      set => _intersectEntityName = value;
    }

    [DataMember]
    public string Entity1IntersectAttribute
    {
      get => _entity1IntersectAttribute;
      set => _entity1IntersectAttribute = value;
    }

    [DataMember]
    public string Entity2IntersectAttribute
    {
      get => _entity2IntersectAttribute;
      set => _entity2IntersectAttribute = value;
    }

    [DataMember]
    public string Entity1NavigationPropertyName
    {
      get => _entity1NavigationPropertyName;
      set => _entity1NavigationPropertyName = value;
    }

    [DataMember]
    public string Entity2NavigationPropertyName
    {
      get => _entity2NavigationPropertyName;
      set => _entity2NavigationPropertyName = value;
    }
  }
}
