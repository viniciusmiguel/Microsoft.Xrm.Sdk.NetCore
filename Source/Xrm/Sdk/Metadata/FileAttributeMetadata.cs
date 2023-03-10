// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.FileAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  /// <summary>Introduces FileAttribute metadata to Xrm SDK</summary>
  [DataContract(Name = "FileAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/9.0/Metadata")]
  [MetadataName(LogicalName = "FileAttributeMetadata", LogicalCollectionName = "FileAttributeDefinitions")]
  public sealed class FileAttributeMetadata : AttributeMetadata
  {
    public FileAttributeMetadata()
      : this(null)
    {
    }

    public FileAttributeMetadata(string schemaName)
    {
      AttributeType = new AttributeTypeCode?(AttributeTypeCode.Virtual);
      AttributeTypeName = AttributeTypeDisplayName.FileType;
      IsValidForUpdate = new bool?(false);
      IsValidForCreate = new bool?(false);
      RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None);
      SchemaName = schemaName;
    }

    /// <summary>Maximum file size(in KBs) allowed for this attribute</summary>
    [DataMember]
    public int? MaxSizeInKB { get; set; }
  }
}
