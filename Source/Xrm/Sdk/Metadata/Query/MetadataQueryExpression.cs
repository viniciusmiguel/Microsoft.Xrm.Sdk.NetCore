// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.Query.MetadataQueryExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
  [KnownType(typeof (EntityQueryExpression))]
  [KnownType(typeof (AttributeQueryExpression))]
  [KnownType(typeof (RelationshipQueryExpression))]
  [KnownType(typeof (LabelQueryExpression))]
  [KnownType(typeof (EntityKeyQueryExpression))]
  [DataContract(Name = "MetadataQueryExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
  public abstract class MetadataQueryExpression : MetadataQueryBase
  {
    protected MetadataQueryExpression() => Criteria = new MetadataFilterExpression(LogicalOperator.And);

    /// <summary>Defines the criteria used to query the metadata</summary>
    [DataMember]
    public MetadataFilterExpression Criteria { get; set; }

    /// <summary>
    /// Defines the set of metadata properties that need to be retrieved
    /// </summary>
    [DataMember]
    public MetadataPropertiesExpression Properties { get; set; }
  }
}
