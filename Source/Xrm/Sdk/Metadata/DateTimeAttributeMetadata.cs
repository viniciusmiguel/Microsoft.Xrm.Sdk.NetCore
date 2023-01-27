// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.DateTimeAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "DateTimeAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "DateTimeAttributeMetadata", LogicalCollectionName = "DateTimeAttributeDefinitions")]
  public sealed class DateTimeAttributeMetadata : AttributeMetadata
  {
    private static readonly DateTime _minDateTime = new(1753, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private static readonly DateTime _maxDateTime = new(9999, 12, 30, 23, 59, 59, DateTimeKind.Utc);

    public DateTimeAttributeMetadata()
      : this(new DateTimeFormat?())
    {
    }

    public DateTimeAttributeMetadata(DateTimeFormat? format)
      : this(format, null)
    {
    }

    public DateTimeAttributeMetadata(DateTimeFormat? format, string schemaName)
      : base(AttributeTypeCode.DateTime, schemaName)
    {
      Format = format;
    }

    public static DateTime MinSupportedValue => _minDateTime;

    public static DateTime MaxSupportedValue => _maxDateTime;

    /// <summary>
    /// Required for CreateAttribute
    /// Valid for UpdateAttribute
    /// </summary>
    [DataMember]
    public DateTimeFormat? Format { get; set; }

    /// <summary>
    /// Valid for CreateAttribute
    /// Valid for UpdateAttribute
    /// </summary>
    [DataMember]
    public ImeMode? ImeMode { get; set; }

    /// <summary>
    ///  Indicates the type of attributes present in the Calculated Field (i.e. persistent, logical, related, calculated, invalid or any combination of these types)
    /// </summary>
    [DataMember(Order = 70)]
    public int? SourceTypeMask { get; internal set; }

    /// <summary>
    /// String representing the formula of a calculated field.
    /// </summary>
    [DataMember(Order = 70)]
    public string FormulaDefinition { get; set; }

    /// <summary>
    /// Valid for CreateAttribute.
    /// Valid for UpdateAttribute.
    /// </summary>
    [DataMember(Order = 71)]
    public DateTimeBehavior DateTimeBehavior { get; set; }

    [DataMember(Order = 71)]
    public BooleanManagedProperty CanChangeDateTimeBehavior { get; set; }
  }
}
