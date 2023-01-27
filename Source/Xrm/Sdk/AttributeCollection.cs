// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.AttributeCollection
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
  /// <summary>Represents collection of attribute values</summary>
  [KnownType("GetKnownParameterTypes")]
  [CollectionDataContract(Name = "AttributeCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class AttributeCollection : DataCollection<string, object>
  {
    public AttributeCollection()
    {
    }

    protected internal AttributeCollection(IDictionary<string, object> collection)
      : base(collection)
    {
    }

    [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called by runtime to get known types")]
    private static IEnumerable<Type> GetKnownParameterTypes() => KnownTypesProvider.RetrieveKnownValueTypes();
  }
}
