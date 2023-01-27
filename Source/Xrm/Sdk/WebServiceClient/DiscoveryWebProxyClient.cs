// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.WebServiceClient.DiscoveryWebProxyClient
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;
using System;

namespace Microsoft.Xrm.Sdk.WebServiceClient
{
  public class DiscoveryWebProxyClient : WebProxyClient<IDiscoveryService>, IDiscoveryService
  {
    public DiscoveryWebProxyClient(Uri serviceUrl)
      : base(serviceUrl, Utilites.DefaultTimeout, false)
    {
    }

    public DiscoveryWebProxyClient(Uri serviceUrl, TimeSpan timeout)
      : base(serviceUrl, timeout, false)
    {
    }

    public DiscoveryResponse Execute(DiscoveryRequest request) => ExecuteCore(request);

    protected override WebProxyClientContextInitializer<IDiscoveryService> CreateNewInitializer() => new DiscoveryWebProxyClientContextInitializer(this);

    protected internal virtual DiscoveryResponse ExecuteCore(DiscoveryRequest request) => ExecuteAction<DiscoveryResponse>(() => Channel.Execute(request));
  }
}
