// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceContextInitializer`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.ServiceModel;

namespace Microsoft.Xrm.Sdk.Client
{
  internal abstract class ServiceContextInitializer<TService> : IDisposable where TService : class
  {
    private OperationContextScope _operationScope;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Client.ServiceContextInitializer`1" /> class.
    /// Constructs a context initializer
    /// </summary>
    /// <param name="proxy">sdk proxy</param>
    /// <param name="serviceProxyConfiguration"></param>
    protected ServiceContextInitializer(ServiceProxy<TService> proxy)
    {
      ClientExceptionHelper.ThrowIfNull(proxy, nameof (proxy));
      ServiceProxy = proxy;
      Initialize(proxy);
    }

    public ServiceProxy<TService> ServiceProxy { get; private set; }

    protected void Initialize(ServiceProxy<TService> proxy) => _operationScope = new OperationContextScope((IContextChannel) proxy.ServiceChannel.Channel);

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    ~ServiceContextInitializer() => Dispose(false);

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing || _operationScope == null)
        return;
      _operationScope.Dispose();
    }
  }
}
