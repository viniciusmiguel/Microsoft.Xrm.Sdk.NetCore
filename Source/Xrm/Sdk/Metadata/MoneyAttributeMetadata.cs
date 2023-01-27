// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.MoneyAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "MoneyAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "MoneyAttributeMetadata", LogicalCollectionName = "MoneyAttributeDefinitions")]
  public sealed class MoneyAttributeMetadata : AttributeMetadata
  {
    public const double MinSupportedValue = -922337203685477.0;
    public const double MaxSupportedValue = 922337203685477.0;
    public const int MinSupportedPrecision = 0;
    public const int MaxSupportedPrecision = 4;
    public const int MaxSupportedPrecisionAfterCurrencyConversion = 10;

    public MoneyAttributeMetadata()
      : this(null)
    {
    }

    public MoneyAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.Money, schemaName)
    {
    }

    /// <summary>
    /// Valid for CreateAttribute
    /// Valid for UpdateAttribute
    /// </summary>
    [DataMember]
    public ImeMode? ImeMode { get; set; }

    /// <summary>
    /// Required for CreateAttribute
    /// Valid for UpdateAttribute
    /// </summary>
    [DataMember]
    public double? MaxValue { get; set; }

    /// <summary>
    /// Required for CreateAttribute
    /// Valid for UpdateAttribute
    /// </summary>
    [DataMember]
    public double? MinValue { get; set; }

    /// <summary>
    /// Required for CreateAttribute
    /// Valid for UpdateAttribute
    /// </summary>
    [DataMember]
    public int? Precision { get; set; }

    /// <summary>
    /// Required for CreateAttribute
    /// Valid for UpdateAttribute
    /// </summary>
    [DataMember]
    public int? PrecisionSource { get; set; }

    [DataMember]
    public string CalculationOf { get; set; }

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

    [DataMember(Order = 70)]
    public bool? IsBaseCurrency { get; internal set; }
  }
}
