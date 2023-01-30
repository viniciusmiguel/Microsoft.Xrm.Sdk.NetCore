/*
// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.DiscoveryServiceProxy
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Discovery;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace Microsoft.Xrm.Sdk.Client
{
  /// <summary>
  /// helper class that manages a ChannelFactory and serves up channels for sdk client use
  /// <remarks>For internal use only</remarks>
  /// </summary>
  public class DiscoveryServiceProxy : ServiceProxy<IDiscoveryService>, IDiscoveryService
  {
    internal DiscoveryServiceProxy()
    {
    }

    public DiscoveryServiceProxy(
      Uri uri,
      Uri homeRealmUri,
      ClientCredentials clientCredentials,
      ClientCredentials deviceCredentials)
      : base(uri, homeRealmUri, clientCredentials, deviceCredentials)
    {
    }

    public DiscoveryServiceProxy(
      IServiceConfiguration<IDiscoveryService> serviceConfiguration,
      SecurityTokenResponse securityTokenResponse)
      : base(serviceConfiguration, securityTokenResponse)
    {
    }

    public DiscoveryServiceProxy(
      IServiceConfiguration<IDiscoveryService> serviceConfiguration,
      ClientCredentials clientCredentials)
      : base(serviceConfiguration, clientCredentials)
    {
    }

    public DiscoveryServiceProxy(
      IServiceManagement<IDiscoveryService> serviceManagement,
      SecurityTokenResponse securityTokenResponse)
      : this(serviceManagement as IServiceConfiguration<IDiscoveryService>, securityTokenResponse)
    {
    }

    public DiscoveryServiceProxy(
      IServiceManagement<IDiscoveryService> serviceManagement,
      ClientCredentials clientCredentials)
      : this(serviceManagement as IServiceConfiguration<IDiscoveryService>, clientCredentials)
    {
    }

    public DiscoveryResponse Execute(DiscoveryRequest request)
    {
      var retry = new bool?();
      do
      {
        var forceClose = false;
        try
        {
          using (new DiscoveryServiceContextInitializer(this))
            return ServiceChannel.Channel.Execute(request);
        }
        catch (MessageSecurityException ex)
        {
          forceClose = true;
          retry = ShouldRetry(ex, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (EndpointNotFoundException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (TimeoutException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (FaultException<DiscoveryServiceFault> ex)
        {
          forceClose = true;
          retry = HandleFailover(ex.Detail, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch
        {
          forceClose = true;
          throw;
        }
        finally
        {
          CloseChannel(forceClose);
        }
      }
      while (retry.HasValue && retry.Value);
      return null;
    }
  }
}
*/
