// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "StringAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "StringAttributeMetadata", LogicalCollectionName = "StringAttributeDefinitions")]
  public sealed class StringAttributeMetadata : AttributeMetadata
  {
    public const int MinSupportedLength = 1;
    public const int MaxSupportedLength = 4000;

    public StringAttributeMetadata()
      : this(null)
    {
    }

    public StringAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.String, schemaName)
    {
    }

    /// <summary>
    /// Gets or sets required for CreateAttribute.
    /// Ignored for UpdateAttribute.
    /// Use FormatName instead of Format
    /// </summary>
    [DataMember]
    public StringFormat? Format { get; set; }

    /// <summary>
    /// Gets or sets valid for CreateAttribute.
    /// Valid for UpdateAttribute.
    /// </summary>
    [DataMember(Order = 60)]
    public StringFormatName FormatName { get; set; }

    /// <summary>
    /// Gets or sets valid for CreateAttribute.
    /// Valid for UpdateAttribute.
    /// </summary>
    [DataMember]
    public ImeMode? ImeMode { get; set; }

    /// <summary>
    /// Gets or sets required for CreateAttribu;te
    /// Valid for UpdateAttribute
    /// </summary>
    [DataMember]
    public int? MaxLength { get; set; }

    /// <summary>
    /// Gets or sets required for CreateAttribute
    /// Valid for UpdateAttribute
    /// </summary>
    [DataMember]
    public string YomiOf { get; set; }

    /// <summary>
    /// Gets valid on RetrieveEntityRequest
    /// Valid on RetrieveAllEntitiesRequest
    /// Valid on RetrieveAttributeRequest
    /// Valid on RetrieveMetadataChanges
    /// </summary>
    [DataMember(Order = 70)]
    public bool? IsLocalizable { get; internal set; }

    [DataMember(Order = 90)]
    public int? DatabaseLength { get; internal set; }

    /// <summary>
    /// Gets or sets string representing the formula of a calculated field.
    /// </summary>
    [DataMember(Order = 70)]
    public string FormulaDefinition { get; set; }

    /// <summary>
    ///  Gets indicates the type of attributes present in the Calculated Field (i.e. persistent, logical, related, calculated, invalid or any combination of these types)
    /// </summary>
    [DataMember(Order = 70)]
    public int? SourceTypeMask { get; internal set; }
  }
}
