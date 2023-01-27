// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.Query.EntityQueryExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
  /// <summary>Class used to specify a query for entity metadata</summary>
  [DataContract(Name = "EntityQueryExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
  public sealed class EntityQueryExpression : MetadataQueryExpression
  {
    /// <summary>
    /// Specifies the filter criteria for any labels selected by this query
    /// </summary>
    [DataMember]
    public LabelQueryExpression LabelQuery { get; set; }

    /// <summary>
    /// Specifies the filter criteria for any attributes selected by this query
    /// </summary>
    [DataMember]
    public AttributeQueryExpression AttributeQuery { get; set; }

    /// <summary>
    /// Specifies the filter criteria for any relationships selected by this query
    /// </summary>
    [DataMember]
    public RelationshipQueryExpression RelationshipQuery { get; set; }

    /// <summary>
    /// Specifies the filter criteria for any entity keys selected by this query
    /// </summary>
    [DataMember]
    public EntityKeyQueryExpression KeyQuery { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal override void Accept(IMetadataQueryExpressionVisitor visitor) => visitor.Visit(this);
  }
}
