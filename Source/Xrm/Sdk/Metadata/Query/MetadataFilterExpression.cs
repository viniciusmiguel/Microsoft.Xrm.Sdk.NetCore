// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.Query.MetadataFilterExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
  /// <summary>Class that is used to group a set of query conditions</summary>
  [DataContract(Name = "MetadataFilterExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
  public sealed class MetadataFilterExpression : IExtensibleDataObject
  {
    private DataCollection<MetadataConditionExpression> _conditions;
    private DataCollection<MetadataFilterExpression> _filters;

    public ExtensionDataObject ExtensionData { get; set; }

    public MetadataFilterExpression()
    {
    }

    public MetadataFilterExpression(LogicalOperator filterOperator) => FilterOperator = filterOperator;

    /// <summary>Set of conditions that are part of this filter</summary>
    [DataMember]
    public DataCollection<MetadataConditionExpression> Conditions
    {
      get => _conditions ?? (_conditions = new DataCollection<MetadataConditionExpression>());
      private set => _conditions = value;
    }

    /// <summary>
    /// Logical operator applied between conditions and child filters
    /// </summary>
    [DataMember]
    public LogicalOperator FilterOperator { get; set; }

    /// <summary>Collection of child filters</summary>
    [DataMember]
    public DataCollection<MetadataFilterExpression> Filters
    {
      get => _filters ?? (_filters = new DataCollection<MetadataFilterExpression>());
      private set => _filters = value;
    }
  }
}
