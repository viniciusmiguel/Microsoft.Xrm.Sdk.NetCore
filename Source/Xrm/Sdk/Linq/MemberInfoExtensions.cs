// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Linq.MemberInfoExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal static class MemberInfoExtensions
  {
    private static readonly ConcurrentDictionary<MemberInfoAttributeType, IEnumerable<object>> _memberInfoToAttributesLookup = new(8, 11);

    /// <summary>
    /// Returns a collection of custom attributes for a given member.
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo info) where T : Attribute
    {
      var key = new MemberInfoAttributeType()
      {
        MemberInfo = info,
        Type = typeof (T)
      };
      return _memberInfoToAttributesLookup.GetOrAdd(key, _ => info.GetCustomAttributes(typeof (T), true)).Cast<T>();
    }

    /// <summary>Returns the first custom attribute of a given member.</summary>
    /// <param name="info"></param>
    /// <returns></returns>
    public static T GetFirstOrDefaultCustomAttribute<T>(this MemberInfo info) where T : Attribute => info.GetCustomAttributes<T>().FirstOrDefault<T>();

    /// <summary>
    /// Retrieves the attribute logical name mapped to the member.
    /// </summary>
    /// <param name="property"></param>
    /// <returns></returns>
    public static string GetLogicalName(this MemberInfo property)
    {
      AttributeLogicalNameAttribute defaultCustomAttribute1 = property.GetFirstOrDefaultCustomAttribute<AttributeLogicalNameAttribute>();
      if (defaultCustomAttribute1 != null)
        return defaultCustomAttribute1.LogicalName;
      EntityLogicalNameAttribute defaultCustomAttribute2 = property.GetFirstOrDefaultCustomAttribute<EntityLogicalNameAttribute>();
      if (defaultCustomAttribute2 != null)
        return defaultCustomAttribute2.LogicalName;
      return property.GetFirstOrDefaultCustomAttribute<RelationshipSchemaNameAttribute>()?.SchemaName;
    }

    private struct MemberInfoAttributeType
    {
      public MemberInfo MemberInfo;
      public Type Type;
    }
  }
}
