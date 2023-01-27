// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Extensions.ServiceProviderExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;

namespace Microsoft.Xrm.Sdk.Extensions
{
  public static class ServiceProviderExtensions
  {
    public static T Get<T>(this IServiceProvider serviceProvider) => (T) serviceProvider.GetService(typeof (T));

    public static IOrganizationService GetOrganizationService(
      this IServiceProvider serviceProvider,
      Guid id)
    {
      return serviceProvider.Get<IOrganizationServiceFactory>().CreateOrganizationService(new Guid?(id));
    }
  }
}
