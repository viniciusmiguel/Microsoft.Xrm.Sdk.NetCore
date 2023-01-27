// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.EnumAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [KnownType(typeof (MultiSelectPicklistAttributeMetadata))]
  [KnownType(typeof (EntityNameAttributeMetadata))]
  [KnownType(typeof (PicklistAttributeMetadata))]
  [KnownType(typeof (StateAttributeMetadata))]
  [KnownType(typeof (StatusAttributeMetadata))]
  [DataContract(Name = "EnumAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "EnumAttributeMetadata", LogicalCollectionName = "EnumAttributeDefinitions")]
  public abstract class EnumAttributeMetadata : AttributeMetadata
  {
    private OptionSetMetadata _optionSetMetadata;
    private int? _defaultValue;

    protected EnumAttributeMetadata()
    {
    }

    protected EnumAttributeMetadata(AttributeTypeCode attributeType, string schemaName)
      : base(attributeType, schemaName)
    {
    }

    [DataMember]
    public int? DefaultFormValue
    {
      get => _defaultValue;
      set => _defaultValue = value;
    }

    [DataMember]
    public OptionSetMetadata OptionSet
    {
      get => _optionSetMetadata;
      set => _optionSetMetadata = value;
    }

    [DataMember(Order = 91)]
    internal string ParentEnumAttributeLogicalName { get; set; }
  }
}
