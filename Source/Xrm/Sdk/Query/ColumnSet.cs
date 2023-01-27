// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.ColumnSet
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  /// <summary>Allow specifying selected columns</summary>
  [DataContract(Name = "ColumnSet", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class ColumnSet : IExtensibleDataObject
  {
    private bool _allColumns;
    private DataCollection<string> _columns;
    private DataCollection<XrmAttributeExpression> _attributeExpressions;
    private ExtensionDataObject _extensionDataObject;

    public ColumnSet() => HasLazyFileAttribute = false;

    public ColumnSet(bool allColumns)
    {
      _allColumns = allColumns;
      HasLazyFileAttribute = false;
    }

    public ColumnSet(params string[] columns)
    {
      _columns = new DataCollection<string>(columns);
      HasLazyFileAttribute = false;
    }

    public void AddColumns(params string[] columns)
    {
      foreach (var column in columns)
        Columns.Add(column);
    }

    public void AddColumn(string column) => Columns.Add(column);

    [DataMember]
    public bool AllColumns
    {
      get => _allColumns;
      set => _allColumns = value;
    }

    [DataMember]
    public DataCollection<string> Columns
    {
      get
      {
        if (_columns == null)
          _columns = new DataCollection<string>();
        return _columns;
      }
      set => _columns = value;
    }

    [DataMember]
    public DataCollection<XrmAttributeExpression> AttributeExpressions
    {
      get
      {
        if (_attributeExpressions == null)
          _attributeExpressions = new DataCollection<XrmAttributeExpression>();
        return _attributeExpressions;
      }
      set => _attributeExpressions = value;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal void Accept(IQueryVisitor visitor) => visitor.Visit(this);

    /// <summary>
    /// Gets and sets a flag for a lazy file attribute value. This flag is used
    /// when large files are not routed to plugins.
    /// </summary>
    /// <returns>True if the entity has a lazy file attribute, otherwise false.</returns>
    public bool HasLazyFileAttribute { get; set; }

    /// <summary>Gets and sets the lazy file attribute's entity name..</summary>
    /// <returns>True if the entity has a lazy file attribute, otherwise false.</returns>
    public string LazyFileAttributeEntityName { get; set; }

    /// <summary>Gets and sets the lazy file attribute name;</summary>
    /// <returns>The lazy file attribute key.</returns>
    public string LazyFileAttributeKey { get; set; }

    /// <summary>Gets and sets the lazy file attribute value;</summary>
    /// <returns>A lazy file attribute value.</returns>
    public Lazy<object> LazyFileAttributeValue { get; set; }

    /// <summary>Gets and sets the lazy file attribute value;</summary>
    /// <returns>A lazy file attribute value.</returns>
    public int LazyFileAttributeSizeLimit { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
