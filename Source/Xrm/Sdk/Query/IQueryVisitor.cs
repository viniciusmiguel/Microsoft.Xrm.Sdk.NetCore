// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.IQueryVisitor
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.ComponentModel;

namespace Microsoft.Xrm.Sdk.Query
{
  [EditorBrowsable(EditorBrowsableState.Never)]
  internal interface IQueryVisitor
  {
    void Visit(QueryExpression query);

    void Visit(QueryByAttribute query);

    void Visit(FetchExpression query);

    void Visit(ColumnSet columnSet);

    void Visit(PagingInfo pageInfo);

    void Visit(OrderExpression order);

    void Visit(LinkEntity linkEntity);

    void Visit(FilterExpression filter);

    void Visit(ConditionExpression condition);
  }
}
