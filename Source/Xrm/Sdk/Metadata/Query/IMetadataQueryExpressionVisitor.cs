// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.Query.IMetadataQueryExpressionVisitor
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.ComponentModel;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
  [EditorBrowsable(EditorBrowsableState.Never)]
  internal interface IMetadataQueryExpressionVisitor
  {
    void Visit(EntityQueryExpression query);

    void Visit(AttributeQueryExpression query);

    void Visit(RelationshipQueryExpression query);

    void Visit(LabelQueryExpression query);

    void Visit(EntityKeyQueryExpression query);
  }
}
