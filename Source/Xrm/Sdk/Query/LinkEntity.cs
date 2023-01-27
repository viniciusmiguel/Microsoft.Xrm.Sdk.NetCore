// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.LinkEntity
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "LinkEntity", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class LinkEntity : IExtensibleDataObject
  {
    private string _linkFromEntityName;
    private string _linkFromAttributeName;
    private string _linkToEntityName;
    private string _linkToAttributeName;
    private JoinOperator _joinOperator;
    private FilterExpression _linkCriteria;
    private string _entityAlias;
    private ColumnSet _columns;
    private DataCollection<LinkEntity> _linkEntities;
    private DataCollection<OrderExpression> _orders;
    private ExtensionDataObject _extensionDataObject;

    public LinkEntity()
      : this(null, null, null, null, JoinOperator.Inner)
    {
    }

    public LinkEntity(
      string linkFromEntityName,
      string linkToEntityName,
      string linkFromAttributeName,
      string linkToAttributeName,
      JoinOperator joinOperator)
    {
      _linkFromEntityName = linkFromEntityName;
      _linkToEntityName = linkToEntityName;
      _linkFromAttributeName = linkFromAttributeName;
      _linkToAttributeName = linkToAttributeName;
      _joinOperator = joinOperator;
      _columns = new ColumnSet();
      _linkCriteria = new FilterExpression();
    }

    [DataMember]
    public string LinkFromAttributeName
    {
      get => _linkFromAttributeName;
      set => _linkFromAttributeName = value;
    }

    [DataMember]
    public string LinkFromEntityName
    {
      get => _linkFromEntityName;
      set => _linkFromEntityName = value;
    }

    [DataMember]
    public string LinkToEntityName
    {
      get => _linkToEntityName;
      set => _linkToEntityName = value;
    }

    [DataMember]
    public string LinkToAttributeName
    {
      get => _linkToAttributeName;
      set => _linkToAttributeName = value;
    }

    [DataMember]
    public JoinOperator JoinOperator
    {
      get => _joinOperator;
      set => _joinOperator = value;
    }

    [DataMember]
    public FilterExpression LinkCriteria
    {
      get => _linkCriteria;
      set => _linkCriteria = value;
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
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] private set => _linkEntities = value;
    }

    [DataMember]
    public ColumnSet Columns
    {
      get
      {
        if (_columns == null)
          _columns = new ColumnSet();
        return _columns;
      }
      set => _columns = value;
    }

    [DataMember]
    public string EntityAlias
    {
      get => _entityAlias;
      set => _entityAlias = value;
    }

    internal void Accept(IQueryVisitor visitor) => visitor.Visit(this);

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
      var linkEntity = new LinkEntity(_linkFromEntityName, linkToEntityName, linkFromAttributeName, linkToAttributeName, joinOperator);
      LinkEntities.Add(linkEntity);
      return linkEntity;
    }

    [DataMember(Order = 80)]
    public DataCollection<OrderExpression> Orders
    {
      get
      {
        if (_orders == null)
          _orders = new DataCollection<OrderExpression>();
        return _orders;
      }
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] private set => _orders = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
