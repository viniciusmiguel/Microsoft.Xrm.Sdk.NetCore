// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.ParameterCollection
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>collection of fields</summary>
  [KnownType("GetKnownParameterTypes")]
  [CollectionDataContract(Name = "ParameterCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public class ParameterCollection : DataCollection<string, object>
  {
    public ParameterCollection()
    {
    }

    protected ParameterCollection(IDictionary<string, object> collection)
      : base(collection)
    {
    }

    public void AddOrUpdateIfNotNull(string key, object obj)
    {
      if (obj == null)
        return;
      this[key] = obj;
    }

    [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called by runtime to get known types")]
    private static IEnumerable<Type> GetKnownParameterTypes() => KnownTypesProvider.RetrieveKnownValueTypes();

    /// <summary>Gets the value associated with the specified key</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">The key of the value to get.</param>
    /// <param name="value">When this method returns, contains the value associated with the specified key, if the key is found and value is of type T; otherwise, the default value for the type of T.</param>
    /// <returns>true if the ParameterCollection contains an element with the specified key and is of type T; otherwise, false.</returns>
    public bool TryGetValue<T>(string key, out T value)
    {
      value = default (T);
      object obj1;
      if (!TryGetValue(key, out obj1) || !(obj1 is T obj2))
        return false;
      value = obj2;
      return true;
    }
  }
}
