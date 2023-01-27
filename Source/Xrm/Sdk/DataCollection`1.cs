// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.DataCollection`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>XRM Collection object</summary>
  /// <typeparam name="T">The type of elements in the collection</typeparam>
  [Serializable]
  public class DataCollection<T> : Collection<T>
  {
    internal DataCollection()
    {
    }

    internal DataCollection(IList<T> list) => AddRange(list);

    /// <summary>Add items to the collection</summary>
    /// <param name="items"></param>
    public void AddRange(params T[] items)
    {
      if (items == null)
        return;
      AddRange((IEnumerable<T>) items);
    }

    /// <summary>Add items from another collection</summary>
    /// <param name="items"></param>
    public void AddRange(IEnumerable<T> items)
    {
      if (items == null)
        return;
      foreach (var obj in items)
        Add(obj);
    }

    /// <summary>Converts the collection into an array</summary>
    /// <returns>Array for the collection</returns>
    public T[] ToArray()
    {
      var array = new T[Count];
      CopyTo(array, 0);
      return array;
    }
  }
}
