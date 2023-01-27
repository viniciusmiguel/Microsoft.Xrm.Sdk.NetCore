// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.QueryExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "QueryExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class QueryExpression : QueryBase
  {
    public static readonly QueryExpression Empty = new();
    private ColumnSet _columnSet;
    private string _entityName;
    private string _queryHints;
    private bool _distinct;
    private bool _noLock;
    private string _dataSource;
    private PagingInfo _pageInfo;
    private DataCollection<LinkEntity> _linkEntities;
    private FilterExpression _criteria;
    private DataCollection<OrderExpression> _orders;
    private QueryExpression _subQueryExpression;
    private int? _topCount;

    public QueryExpression()
      : this(null)
    {
    }

    public QueryExpression(string entityName)
    {
      _entityName = entityName;
      _criteria = new FilterExpression();
      _pageInfo = new PagingInfo();
      _columnSet = new ColumnSet();
    }

    [DataMember]
    public bool Distinct
    {
      get => _distinct;
      set => _distinct = value;
    }

    [DataMember(Order = 50)]
    public bool NoLock
    {
      get => _noLock;
      set => _noLock = value;
    }

    [DataMember(IsRequired = false, EmitDefaultValue = false)]
    public QueryExpression SubQueryExpression
    {
      get => _subQueryExpression;
      set => _subQueryExpression = value;
    }

    [DataMember]
    public PagingInfo PageInfo
    {
      get => _pageInfo;
      set => _pageInfo = value;
    }

    [DataMember(Order = 92, EmitDefaultValue = false)]
    public string QueryHints
    {
      get => _queryHints;
      set => _queryHints = value;
    }

    [DataMember(Order = 93, EmitDefaultValue = false)]
    public string DataSource
    {
      get => _dataSource;
      set => _dataSource = value;
    }

    [DataMember]
    public DataCollection<LinkEntity> LinkEntities
    {
      get
      {
        if (_linkEntities == null)
          _linkEntities = new DataCollection<LinkEntity>();
        return _linkEntities;
      }
      private set => _linkEntities = value;
    }

    [DataMember]
    public FilterExpression Criteria
    {
      get => _criteria;
      set => _criteria = value;
    }

    [DataMember]
    public DataCollection<OrderExpression> Orders
    {
      get
      {
        if (_orders == null)
          _orders = new DataCollection<OrderExpression>();
        return _orders;
      }
      private set => _orders = value;
    }

    [DataMember]
    public string EntityName
    {
      get => _entityName;
      set => _entityName = value;
    }

    [DataMember]
    public ColumnSet ColumnSet
    {
      get => _columnSet;
      set => _columnSet = value;
    }

    [DataMember(Order = 50, EmitDefaultValue = false)]
    public int? TopCount
    {
      get => _topCount;
      set => _topCount = value;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal override void Accept(IQueryVisitor visitor) => visitor.Visit(this);

    public QueryExpression Accept(IQueryExpressionVisitor visitor) => visitor.Visit(this);

    public void AddOrder(string attributeName, OrderType orderType) => Orders.Add(new OrderExpression(attributeName, orderType));

    public void AddOrder(
      string attributeName,
      OrderType orderType,
      string alias,
      string entityName)
    {
      Orders.Add(new OrderExpression(attributeName, orderType, alias, entityName));
    }

    public LinkEntity AddLink(
      string linkToEntityName,
      string linkFromAttributeName,
      string linkToAttributeName)
    {
      return AddLink(linkToEntityName, linkFromAttributeName, linkToAttributeName, JoinOperator.Inner);
    }

    public LinkEntity AddLink(
      string linkToEntityName,
      string linkFromAttributeName,
      string linkToAttributeName,
      JoinOperator joinOperator)
    {
      var linkEntity = new LinkEntity(EntityName, linkToEntityName, linkFromAttributeName, linkToAttributeName, joinOperator);
      LinkEntities.Add(linkEntity);
      return linkEntity;
    }
  }
}
