// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.FilterExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "FilterExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class FilterExpression : IExtensibleDataObject
  {
    private LogicalOperator _filterOperator;
    private string _filterHint;
    private DataCollection<ConditionExpression> _conditions;
    private DataCollection<FilterExpression> _filters;
    private bool _isQuickFindFilter;
    private bool _lateMaterialize;
    private ExtensionDataObject _extensionDataObject;

    public FilterExpression()
    {
    }

    public FilterExpression(LogicalOperator filterOperator) => FilterOperator = filterOperator;

    [DataMember]
    public LogicalOperator FilterOperator
    {
      get => _filterOperator;
      set => _filterOperator = value;
    }

    /// <summary>Filter hint</summary>
    [DataMember(Order = 82, EmitDefaultValue = false)]
    public string FilterHint
    {
      get => _filterHint;
      set => _filterHint = value;
    }

    [DataMember]
    public DataCollection<ConditionExpression> Conditions
    {
      get
      {
        if (_conditions == null)
          _conditions = new DataCollection<ConditionExpression>();
        return _conditions;
      }
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] private set => _conditions = value;
    }

    [DataMember]
    public DataCollection<FilterExpression> Filters
    {
      get
      {
        if (_filters == null)
          _filters = new DataCollection<FilterExpression>();
        return _filters;
      }
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] private set => _filters = value;
    }

    [DataMember(Order = 51, EmitDefaultValue = false)]
    public bool IsQuickFindFilter
    {
      get => _isQuickFindFilter;
      set => _isQuickFindFilter = value;
    }

    /// <summary>
    /// Store state between EntityExpression to QueryExpression conversion
    /// </summary>
    internal bool LateMaterialize
    {
      get => _lateMaterialize;
      set => _lateMaterialize = value;
    }

    /// <summary>Add multiple value condition to the filter</summary>
    /// <param name="attributeName">Name of the attribute that the condition is on</param>
    /// <param name="conditionOperator">condition operator to be applied</param>
    /// <param name="values">list of values to be compared with</param>
    public void AddCondition(
      string attributeName,
      ConditionOperator conditionOperator,
      params object[] values)
    {
      Conditions.Add(new ConditionExpression(attributeName, conditionOperator, values));
    }

    /// <summary>Add multiple value condition to the filter</summary>
    /// <param name="entityName">Name of the entity of attribute on which condition is to be defined on</param>
    /// <param name="attributeName">Name of the attribute on which condition is to be defined on</param>
    /// <param name="conditionOperator">operator that has to be applied</param>
    /// <param name="values">list of values to be compared with</param>
    public void AddCondition(
      string entityName,
      string attributeName,
      ConditionOperator conditionOperator,
      params object[] values)
    {
      Conditions.Add(new ConditionExpression(entityName, attributeName, conditionOperator, values));
    }

    /// <summary>Add multiple value condition to the filter</summary>
    /// <param name="attributeName">Name of the attribute on which condition is to be defined on</param>
    /// <param name="conditionOperator">operator that has to be applied</param>
    /// <param name="compareColumns">Boolean flag to define condition on attributes instead of condition on constant value(s)</param>
    /// <param name="values">list of values or attributes(if compareColumns is true) to be compared with</param>
    public void AddCondition(
      string attributeName,
      ConditionOperator conditionOperator,
      bool compareColumns,
      object[] values)
    {
      Conditions.Add(new ConditionExpression(attributeName, conditionOperator, compareColumns, values));
    }

    /// <summary>Add multiple value condition to the filter</summary>
    /// <param name="entityName">Name of the entity of attribute on which condition is to be defined on</param>
    /// <param name="attributeName">Name of the attribute on which condition is to be defined on</param>
    /// <param name="conditionOperator">operator that has to be applied</param>
    /// <param name="compareColumns">Boolean flag to define condition on attributes instead of condition on constant value(s)</param>
    /// <param name="values">list of values or attributes(if compareColumns is true) to be compared with</param>
    public void AddCondition(
      string entityName,
      string attributeName,
      ConditionOperator conditionOperator,
      bool compareColumns,
      object[] values)
    {
      Conditions.Add(new ConditionExpression(entityName, attributeName, conditionOperator, compareColumns, values));
    }

    /// <summary>Add multiple value condition to the filter</summary>
    /// <param name="attributeName">Name of the attribute on which condition is to be defined on</param>
    /// <param name="conditionOperator">operator that has to be applied</param>
    /// <param name="compareColumns">Boolean flag to define condition on attributes instead of condition on constant value(s)</param>
    /// <param name="value">value or attribute(if compareColumns is true) to be compared with</param>
    public void AddCondition(
      string attributeName,
      ConditionOperator conditionOperator,
      bool compareColumns,
      object value)
    {
      Conditions.Add(new ConditionExpression(attributeName, conditionOperator, (compareColumns ? 1 : 0) != 0, new object[1]
      {
        value
      }));
    }

    /// <summary>Add multiple value condition to the filter</summary>
    /// <param name="entityName">Name of the entity of attribute on which condition is to be defined on</param>
    /// <param name="attributeName">Name of the attribute on which condition is to be defined on</param>
    /// <param name="conditionOperator">operator that has to be applied</param>
    /// <param name="compareColumns">Boolean flag to define condition on attributes instead of condition on constant value(s)</param>
    /// <param name="value">value or attribute(if compareColumns is true) to be compared with</param>
    public void AddCondition(
      string entityName,
      string attributeName,
      ConditionOperator conditionOperator,
      bool compareColumns,
      object value)
    {
      Conditions.Add(new ConditionExpression(entityName, attributeName, conditionOperator, (compareColumns ? 1 : 0) != 0, new object[1]
      {
        value
      }));
    }

    /// <summary>Add condition to the filter</summary>
    /// <param name="condition">condition to be added</param>
    public void AddCondition(ConditionExpression condition) => Conditions.Add(condition);

    /// <summary>add filter to current filter</summary>
    /// <param name="logicalOperator"></param>
    /// <returns></returns>
    public FilterExpression AddFilter(LogicalOperator logicalOperator)
    {
      var filterExpression = new FilterExpression();
      filterExpression.FilterOperator = logicalOperator;
      Filters.Add(filterExpression);
      return filterExpression;
    }

    /// <summary>add filter to current filter</summary>
    /// <param name="childFilter">Filter to be added.</param>
    public void AddFilter(FilterExpression childFilter)
    {
      if (childFilter == null)
        return;
      Filters.Add(childFilter);
    }

    internal void Accept(IQueryVisitor visitor) => visitor.Visit(this);

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
