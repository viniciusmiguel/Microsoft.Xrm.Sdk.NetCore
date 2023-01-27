// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.KnownProxyTypesProvider
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Security;

namespace Microsoft.Xrm.Sdk
{
  internal abstract class KnownProxyTypesProvider
  {
    private static AppDomainBasedKnownProxyTypesProvider _appDomainBasedInstance = null;
    private static AssemblyBasedKnownProxyTypesProvider _assemblyBasedInstance = null;
    private static object _lockObject = new();
    protected List<Assembly> _strongTypeAssemblies;
    protected static Dictionary<Type, string> _typeAttributes = new();

    [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
    static KnownProxyTypesProvider()
    {
      _typeAttributes.Add(typeof (EntityLogicalNameAttribute), "LogicalName");
      _typeAttributes.Add(typeof (ResponseProxyAttribute), "Name");
    }

    [SecuritySafeCritical]
    protected KnownProxyTypesProvider() => _strongTypeAssemblies = new List<Assembly>();

    protected abstract void AddTypeMapping(Assembly assembly, Type type, string proxyName);

    public abstract Type GetTypeForName(string name, Assembly proxyTypesAssembly);

    public abstract string GetNameForType(Type type);

    protected abstract void OnBeginLoadTypes(Assembly targetAssembly);

    protected abstract void OnEndLoadTypes();

    protected abstract void OnErrorLoadTypes();

    internal static KnownProxyTypesProvider GetInstance(bool supportIndividualAssemblies)
    {
      if (supportIndividualAssemblies)
      {
        if (_assemblyBasedInstance == null)
        {
          lock (_lockObject)
          {
            if (_assemblyBasedInstance == null)
              _assemblyBasedInstance = new AssemblyBasedKnownProxyTypesProvider();
          }
        }
        return _assemblyBasedInstance;
      }
      if (_appDomainBasedInstance == null)
      {
        lock (_lockObject)
        {
          if (_appDomainBasedInstance == null)
            _appDomainBasedInstance = new AppDomainBasedKnownProxyTypesProvider();
        }
      }
      return _appDomainBasedInstance;
    }

    protected static object ThisLock => _lockObject;

    public void RegisterAssembly(string assemblyName) => RegisterAssembly(Assembly.Load(assemblyName));

    public void RegisterAssembly(Assembly assembly)
    {
      if (_strongTypeAssemblies.Contains(assembly))
        return;
      lock (_lockObject)
      {
        if (_strongTypeAssemblies.Contains(assembly))
          return;
        _strongTypeAssemblies.Add(assembly);
        LoadKnownTypes(assembly);
      }
    }

    private void LoadKnownTypes(Assembly assembly)
    {
      var customAttributes1 = assembly.GetCustomAttributes(typeof (ProxyTypesAssemblyAttribute), false);
      if (customAttributes1 == null || customAttributes1.Length == 0)
        return;
      OnBeginLoadTypes(assembly);
      try
      {
        foreach (var exportedType in assembly.GetExportedTypes())
        {
          foreach (var typeAttribute in _typeAttributes)
          {
            var customAttributes2 = exportedType.GetCustomAttributes(typeAttribute.Key, false);
            if (customAttributes2 != null && customAttributes2.Length != 0 && customAttributes2[0].GetType().GetProperty(typeAttribute.Value) != null)
            {
              var proxyName = (string) customAttributes2[0].GetType().GetProperty(typeAttribute.Value).GetValue(customAttributes2[0], null);
              AddTypeMapping(assembly, exportedType, proxyName);
            }
          }
        }
        OnEndLoadTypes();
      }
      catch
      {
        OnErrorLoadTypes();
        throw;
      }
    }

    protected void InitializeLoadedAssemblies()
    {
      foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        RegisterAssembly(assembly);
    }
  }
}
