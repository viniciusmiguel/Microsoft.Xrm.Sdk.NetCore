// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.QueryExpressionVisitorBase
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Xrm.Sdk.Query
{
  /// <summary>
  /// Represents a visitor or rewriter for query expression trees.
  /// </summary>
  public abstract class QueryExpressionVisitorBase : IQueryExpressionVisitor
  {
    /// <summary>
    /// Visits top level properties of QueryExpression and dispatches each subexpression to one of the more specialized visit methods in this class.
    /// </summary>
    /// <param name="query">The query expression to visit.</param>
    /// <returns>The modified expression, if it or any subexpression was modified; otherwise, returns the original expression.</returns>
    public virtual QueryExpression Visit(QueryExpression query)
    {
      var filterExpression = query != null ? VisitFilterExpression(query.Criteria) : throw new ArgumentException(nameof (query));
      var items1 = VisitAndConvert<OrderExpression>(query.Orders, new Func<OrderExpression, OrderExpression>(VisitOrderExpression));
      var items2 = VisitAndConvert<LinkEntity>(query.LinkEntities, new Func<LinkEntity, LinkEntity>(VisitLinkEntity));
      var pagingInfo = VisitPagingInfo(query.PageInfo);
      var columnSet = VisitColumnSet(query.ColumnSet);
      if (filterExpression == query.Criteria && items1 == query.Orders && items2 == query.LinkEntities && pagingInfo == query.PageInfo && columnSet == query.ColumnSet)
        return query;
      var queryExpression = new QueryExpression(query.EntityName);
      queryExpression.Criteria = filterExpression;
      queryExpression.Orders.AddRange(items1);
      queryExpression.LinkEntities.AddRange(items2);
      queryExpression.PageInfo = pagingInfo;
      queryExpression.ColumnSet = columnSet;
      queryExpression.TopCount = query.TopCount;
      queryExpression.Distinct = query.Distinct;
      queryExpression.DataSource = query.DataSource;
      queryExpression.NoLock = query.NoLock;
      queryExpression.ExtensionData = query.ExtensionData;
      return queryExpression;
    }

    /// <summary>Visits the PagingInfo.</summary>
    /// <param name="pageInfo">The PagingInfo to visit.</param>
    /// <returns>The modified PagingInfo, if it was modified; otherwise, returns the original PagingInfo.</returns>
    protected virtual PagingInfo VisitPagingInfo(PagingInfo pageInfo) => pageInfo;

    /// <summary>
    /// Visits the LinkEntity by dispatching each subexpression to one of the more specialized visit methods in this class.
    /// </summary>
    /// <param name="linkEntity">The LinkEntity to visit.</param>
    /// <returns>The modified LinkEntity, if it or any subexpression was modified; otherwise, returns the original LinkEntity.</returns>
    protected virtual LinkEntity VisitLinkEntity(LinkEntity linkEntity)
    {
      var filterExpression = VisitFilterExpression(linkEntity.LinkCriteria);
      var items1 = VisitAndConvert<OrderExpression>(linkEntity.Orders, new Func<OrderExpression, OrderExpression>(VisitOrderExpression));
      var items2 = VisitAndConvert<LinkEntity>(linkEntity.LinkEntities, new Func<LinkEntity, LinkEntity>(VisitLinkEntity));
      var columnSet = VisitColumnSet(linkEntity.Columns);
      if (items2 == linkEntity.LinkEntities && filterExpression == linkEntity.LinkCriteria && items1 == linkEntity.Orders && columnSet == linkEntity.Columns)
        return linkEntity;
      var linkEntity1 = new LinkEntity();
      linkEntity1.LinkFromEntityName = linkEntity.LinkFromEntityName;
      linkEntity1.LinkToEntityName = linkEntity.LinkToEntityName;
      linkEntity1.LinkFromAttributeName = linkEntity.LinkFromAttributeName;
      linkEntity1.LinkToAttributeName = linkEntity.LinkToAttributeName;
      linkEntity1.JoinOperator = linkEntity.JoinOperator;
      linkEntity1.LinkCriteria = filterExpression;
      linkEntity1.Columns = columnSet;
      linkEntity1.EntityAlias = linkEntity.EntityAlias;
      linkEntity1.ExtensionData = linkEntity.ExtensionData;
      linkEntity1.Orders.AddRange(items1);
      linkEntity1.LinkEntities.AddRange(items2);
      return linkEntity1;
    }

    /// <summary>Visits the ConditionExpression.</summary>
    /// <param name="condition">The ConditionExpression to visit.</param>
    /// <returns>The modified ConditionExpression, if it was modified; otherwise, returns the original ConditionExpression.</returns>
    protected virtual ConditionExpression VisitConditionExpression(ConditionExpression condition) => condition;

    /// <summary>
    /// Visits the FilterExpression by dispatching each subexpression to one of the more specialized visit methods in this class.
    /// </summary>
    /// <param name="filter">The LinkEntity to visit.</param>
    /// <returns>The modified FilterExpression, if it or any subexpression was modified; otherwise, returns the original FilterExpression.</returns>
    protected virtual FilterExpression VisitFilterExpression(FilterExpression filter)
    {
      if (filter == null)
        return null;
      var items1 = VisitAndConvert<FilterExpression>(filter.Filters, new Func<FilterExpression, FilterExpression>(VisitFilterExpression));
      var items2 = VisitAndConvert<ConditionExpression>(filter.Conditions, new Func<ConditionExpression, ConditionExpression>(VisitConditionExpression));
      if (items1 == filter.Filters && items2 == filter.Conditions)
        return filter;
      var filterExpression = new FilterExpression(filter.FilterOperator);
      filterExpression.IsQuickFindFilter = filter.IsQuickFindFilter;
      filterExpression.ExtensionData = filter.ExtensionData;
      filterExpression.Filters.AddRange(items1);
      filterExpression.Conditions.AddRange(items2);
      return filterExpression;
    }

    /// <summary>Visits the OrderExpression.</summary>
    /// <param name="order">The OrderExpression to visit.</param>
    /// <returns>The modified OrderExpression, if it was modified; otherwise, returns the original OrderExpression.</returns>
    protected virtual OrderExpression VisitOrderExpression(OrderExpression order) => order;

    /// <summary>Visits the ColumnSet.</summary>
    /// <param name="columnSet">The ColumnSet to visit.</param>
    /// <returns>The modified ColumnSet, if it was modified; otherwise, returns the original ColumnSet.</returns>
    protected virtual ColumnSet VisitColumnSet(ColumnSet columnSet) => columnSet;

    private IReadOnlyList<T> VisitAndConvert<T>(IReadOnlyList<T> nodes, Func<T, T> visit)
    {
      T[] list = null;
      var index1 = 0;
      for (var count = nodes.Count; index1 < count; ++index1)
      {
        if (nodes[index1] != null)
        {
          var obj = visit(nodes[index1]);
          if (obj == null)
            throw new InvalidOperationException("Visit returned null");
          if (list != null)
            list[index1] = obj;
          else if ((object) obj != (object) nodes[index1])
          {
            list = new T[count];
            for (var index2 = 0; index2 < index1; ++index2)
              list[index2] = nodes[index2];
            list[index1] = obj;
          }
        }
      }
      return list == null ? nodes : new ReadOnlyCollection<T>(list);
    }
  }
}
