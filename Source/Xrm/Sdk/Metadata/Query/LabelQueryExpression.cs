// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.Query.LabelQueryExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
  /// <summary>Class used to specify a query for labels</summary>
  [DataContract(Name = "LabelQueryExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
  public sealed class LabelQueryExpression : MetadataQueryBase
  {
    private DataCollection<int> _filterLanguages;
    private int? _missingLabelBehavior;

    /// <summary>List of languages on which labels are filtered</summary>
    [DataMember]
    public DataCollection<int> FilterLanguages
    {
      get => _filterLanguages ?? (_filterLanguages = new DataCollection<int>());
      private set => _filterLanguages = value;
    }

    /// <summary>
    /// How should we default labels that don't exist in the requested languages
    /// </summary>
    [DataMember(Order = 60)]
    public int? MissingLabelBehavior
    {
      get => _missingLabelBehavior;
      set => _missingLabelBehavior = value;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal override void Accept(IMetadataQueryExpressionVisitor visitor) => visitor.Visit(this);
  }
}
