// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.OrderExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "OrderExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class OrderExpression : IExtensibleDataObject
  {
    private string _attributeName;
    private OrderType _orderType;
    private string _alias;
    private string _entityName;
    private ExtensionDataObject _extensionDataObject;

    public OrderExpression()
    {
    }

    public OrderExpression(string attributeName, OrderType orderType)
    {
      _attributeName = attributeName;
      _orderType = orderType;
    }

    public OrderExpression(string attributeName, OrderType orderType, string alias)
    {
      _attributeName = attributeName;
      _orderType = orderType;
      _alias = alias;
    }

    public OrderExpression(
      string attributeName,
      OrderType orderType,
      string alias,
      string entityName)
    {
      _attributeName = attributeName;
      _orderType = orderType;
      _alias = alias;
      _entityName = entityName;
    }

    [DataMember]
    public string AttributeName
    {
      get => _attributeName;
      set => _attributeName = value;
    }

    [DataMember]
    public OrderType OrderType
    {
      get => _orderType;
      set => _orderType = value;
    }

    [DataMember]
    public string Alias
    {
      get => _alias;
      set => _alias = value;
    }

    [DataMember]
    public string EntityName
    {
      get => _entityName;
      set => _entityName = value;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal void Accept(IQueryVisitor visitor) => visitor.Visit(this);

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
