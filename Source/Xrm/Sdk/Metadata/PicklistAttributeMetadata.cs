// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.PicklistAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "PicklistAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "PicklistAttributeMetadata", LogicalCollectionName = "PicklistAttributeDefinitions")]
  public sealed class PicklistAttributeMetadata : EnumAttributeMetadata
  {
    public PicklistAttributeMetadata()
      : this(null)
    {
    }

    public PicklistAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.Picklist, schemaName)
    {
    }

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

    /// <summary>
    /// Gets or sets parent picklist attribute's logical name.
    /// </summary>
    [DataMember(Order = 91)]
    public string ParentPicklistLogicalName
    {
      get => ParentEnumAttributeLogicalName;
      set => ParentEnumAttributeLogicalName = value;
    }

    /// <summary>
    /// Gets list (logical names) of a picklist attribute's child attributes
    /// </summary>
    [DataMember(Order = 91)]
    public List<string> ChildPicklistLogicalNames { get; internal set; }
  }
}
