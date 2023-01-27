// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ImageAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "ImageAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2013/Metadata")]
  [MetadataName(LogicalName = "ImageAttributeMetadata", LogicalCollectionName = "ImageAttributeDefinitions")]
  public sealed class ImageAttributeMetadata : AttributeMetadata
  {
    private bool? _isPrimaryImageAttribute;
    private short? _maxHeight;
    private short? _maxWidth;

    public ImageAttributeMetadata()
      : this(null)
    {
    }

    public ImageAttributeMetadata(string schemaName)
    {
      AttributeType = new AttributeTypeCode?(AttributeTypeCode.Virtual);
      AttributeTypeName = AttributeTypeDisplayName.ImageType;
      SchemaName = schemaName;
    }

    [DataMember]
    public bool? IsPrimaryImage
    {
      get => _isPrimaryImageAttribute;
      set => _isPrimaryImageAttribute = value;
    }

    [DataMember]
    public short? MaxHeight
    {
      get => _maxHeight;
      internal set => _maxHeight = value;
    }

    [DataMember]
    public short? MaxWidth
    {
      get => _maxWidth;
      internal set => _maxWidth = value;
    }

    /// <summary>Maximum file size(in KBs) allowed for this attribute</summary>
    [DataMember]
    public int? MaxSizeInKB { get; set; }

    /// <summary>
    /// Indicates whether this Image attribute can store full image
    /// </summary>
    [DataMember]
    public bool? CanStoreFullImage { get; set; }
  }
}
