// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.AssemblyBasedKnownProxyTypesProvider
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Security;

namespace Microsoft.Xrm.Sdk
{
  internal sealed class AssemblyBasedKnownProxyTypesProvider : KnownProxyTypesProvider
  {
    private static Dictionary<Assembly, EarlyBoundTypeMap> _earlyBoundTypesMapByAssembly;
    private static Dictionary<Assembly, EarlyBoundNameMap> _earlyBoundNamesMapByAssembly;
    private Assembly _currentlyLoadingAssembly;

    [SecuritySafeCritical]
    internal AssemblyBasedKnownProxyTypesProvider()
    {
      _earlyBoundTypesMapByAssembly = new Dictionary<Assembly, EarlyBoundTypeMap>();
      _earlyBoundNamesMapByAssembly = new Dictionary<Assembly, EarlyBoundNameMap>();
    }

    public override Type GetTypeForName(string name, Assembly proxyTypesAssembly)
    {
      if (proxyTypesAssembly == null)
        return null;
      RegisterAssembly(proxyTypesAssembly);
      lock (ThisLock)
      {
        EarlyBoundTypeMap earlyBoundTypeMap = null;
        if (_earlyBoundTypesMapByAssembly.TryGetValue(proxyTypesAssembly, out earlyBoundTypeMap))
        {
          if (earlyBoundTypeMap.ContainsKey(name))
            return earlyBoundTypeMap[name];
        }
      }
      return null;
    }

    public override string GetNameForType(Type type)
    {
      var assembly = type.Assembly;
      RegisterAssembly(assembly);
      lock (ThisLock)
      {
        EarlyBoundNameMap earlyBoundNameMap = null;
        if (_earlyBoundNamesMapByAssembly.TryGetValue(assembly, out earlyBoundNameMap))
        {
          if (earlyBoundNameMap.ContainsKey(type))
            return earlyBoundNameMap[type];
        }
      }
      return null;
    }

    protected override void AddTypeMapping(Assembly assembly, Type type, string proxyName)
    {
      EarlyBoundTypeMap earlyBoundTypeMap = null;
      _earlyBoundTypesMapByAssembly.TryGetValue(assembly, out earlyBoundTypeMap);
      if (earlyBoundTypeMap == null)
      {
        earlyBoundTypeMap = new EarlyBoundTypeMap();
        _earlyBoundTypesMapByAssembly[assembly] = earlyBoundTypeMap;
      }
      if (earlyBoundTypeMap.ContainsKey(proxyName))
        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "A proxy type with the name {0} has been defined by multiple types. Current type: {1}, Existing type: {2}", proxyName, type.AssemblyQualifiedName, earlyBoundTypeMap[proxyName].AssemblyQualifiedName), proxyName);
      earlyBoundTypeMap.Add(proxyName, type);
      EarlyBoundNameMap earlyBoundNameMap = null;
      _earlyBoundNamesMapByAssembly.TryGetValue(assembly, out earlyBoundNameMap);
      if (earlyBoundNameMap == null)
      {
        earlyBoundNameMap = new EarlyBoundNameMap();
        _earlyBoundNamesMapByAssembly[assembly] = earlyBoundNameMap;
      }
      if (earlyBoundNameMap.ContainsKey(type))
        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "A proxy type with the name {0} has been defined by multiple types. Current type: {1}, Existing type: {2}", proxyName, type.AssemblyQualifiedName, type.AssemblyQualifiedName), proxyName);
      earlyBoundNameMap.Add(type, proxyName);
    }

    protected override void OnBeginLoadTypes(Assembly targetAssembly) => _currentlyLoadingAssembly = targetAssembly;

    protected override void OnEndLoadTypes() => _currentlyLoadingAssembly = null;

    protected override void OnErrorLoadTypes()
    {
      if (_currentlyLoadingAssembly != null && _earlyBoundTypesMapByAssembly.ContainsKey(_currentlyLoadingAssembly))
        _earlyBoundTypesMapByAssembly.Remove(_currentlyLoadingAssembly);
      _currentlyLoadingAssembly = null;
    }

    private sealed class EarlyBoundTypeMap : Dictionary<string, Type>
    {
    }

    private sealed class EarlyBoundNameMap : Dictionary<Type, string>
    {
    }
  }
}
