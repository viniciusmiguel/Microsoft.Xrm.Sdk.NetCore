// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.PagingInfo
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "PagingInfo", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class PagingInfo : IExtensibleDataObject
  {
    private int _pageNumber;
    private int _count;
    private string _pagingCookie;
    private bool _returnTotalRecordCount;
    private ExtensionDataObject _extensionDataObject;

    /// <summary>The page to be returned.</summary>
    [DataMember]
    public int PageNumber
    {
      get => _pageNumber;
      set => _pageNumber = value;
    }

    /// <summary>number of rows per page.</summary>
    [DataMember]
    public int Count
    {
      get => _count;
      set => _count = value;
    }

    /// <summary>If total record count across all pages is required</summary>
    [DataMember]
    public bool ReturnTotalRecordCount
    {
      get => _returnTotalRecordCount;
      set => _returnTotalRecordCount = value;
    }

    /// <summary>
    /// Page Cookie information, null indicates old paging to be used.
    /// </summary>
    [DataMember]
    public string PagingCookie
    {
      get => _pagingCookie;
      set => _pagingCookie = value;
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
