// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.AppDomainBasedKnownProxyTypesProvider
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
  internal sealed class AppDomainBasedKnownProxyTypesProvider : KnownProxyTypesProvider
  {
    private static Dictionary<string, Type> _nameMap;
    private static Dictionary<Type, string> _typeMap;
    private Dictionary<string, Type> _currentMap;

    [SecuritySafeCritical]
    internal AppDomainBasedKnownProxyTypesProvider()
    {
      _nameMap = new Dictionary<string, Type>();
      _typeMap = new Dictionary<Type, string>();
      AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(CurrentDomain_AssemblyLoad);
      InitializeLoadedAssemblies();
    }

    public override Type GetTypeForName(string name, Assembly notUsed)
    {
      if (!string.IsNullOrEmpty(name))
      {
        if (_nameMap.ContainsKey(name))
          return _nameMap[name];
        lock (ThisLock)
        {
          if (_nameMap.ContainsKey(name))
            return _nameMap[name];
        }
      }
      return null;
    }

    public override string GetNameForType(Type type)
    {
      if (_typeMap.ContainsKey(type))
        return _typeMap[type];
      lock (ThisLock)
      {
        if (_typeMap.ContainsKey(type))
          return _typeMap[type];
      }
      return null;
    }

    protected override void AddTypeMapping(Assembly assembly, Type type, string proxyName)
    {
      if (_currentMap == null)
        OnBeginLoadTypes(assembly);
      if (_nameMap.ContainsKey(proxyName))
        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "A proxy type with the name {0} has been defined by another assembly. Current type: {1}, Existing type: {2}", proxyName, type.AssemblyQualifiedName, _nameMap[proxyName].AssemblyQualifiedName), proxyName);
      if (_currentMap.ContainsKey(proxyName))
        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "A proxy type with the name {0} has been defined by an assembly. Current type: {1}, Existing type: {2}", proxyName, type.AssemblyQualifiedName, _currentMap[proxyName].AssemblyQualifiedName), proxyName);
      _currentMap.Add(proxyName, type);
    }

    protected override void OnBeginLoadTypes(Assembly targetAssembly) => _currentMap = new Dictionary<string, Type>();

    protected override void OnEndLoadTypes()
    {
      if (_currentMap != null && _currentMap.Count > 0)
      {
        foreach (var key in _currentMap.Keys)
        {
          _nameMap[key] = _currentMap[key];
          _typeMap[_currentMap[key]] = key;
        }
      }
      _currentMap = null;
    }

    protected override void OnErrorLoadTypes() => _currentMap = null;

    private void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args) => RegisterAssembly(args.LoadedAssembly);
  }
}
