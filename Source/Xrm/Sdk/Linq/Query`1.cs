// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Linq.Query`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal sealed class Query<T> : 
    IOrderedQueryable<T>,
    IQueryable<T>,
    IEnumerable<T>,
    IEnumerable,
    IQueryable,
    IOrderedQueryable,
    IEntityQuery
  {
    public string EntityLogicalName { get; private set; }

    public Query(IQueryProvider provider, string entityLogicalName)
    {
      if (provider == null)
        throw new ArgumentNullException(nameof (provider));
      if (string.IsNullOrWhiteSpace(entityLogicalName))
        throw new ArgumentNullException(nameof (entityLogicalName));
      Provider = provider;
      EntityLogicalName = entityLogicalName;
      Expression = Expression.Constant(this);
    }

    public Query(IQueryProvider provider, Expression expression)
    {
      if (provider == null)
        throw new ArgumentNullException(nameof (provider));
      if (expression == null)
        throw new ArgumentNullException(nameof (expression));
      Provider = provider;
      Expression = expression;
    }

    public IEnumerator<T> GetEnumerator() => Provider is QueryProvider provider ? provider.GetEnumerator<T>(Expression) : throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The provider '{0}' is not of the expected type '{1}'.", Provider, typeof (QueryProvider)));

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Target = "CS$1$0000", Justification = "Value is returned from method and cannot be disposed.")]
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public Type ElementType => typeof (T);

    public IQueryProvider Provider { get; private set; }

    public Expression Expression { get; private set; }
  }
}
