// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.DataCollection`2
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Base class for Dictionary types in XRM SDK</summary>
  /// <typeparam name="TKey"></typeparam>
  /// <typeparam name="TValue"></typeparam>
  [Serializable]
  public abstract class DataCollection<TKey, TValue> : 
    IEnumerable<KeyValuePair<TKey, TValue>>,
    IEnumerable
  {
    private IDictionary<TKey, TValue> _innerDictionary = new Dictionary<TKey, TValue>();
    private bool _isReadOnly;

    protected internal DataCollection(IDictionary<TKey, TValue> collection) => _innerDictionary = collection;

    protected internal DataCollection()
    {
    }

    /// <summary>Adds an item to the collection</summary>
    /// <param name="item">Item to be added</param>
    public void Add(KeyValuePair<TKey, TValue> item)
    {
      CheckIsReadOnly();
      _innerDictionary.Add(item);
    }

    /// <summary>Adds the given items to the collection</summary>
    /// <param name="items"></param>
    public void AddRange(params KeyValuePair<TKey, TValue>[] items)
    {
      CheckIsReadOnly();
      AddRange((IEnumerable<KeyValuePair<TKey, TValue>>) items);
    }

    /// <summary>Adds the given items to the collection</summary>
    /// <param name="items"></param>
    public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> items)
    {
      if (items == null)
        return;
      CheckIsReadOnly();
      ICollection<KeyValuePair<TKey, TValue>> innerDictionary = _innerDictionary;
      foreach (var keyValuePair in items)
        innerDictionary.Add(keyValuePair);
    }

    /// <summary>Adds an item to the collection</summary>
    /// <param name="key">Key of the item</param>
    /// <param name="value">Value to be added</param>
    public void Add(TKey key, TValue value)
    {
      CheckIsReadOnly();
      _innerDictionary.Add(key, value);
    }

    /// <summary>Property accessor value</summary>
    public virtual TValue this[TKey key]
    {
      get => _innerDictionary[key];
      set
      {
        CheckIsReadOnly();
        _innerDictionary[key] = value;
      }
    }

    /// <summary>Clears the items from the collection</summary>
    public void Clear()
    {
      CheckIsReadOnly();
      _innerDictionary.Clear();
    }

    /// <summary>Checks if an item exists in the collection</summary>
    /// <param name="key">Key for the item</param>
    /// <returns>True if the item is contained in the collection</returns>
    public bool Contains(TKey key) => _innerDictionary.ContainsKey(key);

    /// <summary>
    /// Determines whether the collection contains a specific value.
    /// </summary>
    /// <param name="item">The object to locate in the collection</param>
    /// <returns>True if item is found in the collection; otherwise, false.</returns>
    public bool Contains(KeyValuePair<TKey, TValue> key) => _innerDictionary.Contains(key);

    /// <summary>Gets the value associated with the specified key.</summary>
    /// <param name="key">Key for the item</param>
    /// <param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
    /// <returns>True if the DataCollection contains an element with the specified key; otherwise, false.</returns>
    public bool TryGetValue(TKey key, out TValue value) => _innerDictionary.TryGetValue(key, out value);

    /// <summary>
    /// Copies the elements of the collection to an Array, starting at a particular Array index.
    /// </summary>
    /// <param name="array">The one-dimensional Array that is the destination of the elements copied from the collection. The Array must have zero-based indexing.</param>
    /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => _innerDictionary.CopyTo(array, arrayIndex);

    /// <summary>Checks if an item exists in the dictionary</summary>
    /// <param name="key">Key for the item</param>
    /// <returns>True if the item is contained in the dictionary</returns>
    public bool ContainsKey(TKey key) => _innerDictionary.ContainsKey(key);

    /// <summary>Removes an item from the collection</summary>
    /// <param name="key"></param>
    /// <returns>True if the item was removed</returns>
    public bool Remove(TKey key)
    {
      CheckIsReadOnly();
      return _innerDictionary.Remove(key);
    }

    /// <summary>
    /// Removes the first occurrence of a specific object from the collection.
    /// </summary>
    /// <param name="item">The object to remove from the collection.</param>
    /// <returns>True if item was successfully removed from the collection; otherwise, false. This method also returns false if item is not found in the original collection.</returns>
    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
      CheckIsReadOnly();
      return _innerDictionary.Remove(item);
    }

    /// <summary>Number of elements in the collection</summary>
    public int Count => _innerDictionary.Count;

    public ICollection<TKey> Keys => _innerDictionary.Keys;

    public ICollection<TValue> Values => _innerDictionary.Values;

    /// <summary>
    /// Gets a value indicating whether the collection is read-only.
    /// </summary>
    public virtual bool IsReadOnly
    {
      get => _isReadOnly;
      internal set => _isReadOnly = value;
    }

    internal void SetItemInternal(TKey key, TValue value) => _innerDictionary[key] = value;

    internal void ClearInternal() => _innerDictionary.Clear();

    internal bool RemoveInternal(TKey key) => _innerDictionary.Remove(key);

    private void CheckIsReadOnly()
    {
      if (IsReadOnly)
        throw new InvalidOperationException("The collection is read-only.");
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _innerDictionary.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _innerDictionary.GetEnumerator();

    [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called by runtime to get known types")]
    private static IEnumerable<Type> GetKnownParameterTypes() => KnownTypesProvider.RetrieveKnownValueTypes();
  }
}
