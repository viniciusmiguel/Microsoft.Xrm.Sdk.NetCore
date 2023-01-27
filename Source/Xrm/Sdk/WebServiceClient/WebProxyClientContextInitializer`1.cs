﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.WebServiceClient.WebProxyClientContextInitializer`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.Xrm.Sdk.WebServiceClient
{
  /// <summary>Manages context for sdk calls</summary>
  public abstract class WebProxyClientContextInitializer<TService> : IDisposable where TService : class
  {
    private OperationContextScope _operationScope;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.WebServiceClient.WebProxyClientContextInitializer`1" /> class.
    ///     Constructs a context initializer
    /// </summary>
    /// <param name="proxy">sdk proxy</param>
    protected WebProxyClientContextInitializer(WebProxyClient<TService> proxy)
    {
      ServiceProxy = proxy;
      Initialize(proxy);
    }

    public WebProxyClient<TService> ServiceProxy { get; private set; }

    protected void AddTokenToHeaders()
    {
      var requestMessageProperty = new HttpRequestMessageProperty();
      requestMessageProperty.Headers[HttpRequestHeader.Authorization.ToString()] = "Bearer " + ServiceProxy.HeaderToken;
      OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessageProperty;
    }

    protected void AddCommonHeaders()
    {
      if (!string.IsNullOrEmpty(ServiceProxy.ClientAppName))
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("ClientAppName", "http://schemas.microsoft.com/xrm/2011/Contracts", ServiceProxy.ClientAppName));
      if (!string.IsNullOrEmpty(ServiceProxy.ClientAppVersion))
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("ClientAppVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", ServiceProxy.ClientAppVersion));
      if (!string.IsNullOrEmpty(ServiceProxy.SdkClientVersion))
      {
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("SdkClientVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", ServiceProxy.SdkClientVersion));
      }
      else
      {
        var assemblyFileVersion = ServiceProxy.GetXrmSdkAssemblyFileVersion();
        if (string.IsNullOrEmpty(assemblyFileVersion))
          return;
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("SdkClientVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", assemblyFileVersion));
      }
    }

    protected void Initialize(ClientBase<TService> proxy) => _operationScope = new OperationContextScope(proxy.InnerChannel);

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing || _operationScope == null)
        return;
      _operationScope.Dispose();
    }

    ~WebProxyClientContextInitializer() => Dispose(false);
  }
}
