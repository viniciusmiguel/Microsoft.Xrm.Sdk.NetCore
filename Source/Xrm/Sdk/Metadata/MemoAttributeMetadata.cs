// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.MemoAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "MemoAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "MemoAttributeMetadata", LogicalCollectionName = "MemoAttributeDefinitions")]
  public sealed class MemoAttributeMetadata : AttributeMetadata
  {
    public const int MinSupportedLength = 1;
    public const int MaxSupportedLength = 1048576;
    private StringFormat? _format;
    private ImeMode? _imeMode;
    private int? _maxLength;
    private bool? _isLocalizable;

    public MemoAttributeMetadata()
      : this(null)
    {
    }

    public MemoAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.Memo, schemaName)
    {
    }

    /// <summary>
    /// Valid for CreateAttribute
    /// Valid for UpdateAttribute
    /// </summary>
    [DataMember]
    public StringFormat? Format
    {
      get => _format;
      set => _format = value;
    }

    /// <summary>
    /// Valid for UpdateAttribute.
    /// Valid for UpdateAttribute.
    /// </summary>
    [DataMember(Order = 60)]
    public MemoFormatName FormatName { get; set; }

    /// <summary>
    /// Valid for CreateAttribute
    /// Valid for UpdateAttribute
    /// </summary>
    [DataMember]
    public ImeMode? ImeMode
    {
      get => _imeMode;
      set => _imeMode = value;
    }

    /// <summary>
    /// Required on non-email Memo attributes for CreateAttribute
    /// Valid on UpdateAttribute
    /// </summary>
    [DataMember]
    public int? MaxLength
    {
      get => _maxLength;
      set => _maxLength = value;
    }

    /// <summary>
    /// Valid on RetrieveEntityRequest
    /// Valid on RetrieveAllEntitiesRequest
    /// Valid on RetrieveAttributeRequest
    /// Valid on RetrieveMetadataChanges
    /// </summary>
    [DataMember(Order = 70)]
    public bool? IsLocalizable
    {
      get => _isLocalizable;
      internal set => _isLocalizable = value;
    }
  }
}
