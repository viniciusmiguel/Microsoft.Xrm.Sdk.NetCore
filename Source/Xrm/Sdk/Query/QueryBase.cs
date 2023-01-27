// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.QueryBase
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  /// <summary>Query class similary to V4</summary>
  [KnownType(typeof (QueryExpression))]
  [KnownType(typeof (QueryByAttribute))]
  [KnownType(typeof (FetchExpression))]
  [DataContract(Name = "QueryBase", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public abstract class QueryBase : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal abstract void Accept(IQueryVisitor visitor);

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
