// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.XrmAttributeExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "AttributeExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class XrmAttributeExpression : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;
    private XrmAggregateType _aggregateType;
    private string _attributeName;
    private string _alias;
    private bool _hasGroupBy;
    private XrmDateTimeGrouping _dateTimeGroupingType;

    public XrmAttributeExpression()
      : this(null, XrmAggregateType.None, null)
    {
    }

    public XrmAttributeExpression(string attributeName) => _attributeName = attributeName;

    public XrmAttributeExpression(string attributeName, XrmAggregateType aggregateType) => _attributeName = attributeName;

    public XrmAttributeExpression(
      string attributeName,
      XrmAggregateType aggregateType,
      string alias)
    {
      _attributeName = attributeName;
      _aggregateType = aggregateType;
      _alias = alias;
    }

    public XrmAttributeExpression(
      string attributeName,
      XrmAggregateType aggregateType,
      string alias,
      XrmDateTimeGrouping dateTimeGrouping)
    {
      _attributeName = attributeName;
      _aggregateType = aggregateType;
      _alias = alias;
      _dateTimeGroupingType = dateTimeGrouping;
    }

    [DataMember]
    public string AttributeName
    {
      get => _attributeName;
      set => _attributeName = value;
    }

    [DataMember]
    public XrmAggregateType AggregateType
    {
      get => _aggregateType;
      set => _aggregateType = value;
    }

    [DataMember]
    public string Alias
    {
      get => _alias;
      set => _alias = value;
    }

    [DataMember]
    public bool HasGroupBy
    {
      get => _hasGroupBy;
      set => _hasGroupBy = value;
    }

    [DataMember]
    public XrmDateTimeGrouping DateTimeGrouping
    {
      get => _dateTimeGroupingType;
      set => _dateTimeGroupingType = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
