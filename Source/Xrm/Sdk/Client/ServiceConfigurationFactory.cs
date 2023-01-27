// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceConfigurationFactory
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Discovery;
using System;
using System.Reflection;

namespace Microsoft.Xrm.Sdk.Client
{
  public static class ServiceConfigurationFactory
  {
    public static IServiceConfiguration<TService> CreateConfiguration<TService>(Uri serviceUri) => CreateConfiguration<TService>(serviceUri, false, null);

    public static IServiceConfiguration<TService> CreateConfiguration<TService>(
      Uri serviceUri,
      bool enableProxyTypes,
      Assembly assembly)
    {
      if (serviceUri != null)
      {
        if (typeof (TService) == typeof (IDiscoveryService))
          return new DiscoveryServiceConfiguration(serviceUri) as IServiceConfiguration<TService>;
        if (typeof (TService) == typeof (IOrganizationService))
          return new OrganizationServiceConfiguration(serviceUri, enableProxyTypes, assembly) as IServiceConfiguration<TService>;
      }
      return null;
    }

    public static IServiceManagement<TService> CreateManagement<TService>(Uri serviceUri) => CreateManagement<TService>(serviceUri, false, null);

    public static IServiceManagement<TService> CreateManagement<TService>(
      Uri serviceUri,
      bool enableProxyTypes,
      Assembly assembly)
    {
      if (serviceUri != null)
      {
        if (typeof (TService) == typeof (IDiscoveryService))
          return new DiscoveryServiceConfiguration(serviceUri) as IServiceManagement<TService>;
        if (typeof (TService) == typeof (IOrganizationService))
          return new OrganizationServiceConfiguration(serviceUri, enableProxyTypes, assembly) as IServiceManagement<TService>;
      }
      return null;
    }
  }
}
