// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.IntegerAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "IntegerAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "IntegerAttributeMetadata", LogicalCollectionName = "IntegerAttributeDefinitions")]
  public sealed class IntegerAttributeMetadata : AttributeMetadata
  {
    public const int MinSupportedValue = -2147483648;
    public const int MaxSupportedValue = 2147483647;

    public IntegerAttributeMetadata()
      : this(null)
    {
    }

    public IntegerAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.Integer, schemaName)
    {
    }

    /// <summary>
    /// Required for CreateAttribute
    /// Ignored for UpdateAttribute
    /// </summary>
    [DataMember]
    public IntegerFormat? Format { get; set; }

    /// <summary>
    /// Required for CreateAttribute
    /// Valid for UpdateAttribute
    /// </summary>
    [DataMember]
    public int? MaxValue { get; set; }

    /// <summary>
    /// Required for CreateAttribute
    /// Valid for UpdateAttribute
    /// </summary>
    [DataMember]
    public int? MinValue { get; set; }

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
