// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.ConditionExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "ConditionExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class ConditionExpression : IExtensibleDataObject
  {
    private string _attributeName;
    private ConditionOperator _conditionOperator;
    private DataCollection<object> _values;
    private string _entityName;
    private bool _compareColumns;
    private bool _isReferencedEntityLinkEntity;
    internal bool IsDocumentBodyFilter;
    private ExtensionDataObject _extensionDataObject;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression" /> class.
    /// Condition Expression constructor.
    /// </summary>
    public ConditionExpression()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression" /> class.
    /// Condition Expression constructor.
    /// </summary>
    /// <param name="attributeName">Name of the attribute on which condition is to be defined on</param>
    /// <param name="conditionOperator">operator that has to be applied</param>
    /// <param name="values">list of values to be compared with</param>
    public ConditionExpression(
      string attributeName,
      ConditionOperator conditionOperator,
      params object[] values)
      : this(null, attributeName, conditionOperator, values)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression" /> class.
    /// Condition Expression constructor.
    /// </summary>
    /// <param name="entityName">Name of the entity of attribute on which condition is to be defined on</param>
    /// <param name="attributeName">Name of the attribute on which condition is to be defined on</param>
    /// <param name="conditionOperator">operator that has to be applied</param>
    /// <param name="values">list of values to be compared with</param>
    public ConditionExpression(
      string entityName,
      string attributeName,
      ConditionOperator conditionOperator,
      params object[] values)
    {
      _entityName = entityName;
      _attributeName = attributeName;
      _conditionOperator = conditionOperator;
      if (values == null)
        return;
      _values = new DataCollection<object>(values);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression" /> class.
    /// Condition Expression constructor.
    /// </summary>
    /// <param name="entityName">Name of the entity of attribute on which condition is to be defined on</param>
    /// <param name="attributeName">Name of the attribute on which condition is to be defined on</param>
    /// <param name="conditionOperator">operator that has to be applied</param>
    /// <param name="compareColumns">Boolean flag to define condition on attributes instead of condition on constant value(s)</param>
    /// <param name="values">list of values or attributes(if compareColumns is true) to be compared with</param>
    public ConditionExpression(
      string entityName,
      string attributeName,
      ConditionOperator conditionOperator,
      bool compareColumns,
      object[] values)
      : this(entityName, attributeName, conditionOperator, values)
    {
      _compareColumns = compareColumns;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression" /> class.
    /// Condition Expression constructor.
    /// </summary>
    /// <param name="entityName">Name of the entity of attribute on which condition is to be defined on</param>
    /// <param name="attributeName">Name of the attribute on which condition is to be defined on</param>
    /// <param name="conditionOperator">operator that has to be applied</param>
    /// <param name="compareColumns">Boolean flag to define condition on attributes instead of condition on constant value(s)</param>
    /// <param name="value">value or attributes(if compareColumns is true) to be compared with</param>
    public ConditionExpression(
      string entityName,
      string attributeName,
      ConditionOperator conditionOperator,
      bool compareColumns,
      object value)
      : this(entityName, attributeName, conditionOperator, (compareColumns ? 1 : 0) != 0, new object[1]
      {
        value
      })
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression" /> class.
    /// Condition Expression constructor.
    /// </summary>
    /// <param name="attributeName">Name of the attribute on which condition is to be defined on</param>
    /// <param name="conditionOperator">operator that has to be applied</param>
    /// <param name="compareColumns">Boolean flag to define condition on attributes instead of condition on constant value(s)</param>
    /// <param name="value">value or attributes(if compareColumns is true) to be compared with</param>
    public ConditionExpression(
      string attributeName,
      ConditionOperator conditionOperator,
      bool compareColumns,
      object value)
      : this(null, attributeName, conditionOperator, (compareColumns ? 1 : 0) != 0, new object[1]
      {
        value
      })
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression" /> class.
    /// Condition Expression constructor.
    /// </summary>
    /// <param name="attributeName">Name of the attribute on which condition is to be defined on</param>
    /// <param name="conditionOperator">operator that has to be applied</param>
    /// <param name="compareColumns">Boolean flag to define condition on attributes instead of condition on constant value(s)</param>
    /// <param name="values">list of values or attributes(if compareColumns is true) to be compared with</param>
    public ConditionExpression(
      string attributeName,
      ConditionOperator conditionOperator,
      bool compareColumns,
      object[] values)
      : this(null, attributeName, conditionOperator, compareColumns, values)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression" /> class.
    /// Condition Expression constructor.
    /// </summary>
    /// <param name="attributeName">Name of the attribute on which condition is to be defined on</param>
    /// <param name="conditionOperator">operator that has to be applied</param>
    /// <param name="value">value to be compared with</param>
    public ConditionExpression(
      string attributeName,
      ConditionOperator conditionOperator,
      object value)
      : this(attributeName, conditionOperator, new object[1]
      {
        value
      })
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression" /> class.
    /// Condition Expression constructor.
    /// </summary>
    /// <param name="entityName">Name of the entity of attribute on which condition is to be defined on</param>
    /// <param name="attributeName">Name of the attribute on which condition is to be defined on</param>
    /// <param name="conditionOperator">operator that has to be applied</param>
    /// <param name="value">value to be compared with</param>
    public ConditionExpression(
      string entityName,
      string attributeName,
      ConditionOperator conditionOperator,
      object value)
      : this(entityName, attributeName, conditionOperator, new object[1]
      {
        value
      })
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression" /> class.
    /// Condition Expression constructor.
    /// </summary>
    /// <param name="attributeName">Name of the attribute on which condition is to be defined on</param>
    /// <param name="conditionOperator">operator that has to be applied</param>
    public ConditionExpression(string attributeName, ConditionOperator conditionOperator)
      : this(null, attributeName, conditionOperator, Array.Empty<object>())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression" /> class.
    /// Condition Expression constructor.
    /// </summary>
    /// <param name="entityName">Name of the entity of attribute on which condition is to be defined on</param>
    /// <param name="attributeName">Name of the attribute on which condition is to be defined on</param>
    /// <param name="conditionOperator">operator that has to be applied</param>
    public ConditionExpression(
      string entityName,
      string attributeName,
      ConditionOperator conditionOperator)
      : this(entityName, attributeName, conditionOperator, Array.Empty<object>())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression" /> class.
    /// Condition Expression constructor.
    /// </summary>
    /// <param name="attributeName">Name of the attribute on which condition is to be defined on</param>
    /// <param name="conditionOperator">operator that has to be applied</param>
    /// <param name="values">list of values to be compared with</param>
    /// <remarks>Need to handle collections differently. esp. Guid arrays.</remarks>
    public ConditionExpression(
      string attributeName,
      ConditionOperator conditionOperator,
      ICollection values)
    {
      _attributeName = attributeName;
      _conditionOperator = conditionOperator;
      if (values == null)
        return;
      _values = new DataCollection<object>();
      foreach (var obj in values)
        _values.Add(obj);
    }

    /// <summary>
    /// Name or alias of LinkEntity to which this condition refers to
    /// </summary>
    [DataMember(Order = 60)]
    public string EntityName
    {
      get => _entityName;
      set => _entityName = value;
    }

    /// <summary>
    /// Bool flag to distinguish between column comparison condition vs condition on constant value(s)
    /// </summary>
    [DataMember]
    public bool CompareColumns
    {
      get => _compareColumns;
      set => _compareColumns = value;
    }

    /// <summary>
    /// Name of the attribute on which the condition is defined on
    /// </summary>
    [DataMember]
    public string AttributeName
    {
      get => _attributeName;
      set => _attributeName = value;
    }

    /// <summary>Condition Operator to be applied on condition</summary>
    [DataMember]
    public ConditionOperator Operator
    {
      get => _conditionOperator;
      set => _conditionOperator = value;
    }

    /// <summary>List of values to be compared to in the condition</summary>
    [DataMember]
    public DataCollection<object> Values
    {
      get
      {
        if (_values == null)
          _values = new DataCollection<object>();
        return _values;
      }
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] private set => _values = value;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal void Accept(IQueryVisitor visitor) => visitor.Visit(this);

    /// <summary>
    ///  Store condition variable between EntityExpression to QueryExpression conversion
    /// </summary>
    internal bool IsReferencedEntityLinkEntity
    {
      get => _isReferencedEntityLinkEntity;
      set => _isReferencedEntityLinkEntity = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
