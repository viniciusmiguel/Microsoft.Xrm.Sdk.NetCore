// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.BooleanAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "BooleanAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "BooleanAttributeMetadata", LogicalCollectionName = "BooleanAttributeDefinitions")]
  public sealed class BooleanAttributeMetadata : AttributeMetadata
  {
    public BooleanAttributeMetadata()
      : this(null, null)
    {
    }

    public BooleanAttributeMetadata(string schemaName)
      : this(schemaName, null)
    {
    }

    public BooleanAttributeMetadata(BooleanOptionSetMetadata optionSet)
      : this(null, optionSet)
    {
    }

    public BooleanAttributeMetadata(string schemaName, BooleanOptionSetMetadata optionSet)
      : base(AttributeTypeCode.Boolean, schemaName)
    {
      OptionSet = optionSet;
    }

    [DataMember]
    public bool? DefaultValue { get; set; }

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

    [DataMember]
    public BooleanOptionSetMetadata OptionSet { get; set; }
  }
}
