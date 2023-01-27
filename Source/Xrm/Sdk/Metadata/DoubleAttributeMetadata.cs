// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.DoubleAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "DoubleAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "DoubleAttributeMetadata", LogicalCollectionName = "DoubleAttributeDefinitions")]
  public sealed class DoubleAttributeMetadata : AttributeMetadata
  {
    public const double MinSupportedValue = -100000000000.0;
    public const double MaxSupportedValue = 100000000000.0;
    public const int MinSupportedPrecision = 0;
    public const int MaxSupportedPrecision = 5;

    public DoubleAttributeMetadata()
      : this(null)
    {
    }

    public DoubleAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.Double, schemaName)
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
  }
}
