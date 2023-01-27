// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.QueryByAttribute
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "QueryByAttribute", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class QueryByAttribute : QueryBase
  {
    private string _entityName;
    private DataCollection<string> _attributes;
    private DataCollection<object> _attributeValues;
    private PagingInfo _pageInfo;
    private ColumnSet _columnSet;
    private DataCollection<OrderExpression> _orders;
    private int? _topCount;

    public QueryByAttribute()
    {
      _columnSet = new ColumnSet();
      _pageInfo = new PagingInfo();
    }

    public QueryByAttribute(string entityName) => EntityName = entityName;

    [DataMember]
    public string EntityName
    {
      get => _entityName;
      set => _entityName = value;
    }

    [DataMember]
    public DataCollection<string> Attributes
    {
      get
      {
        if (_attributes == null)
          _attributes = new DataCollection<string>();
        return _attributes;
      }
      private set => _attributes = value;
    }

    [DataMember]
    public DataCollection<object> Values
    {
      get
      {
        if (_attributeValues == null)
          _attributeValues = new DataCollection<object>();
        return _attributeValues;
      }
      private set => _attributeValues = value;
    }

    [DataMember]
    public PagingInfo PageInfo
    {
      get => _pageInfo;
      set => _pageInfo = value;
    }

    [DataMember]
    public ColumnSet ColumnSet
    {
      get => _columnSet;
      set => _columnSet = value;
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

    [DataMember(Order = 50)]
    public int? TopCount
    {
      get => _topCount;
      set => _topCount = value;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal override void Accept(IQueryVisitor visitor) => visitor.Visit(this);

    public void AddOrder(string attributeName, OrderType orderType) => Orders.Add(new OrderExpression(attributeName, orderType));

    public void AddAttributeValue(string attributeName, object value)
    {
      Attributes.Add(attributeName);
      Values.Add(value);
    }
  }
}
