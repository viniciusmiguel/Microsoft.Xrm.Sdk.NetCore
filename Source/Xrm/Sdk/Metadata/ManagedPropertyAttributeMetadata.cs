// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ManagedPropertyAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "ManagedPropertyAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "ManagedPropertyAttributeMetadata", LogicalCollectionName = "ManagedPropertyAttributeDefinitions")]
  public sealed class ManagedPropertyAttributeMetadata : AttributeMetadata
  {
    public const int EmptyParentComponentType = 0;
    private string _managedPropertyLogicalName;
    private int? _parentComponentType;
    private string _parentAttributeName;
    private AttributeTypeCode _typeCode;

    public ManagedPropertyAttributeMetadata()
      : this(null)
    {
    }

    public ManagedPropertyAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.ManagedProperty, schemaName)
    {
    }

    [DataMember]
    public string ManagedPropertyLogicalName
    {
      get => _managedPropertyLogicalName;
      internal set => _managedPropertyLogicalName = value;
    }

    [DataMember]
    public int? ParentComponentType
    {
      get => _parentComponentType;
      internal set => _parentComponentType = value;
    }

    [DataMember]
    public string ParentAttributeName
    {
      get => _parentAttributeName;
      internal set => _parentAttributeName = value;
    }

    [DataMember]
    public AttributeTypeCode ValueAttributeTypeCode
    {
      get => _typeCode;
      internal set => _typeCode = value;
    }
  }
}
