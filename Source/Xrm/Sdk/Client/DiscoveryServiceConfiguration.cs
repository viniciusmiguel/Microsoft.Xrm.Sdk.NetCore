/*
// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.DiscoveryServiceConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Discovery;
using System;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.Client
{
  internal sealed class DiscoveryServiceConfiguration : 
    IServiceConfiguration<IDiscoveryService>,
    IWebAuthentication<IDiscoveryService>,
    IServiceManagement<IDiscoveryService>,
    IEndpointSwitch
  {
    private readonly ServiceConfiguration<IDiscoveryService> service;

    private DiscoveryServiceConfiguration()
    {
    }

    internal DiscoveryServiceConfiguration(Uri serviceUri) => service = new ServiceConfiguration<IDiscoveryService>(serviceUri, false);

    public ServiceEndpoint CurrentServiceEndpoint
    {
      get => service.CurrentServiceEndpoint;
      set => service.CurrentServiceEndpoint = value;
    }

    public IssuerEndpoint CurrentIssuer
    {
      get => service.CurrentIssuer;
      set => service.CurrentIssuer = value;
    }

    public AuthenticationProviderType AuthenticationType => service.AuthenticationType;

    public ServiceEndpointDictionary ServiceEndpoints => service.ServiceEndpoints;

    public IssuerEndpointDictionary IssuerEndpoints => service.IssuerEndpoints;

    public CrossRealmIssuerEndpointCollection CrossRealmIssuerEndpoints => service.CrossRealmIssuerEndpoints;

    public ChannelFactory<IDiscoveryService> CreateChannelFactory() => service.CreateChannelFactory(ClientAuthenticationType.Kerberos);

    public ChannelFactory<IDiscoveryService> CreateChannelFactory(
      ClientAuthenticationType clientAuthenticationType)
    {
      return service.CreateChannelFactory(clientAuthenticationType);
    }

    public ChannelFactory<IDiscoveryService> CreateChannelFactory(
      TokenServiceCredentialType endpointType)
    {
      return service.CreateChannelFactory(endpointType);
    }

    public ChannelFactory<IDiscoveryService> CreateChannelFactory(
      ClientCredentials clientCredentials)
    {
      return service.CreateChannelFactory(clientCredentials);
    }

    public SecurityTokenResponse Authenticate(ClientCredentials clientCredentials) => service.Authenticate(clientCredentials);

    public SecurityTokenResponse Authenticate(SecurityToken securityToken) => service.Authenticate(securityToken);

    public SecurityTokenResponse AuthenticateCrossRealm(
      ClientCredentials clientCredentials,
      string appliesTo,
      Uri crossRealmSts)
    {
      return service.AuthenticateCrossRealm(clientCredentials, appliesTo, crossRealmSts);
    }

    public SecurityTokenResponse AuthenticateCrossRealm(
      SecurityToken securityToken,
      string appliesTo,
      Uri crossRealmSts)
    {
      return service.AuthenticateCrossRealm(securityToken, appliesTo, crossRealmSts);
    }

    public SecurityTokenResponse Authenticate(
      ClientCredentials clientCredentials,
      SecurityTokenResponse deviceSecurityTokenResponse)
    {
      throw new InvalidOperationException("Authentication to MSA services is not supported.");
    }

    public SecurityTokenResponse AuthenticateDevice(ClientCredentials clientCredentials) => throw new InvalidOperationException("Authentication to MSA services is not supported.");

    public PolicyConfiguration PolicyConfiguration => service.PolicyConfiguration;

    public IdentityProvider GetIdentityProvider(string userPrincipalName) => service.GetIdentityProvider(userPrincipalName);

    public SecurityTokenResponse Authenticate(
      ClientCredentials clientCredentials,
      Uri uri,
      string keyType)
    {
      return service.Authenticate(clientCredentials, uri, keyType);
    }

    public SecurityTokenResponse Authenticate(SecurityToken securityToken, Uri uri, string keyType) => service.Authenticate(securityToken, uri, keyType);

    public AuthenticationCredentials Authenticate(
      AuthenticationCredentials authenticationCredentials)
    {
      return service.Authenticate(authenticationCredentials);
    }

    public bool EndpointAutoSwitchEnabled
    {
      get => service.EndpointAutoSwitchEnabled;
      set => service.EndpointAutoSwitchEnabled = value;
    }

    public Uri AlternateEndpoint => service.AlternateEndpoint;

    public Uri PrimaryEndpoint => service.PrimaryEndpoint;

    public void SwitchEndpoint() => service.SwitchEndpoint();

    public bool HandleEndpointSwitch() => service.HandleEndpointSwitch();

    public event EventHandler<EndpointSwitchEventArgs> EndpointSwitched
    {
      add => service.EndpointSwitched += value;
      remove => service.EndpointSwitched -= value;
    }

    public event EventHandler<EndpointSwitchEventArgs> EndpointSwitchRequired
    {
      add => service.EndpointSwitchRequired += value;
      remove => service.EndpointSwitchRequired -= value;
    }

    public bool IsPrimaryEndpoint => service.IsPrimaryEndpoint;

    public bool CanSwitch(Uri currentUri) => service.CanSwitch(currentUri);
  }
}
*/
