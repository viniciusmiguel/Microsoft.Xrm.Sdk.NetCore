// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.WebServiceClient.DiscoveryWebProxyClientContextInitializer
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Discovery;

namespace Microsoft.Xrm.Sdk.WebServiceClient
{
  /// <summary>Manages context for sdk calls</summary>
  internal sealed class DiscoveryWebProxyClientContextInitializer : 
    WebProxyClientContextInitializer<IDiscoveryService>
  {
    public DiscoveryWebProxyClientContextInitializer(DiscoveryWebProxyClient proxy)
      : base(proxy)
    {
      Initialize();
    }

    private void Initialize()
    {
      if (ServiceProxy == null)
        return;
      AddTokenToHeaders();
      AddCommonHeaders();
    }
  }
}
