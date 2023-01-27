// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.OrganizationServiceConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Common;
using System;
using System.IdentityModel.Tokens;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace Microsoft.Xrm.Sdk.Client
{
  internal sealed class OrganizationServiceConfiguration : 
    IServiceConfiguration<IOrganizationService>,
    IWebAuthentication<IOrganizationService>,
    IServiceManagement<IOrganizationService>,
    IEndpointSwitch
  {
    private const string XrmServicesRoot = "xrmservices/";
    private ServiceConfiguration<IOrganizationService> service;
    private object _lockObject = new();

    private OrganizationServiceConfiguration()
    {
    }

    internal OrganizationServiceConfiguration(Uri serviceUri)
      : this(serviceUri, false, null)
    {
    }

    internal OrganizationServiceConfiguration(
      Uri serviceUri,
      bool enableProxyTypes,
      Assembly assembly)
    {
      try
      {
        service = new ServiceConfiguration<IOrganizationService>(serviceUri, false);
        if (enableProxyTypes && assembly != null)
        {
          EnableProxyTypes(assembly);
        }
        else
        {
          if (!enableProxyTypes)
            return;
          EnableProxyTypes();
        }
      }
      catch (InvalidOperationException ex)
      {
        var flag = true;
        if (ex.InnerException is WebException innerException && innerException.Response is HttpWebResponse response && response.StatusCode == HttpStatusCode.Unauthorized)
          flag = !AdjustServiceEndpoint(serviceUri);
        if (!flag)
          return;
        throw;
      }
    }

    /// <summary>
    /// This method will enable support for the default strong proxy types.
    /// 
    /// If you are using a shared Service Configuration instance, you must be careful if using
    /// </summary>
    public void EnableProxyTypes()
    {
      ClientExceptionHelper.ThrowIfNull(CurrentServiceEndpoint, "CurrentServiceEndpoint");
      lock (_lockObject)
      {
        var behavior = CurrentServiceEndpoint.FindBehavior<ProxyTypesBehavior>();
        if (behavior != null)
          CurrentServiceEndpoint.RemoveBehavior(behavior);
        CurrentServiceEndpoint.AddBehavior(new ProxyTypesBehavior());
      }
    }

    /// <summary>
    /// This method will enable support for the strong proxy types exposed in the passed assembly.
    /// <param name="assembly">The assembly that will provide support for the desired strong types in the proxy.</param>
    /// </summary>
    public void EnableProxyTypes(Assembly assembly)
    {
      ClientExceptionHelper.ThrowIfNull(assembly, nameof (assembly));
      ClientExceptionHelper.ThrowIfNull(CurrentServiceEndpoint, "CurrentServiceEndpoint");
      lock (_lockObject)
      {
        var behavior = CurrentServiceEndpoint.FindBehavior<ProxyTypesBehavior>();
        if (behavior != null)
          CurrentServiceEndpoint.RemoveBehavior(behavior);
        CurrentServiceEndpoint.AddBehavior(new ProxyTypesBehavior(assembly));
      }
    }

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

    public ChannelFactory<IOrganizationService> CreateChannelFactory() => service.CreateChannelFactory(ClientAuthenticationType.Kerberos);

    public ChannelFactory<IOrganizationService> CreateChannelFactory(
      ClientAuthenticationType clientAuthenticationType)
    {
      return service.CreateChannelFactory(clientAuthenticationType);
    }

    public ChannelFactory<IOrganizationService> CreateChannelFactory(
      TokenServiceCredentialType endpointType)
    {
      return service.CreateChannelFactory(endpointType);
    }

    public ChannelFactory<IOrganizationService> CreateChannelFactory(
      ClientCredentials clientCredentials)
    {
      return service.CreateChannelFactory(clientCredentials);
    }

    public SecurityTokenResponse Authenticate(ClientCredentials clientCredentials) => service.Authenticate(clientCredentials);

    public SecurityTokenResponse Authenticate(SecurityToken securityToken) => service.Authenticate(securityToken);

    public SecurityTokenResponse Authenticate(
      ClientCredentials clientCredentials,
      SecurityTokenResponse deviceSecurityTokenResponse)
    {
      throw new InvalidOperationException("Authentication to MSA services is not supported.");
    }

    public SecurityTokenResponse AuthenticateDevice(ClientCredentials clientCredentials) => throw new InvalidOperationException("Authentication to MSA services is not supported.");

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

    private bool AdjustServiceEndpoint(Uri serviceUri)
    {
      var serviceUri1 = RemoveOrgName(serviceUri);
      if (serviceUri1 != null)
      {
        service = new ServiceConfiguration<IOrganizationService>(serviceUri1);
        if (service != null && service.ServiceEndpoints != null)
        {
          foreach (var serviceEndpoint in service.ServiceEndpoints)
            ServiceMetadataUtility.ReplaceEndpointAddress(serviceEndpoint.Value, serviceUri);
          return true;
        }
      }
      return false;
    }

    private static Uri RemoveOrgName(Uri serviceUri)
    {
      if (!serviceUri.AbsolutePath.StartsWith("/xrmservices/", StringComparison.OrdinalIgnoreCase))
      {
        var stringBuilder = new StringBuilder();
        for (var index = 2; index < serviceUri.Segments.Length; ++index)
          stringBuilder.Append(serviceUri.Segments[index]);
        if (stringBuilder.Length > 0)
        {
          serviceUri = new UriBuilder(serviceUri.GetComponents(UriComponents.SchemeAndServer, UriFormat.UriEscaped))
          {
            Path = stringBuilder.ToString()
          }.Uri;
          return serviceUri;
        }
      }
      return null;
    }

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

    public bool HandleEndpointSwitch() => service.HandleEndpointSwitch();

    public bool IsPrimaryEndpoint => service.IsPrimaryEndpoint;

    public bool CanSwitch(Uri currentUri) => service.CanSwitch(currentUri);
  }
}
