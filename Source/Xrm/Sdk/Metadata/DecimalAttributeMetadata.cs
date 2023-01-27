// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.DecimalAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "DecimalAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "DecimalAttributeMetadata", LogicalCollectionName = "DecimalAttributeMetadataDefinitions")]
  public sealed class DecimalAttributeMetadata : AttributeMetadata
  {
    public const double MinSupportedValue = -100000000000.0;
    public const double MaxSupportedValue = 100000000000.0;
    public const int MinSupportedPrecision = 0;
    public const int MaxSupportedPrecision = 10;

    public DecimalAttributeMetadata()
      : this(null)
    {
    }

    public DecimalAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.Decimal, schemaName)
    {
    }

    [DataMember]
    public Decimal? MaxValue { get; set; }

    [DataMember]
    public Decimal? MinValue { get; set; }

    [DataMember]
    public int? Precision { get; set; }

    [DataMember]
    public ImeMode? ImeMode { get; set; }

    /// <summary>
    /// String representing the formula of a calculated field.
    /// </summary>
    [DataMember(Order = 70)]
    public string FormulaDefinition { get; set; }

    /// <summary>
    ///  Indicates the type of attributes present in the Calculated Field (i.e. persistent, logical, related, calculated, invalid or any combination of these types)
    /// </summary>
    [DataMember(Order = 70)]
    public int? SourceTypeMask { get; internal set; }
  }
}
