// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.Query.EntityKeyQueryExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
  /// <summary>Class used to specify a query for entity key metadata</summary>
  [DataContract(Name = "EntityKeyQueryExpression", Namespace = "http://schemas.microsoft.com/xrm/8.0")]
  public sealed class EntityKeyQueryExpression : MetadataQueryExpression
  {
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal override void Accept(IMetadataQueryExpressionVisitor visitor) => visitor.Visit(this);
  }
}
