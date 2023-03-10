// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.FetchExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "FetchExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class FetchExpression : QueryBase
  {
    private string _query;

    public FetchExpression()
      : this(null)
    {
    }

    public FetchExpression(string query) => _query = query;

    [DataMember]
    public string Query
    {
      get => _query;
      set => _query = value;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal override void Accept(IQueryVisitor visitor) => visitor.Visit(this);
  }
}
