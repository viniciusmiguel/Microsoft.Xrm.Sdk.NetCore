// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Linq.PagedItemCollection`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal sealed class PagedItemCollection<TSource> : 
    PagedItemCollectionBase,
    IEnumerable<TSource>,
    IEnumerable,
    IEnumerator<TSource>,
    IDisposable,
    IEnumerator
  {
    private TSource current;
    private IEnumerator<TSource> enumerator;
    private IEnumerable<TSource> source;

    public PagedItemCollection(
      IEnumerable<TSource> source,
      QueryExpression query,
      string pagingCookie,
      bool moreRecords)
      : base(query, pagingCookie, moreRecords)
    {
      this.source = source;
    }

    public PagedItemCollection<TSource> Clone() => new(source, Query, PagingCookie, MoreRecords);

    public IEnumerator<TSource> GetEnumerator() => Clone();

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "The enumerator will be disposed by the calling method.")]
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public TSource Current => current;

    public void Dispose()
    {
      if (enumerator != null)
        enumerator.Dispose();
      enumerator = null;
      current = default (TSource);
    }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
      if (enumerator == null)
        enumerator = source.GetEnumerator();
      if (!enumerator.MoveNext())
        return false;
      current = enumerator.Current;
      return true;
    }

    public void Reset() => throw new NotImplementedException();
  }
}
