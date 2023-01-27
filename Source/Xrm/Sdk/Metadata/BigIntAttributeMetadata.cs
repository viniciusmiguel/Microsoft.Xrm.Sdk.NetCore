// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.BigIntAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "BigIntAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "BigIntAttributeMetadata", LogicalCollectionName = "BigIntAttributeDefinitions")]
  public sealed class BigIntAttributeMetadata : AttributeMetadata
  {
    public const long MinSupportedValue = -9223372036854775808;
    public const long MaxSupportedValue = 9223372036854775807;
    private long? _maxValue;
    private long? _minValue;

    public BigIntAttributeMetadata()
      : this(null)
    {
    }

    public BigIntAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.BigInt, schemaName)
    {
    }

    /// <summary>
    /// Required for CreateAttribute
    /// Valid for UpdateAttribute
    /// </summary>
    [DataMember]
    public long? MaxValue
    {
      get => _maxValue;
      internal set => _maxValue = value;
    }

    /// <summary>
    /// Required for CreateAttribute
    /// Valid for UpdateAttribute
    /// </summary>
    [DataMember]
    public long? MinValue
    {
      get => _minValue;
      internal set => _minValue = value;
    }
  }
}
