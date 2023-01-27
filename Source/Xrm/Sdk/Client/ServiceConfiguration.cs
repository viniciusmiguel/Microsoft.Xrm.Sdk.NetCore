// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceConfiguration`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Text;

namespace Microsoft.Xrm.Sdk.Client
{
  [SecuritySafeCritical]
  [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
  internal sealed class ServiceConfiguration<TService> : IEndpointSwitch
  {
    private ServiceEndpoint currentServiceEndpoint;
    private TokenServiceCredentialType _tokenEndpointType = TokenServiceCredentialType.AsymmetricToken;
    private static object _lockObject = new();
    internal const string DefaultRequestType = "http://schemas.microsoft.com/idfx/requesttype/issue";

    public AuthenticationCredentials Authenticate(
      AuthenticationCredentials authenticationCredentials)
    {
      ClientExceptionHelper.ThrowIfNull(authenticationCredentials, nameof (authenticationCredentials));
      switch (AuthenticationType)
      {
        case AuthenticationProviderType.ActiveDirectory:
          ServiceMetadataUtility.AdjustUserNameForWindows(authenticationCredentials.ClientCredentials);
          return authenticationCredentials;
        case AuthenticationProviderType.Federation:
          return AuthenticateFederationInternal(authenticationCredentials);
        case AuthenticationProviderType.OnlineFederation:
          return AuthenticateOnlineFederationInternal(authenticationCredentials);
        default:
          return authenticationCredentials;
      }
    }

    private AuthenticationCredentials AuthenticateFederationInternal(
      AuthenticationCredentials authenticationCredentials)
    {
      if (authenticationCredentials.SecurityTokenResponse != null)
        return AuthenticateFederationTokenInternal(authenticationCredentials);
      if (authenticationCredentials.AppliesTo == null)
        authenticationCredentials.AppliesTo = CurrentServiceEndpoint.Address.Uri;
      authenticationCredentials.EndpointType = GetCredentialsEndpointType(authenticationCredentials.ClientCredentials);
      authenticationCredentials.IssuerEndpoints = authenticationCredentials.HomeRealm != null ? CrossRealmIssuerEndpoints[authenticationCredentials.HomeRealm] : IssuerEndpoints;
      authenticationCredentials.SecurityTokenResponse = AuthenticateInternal(authenticationCredentials);
      return authenticationCredentials;
    }

    private AuthenticationCredentials AuthenticateFederationTokenInternal(
      AuthenticationCredentials authenticationCredentials)
    {
      var authenticationCredentials1 = new AuthenticationCredentials();
      authenticationCredentials1.SupportingCredentials = authenticationCredentials;
      if (authenticationCredentials.AppliesTo == null)
        authenticationCredentials.AppliesTo = CurrentServiceEndpoint.Address.Uri;
      authenticationCredentials.EndpointType = _tokenEndpointType;
      authenticationCredentials.KeyType = string.Empty;
      authenticationCredentials.IssuerEndpoints = IssuerEndpoints;
      authenticationCredentials1.SecurityTokenResponse = AuthenticateInternal(authenticationCredentials);
      return authenticationCredentials1;
    }

    /// <summary>
    /// Supported matrix:
    /// 1.  Security Token Response populated: We will submit the token to Org ID to exchange for a CRM token.
    /// 2.  Credentials passed.
    /// 		a.  The UserPrincipalName MUST be populated if the Username/Windows username is empty AND the Home Realm Uri is null.
    /// 		a.  If the Home Realm
    /// </summary>
    /// <param name="authenticationCredentials"></param>
    /// <returns></returns>
    private AuthenticationCredentials AuthenticateOnlineFederationInternal(
      AuthenticationCredentials authenticationCredentials)
    {
      var policyConfiguration = PolicyConfiguration as OnlinePolicyConfiguration;
      ClientExceptionHelper.ThrowIfNull(policyConfiguration, "onlinePolicy");
      var trustConfiguration = policyConfiguration.OnlineProviders.Values.OfType<OrgIdentityProviderTrustConfiguration>().FirstOrDefault<OrgIdentityProviderTrustConfiguration>();
      ClientExceptionHelper.ThrowIfNull(trustConfiguration, "liveTrustConfig");
      if (authenticationCredentials.SecurityTokenResponse != null)
        return AuthenticateOnlineFederationTokenInternal(trustConfiguration, authenticationCredentials);
      var flag = true;
      if (authenticationCredentials.HomeRealm == null)
      {
        var parameter = !string.IsNullOrEmpty(authenticationCredentials.UserPrincipalName) ? GetIdentityProvider(authenticationCredentials.UserPrincipalName) : GetIdentityProvider(authenticationCredentials.ClientCredentials);
        ClientExceptionHelper.ThrowIfNull(parameter, "identityProvider");
        authenticationCredentials.HomeRealm = parameter.ServiceUrl;
        flag = parameter.IdentityProviderType == IdentityProviderType.OrgId;
        if (flag)
          ClientExceptionHelper.Assert((policyConfiguration.OnlineProviders.ContainsKey(authenticationCredentials.HomeRealm) ? 1 : 0) != 0, "Online Identity Provider NOT found!  {0}", parameter.ServiceUrl);
      }
      authenticationCredentials.AppliesTo = new Uri(trustConfiguration.AppliesTo);
      authenticationCredentials.IssuerEndpoints = IssuerEndpoints;
      authenticationCredentials.KeyType = "http://schemas.microsoft.com/idfx/keytype/bearer";
      authenticationCredentials.EndpointType = TokenServiceCredentialType.Username;
      return flag ? AuthenticateTokenWithOrgIdForCrm(authenticationCredentials) : AuthenticateFederatedTokenWithOrgIdForCRM(AuthenticateWithADFSForOrgId(authenticationCredentials, trustConfiguration.Identifier));
    }

    /// <summary>
    /// Authenticates a federated token with OrgID to retrieve a token for CRM
    /// </summary>
    /// <param name="authenticationCredentials"></param>
    private AuthenticationCredentials AuthenticateFederatedTokenWithOrgIdForCRM(
      AuthenticationCredentials authenticationCredentials)
    {
      ClientExceptionHelper.ThrowIfNull(authenticationCredentials, nameof (authenticationCredentials));
      ClientExceptionHelper.ThrowIfNull(authenticationCredentials.SecurityTokenResponse, "authenticationCredentials.SecurityTokenResponse");
      var authenticationCredentials1 = new AuthenticationCredentials()
      {
        SupportingCredentials = authenticationCredentials,
        AppliesTo = authenticationCredentials.AppliesTo,
        IssuerEndpoints = authenticationCredentials.IssuerEndpoints,
        EndpointType = TokenServiceCredentialType.SymmetricToken
      };
      authenticationCredentials1.SecurityTokenResponse = AuthenticateInternal(authenticationCredentials1);
      return authenticationCredentials1;
    }

    /// <summary>
    /// Authenticates with ADFS to retrieve a federated token to exchange with OrgId for CRM
    /// </summary>
    /// <param name="authenticationCredentials"></param>
    /// <param name="identifier"></param>
    private AuthenticationCredentials AuthenticateWithADFSForOrgId(
      AuthenticationCredentials authenticationCredentials,
      Uri identifier)
    {
      var authenticationCredentials1 = new AuthenticationCredentials()
      {
        AppliesTo = authenticationCredentials.AppliesTo,
        SupportingCredentials = authenticationCredentials
      };
      authenticationCredentials1.AppliesTo = authenticationCredentials.AppliesTo;
      authenticationCredentials1.IssuerEndpoints = authenticationCredentials.IssuerEndpoints;
      authenticationCredentials1.EndpointType = TokenServiceCredentialType.SymmetricToken;
      authenticationCredentials.AppliesTo = identifier;
      authenticationCredentials.KeyType = "http://schemas.microsoft.com/idfx/keytype/bearer";
      authenticationCredentials.EndpointType = GetCredentialsEndpointType(authenticationCredentials.ClientCredentials);
      authenticationCredentials.IssuerEndpoints = CrossRealmIssuerEndpoints[authenticationCredentials.HomeRealm];
      authenticationCredentials1.SecurityTokenResponse = AuthenticateInternal(authenticationCredentials);
      return authenticationCredentials1;
    }

    private AuthenticationCredentials AuthenticateTokenWithOrgIdForCrm(
      AuthenticationCredentials authenticationCredentials)
    {
      ClientExceptionHelper.ThrowIfNull(authenticationCredentials, nameof (authenticationCredentials));
      return new AuthenticationCredentials()
      {
        SupportingCredentials = authenticationCredentials,
        AppliesTo = authenticationCredentials.AppliesTo,
        IssuerEndpoints = authenticationCredentials.IssuerEndpoints,
        KeyType = "http://schemas.microsoft.com/idfx/keytype/bearer",
        EndpointType = TokenServiceCredentialType.Username,
        SecurityTokenResponse = AuthenticateInternal(authenticationCredentials)
      };
    }

    private AuthenticationCredentials AuthenticateOnlineFederationTokenInternal(
      IdentityProviderTrustConfiguration liveTrustConfig,
      AuthenticationCredentials authenticationCredentials)
    {
      var authenticationCredentials1 = new AuthenticationCredentials();
      authenticationCredentials1.SupportingCredentials = authenticationCredentials;
      var appliesTo = authenticationCredentials.AppliesTo != null ? authenticationCredentials.AppliesTo.AbsoluteUri : liveTrustConfig.AppliesTo;
      var uri = authenticationCredentials.HomeRealm;
      if ((object) uri == null)
        uri = liveTrustConfig.Endpoint.GetServiceRoot();
      var crossRealmSts = uri;
      authenticationCredentials1.SecurityTokenResponse = AuthenticateCrossRealm(authenticationCredentials.SecurityTokenResponse.Token, appliesTo, crossRealmSts);
      return authenticationCredentials1;
    }

    internal IdentityProvider GetIdentityProvider(ClientCredentials clientCredentials)
    {
      var userPrincipalName = string.Empty;
      if (!string.IsNullOrWhiteSpace(clientCredentials.UserName.UserName))
        userPrincipalName = ExtractUserName(clientCredentials.UserName.UserName);
      else if (!string.IsNullOrWhiteSpace(clientCredentials.Windows.ClientCredential.UserName))
        userPrincipalName = ExtractUserName(clientCredentials.Windows.ClientCredential.UserName);
      ClientExceptionHelper.Assert(!string.IsNullOrEmpty(userPrincipalName), "clientCredentials.UserName.UserName or clientCredentials.Windows.ClientCredential.UserName MUST be populated!");
      return GetIdentityProvider(userPrincipalName);
    }

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    private string ExtractUserName(string userName) => !userName.Contains<char>('@') ? string.Empty : userName;

    public bool EndpointAutoSwitchEnabled { get; set; }

    public string GetAlternateEndpointAddress(string host)
    {
      var startIndex = host.IndexOf('.');
      return host.Insert(startIndex, "." + AlternateEndpointToken);
    }

    public void OnEndpointSwitchRequiredEvent() => HandleEndpointEvent(EndpointSwitchRequired, CurrentServiceEndpoint.Address.Uri == PrimaryEndpoint ? AlternateEndpoint : PrimaryEndpoint, CurrentServiceEndpoint.Address.Uri);

    public void OnEndpointSwitchedEvent() => HandleEndpointEvent(EndpointSwitched, CurrentServiceEndpoint.Address.Uri, CurrentServiceEndpoint.Address.Uri == PrimaryEndpoint ? AlternateEndpoint : PrimaryEndpoint);

    private void HandleEndpointEvent(
      EventHandler<EndpointSwitchEventArgs> tmp,
      Uri newUrl,
      Uri previousUrl)
    {
      if (tmp == null)
        return;
      var e = new EndpointSwitchEventArgs();
      lock (_lockObject)
      {
        e.NewUrl = newUrl;
        e.PreviousUrl = previousUrl;
      }
      tmp(this, e);
    }

    public event EventHandler<EndpointSwitchEventArgs> EndpointSwitched;

    public event EventHandler<EndpointSwitchEventArgs> EndpointSwitchRequired;

    public string AlternateEndpointToken { get; set; }

    public Uri AlternateEndpoint { get; internal set; }

    public Uri PrimaryEndpoint { get; internal set; }

    private void SetEndpointSwitchingBehavior()
    {
      if (ServiceEndpointMetadata.ServiceUrls == null)
        return;
      PrimaryEndpoint = ServiceEndpointMetadata.ServiceUrls.PrimaryEndpoint;
      var flag1 = false;
      var flag2 = true;
      if (!ServiceEndpointMetadata.ServiceUrls.GeneratedFromAlternate)
      {
        var failoverPolicy = CurrentServiceEndpoint.Binding.CreateBindingElements().Find<FailoverPolicy>();
        if (failoverPolicy != null && failoverPolicy.PolicyElements.ContainsKey("FailoverAvailable"))
        {
          flag1 = Convert.ToBoolean(failoverPolicy.PolicyElements["FailoverAvailable"], CultureInfo.InvariantCulture);
          flag2 = Convert.ToBoolean(failoverPolicy.PolicyElements["EndpointEnabled"], CultureInfo.InvariantCulture);
        }
      }
      else
        flag1 = true;
      if (!flag1)
        return;
      AlternateEndpoint = ServiceEndpointMetadata.ServiceUrls.AlternateEndpoint;
      if (flag2)
        return;
      SwitchEndpoint();
    }

    public bool IsPrimaryEndpoint
    {
      get
      {
        lock (_lockObject)
          return AlternateEndpoint == null || CurrentServiceEndpoint.Address.Uri != AlternateEndpoint;
      }
    }

    public bool CanSwitch(Uri currentUri)
    {
      ClientExceptionHelper.ThrowIfNull(currentUri, nameof (currentUri));
      lock (_lockObject)
        return currentUri == CurrentServiceEndpoint.Address.Uri;
    }

    public bool HandleEndpointSwitch()
    {
      if (AlternateEndpoint != null)
      {
        OnEndpointSwitchRequiredEvent();
        if (EndpointAutoSwitchEnabled)
        {
          SwitchEndpoint();
          return true;
        }
      }
      return false;
    }

    public void SwitchEndpoint()
    {
      if (AlternateEndpoint == null)
        return;
      lock (_lockObject)
      {
        CurrentServiceEndpoint.Address = !(CurrentServiceEndpoint.Address.Uri != AlternateEndpoint) ? new EndpointAddress(PrimaryEndpoint, CurrentServiceEndpoint.Address.Identity, CurrentServiceEndpoint.Address.Headers) : new EndpointAddress(AlternateEndpoint, CurrentServiceEndpoint.Address.Identity, CurrentServiceEndpoint.Address.Headers);
        OnEndpointSwitchedEvent();
      }
    }

    internal static unsafe ServiceUrls CalculateEndpoints(Uri serviceUri)
    {
      var urls = new ServiceUrls();
      var builder = new UriBuilder(serviceUri);
      
      var strArray = builder.Host.Split('.');
      
      if (strArray[0].EndsWith("--s", StringComparison.OrdinalIgnoreCase))
      {
        urls.AlternateEndpoint = builder.Uri;
        strArray[0] = strArray[0].Remove(strArray[0].Length - 3);
        builder.Host = string.Join(".", strArray);
        urls.PrimaryEndpoint = builder.Uri;
        urls.GeneratedFromAlternate = true;
      }
      else
      {
        urls.PrimaryEndpoint = builder.Uri;
        //TODO: WTF??
        //string* textPtr1 = strArray;
        //textPtr1 = (string*) (((string) textPtr1) + "--s");
        builder.Host = string.Join(".", strArray);
        urls.AlternateEndpoint = builder.Uri;
      }
      return urls;
    }

    public PolicyConfiguration PolicyConfiguration { get; set; }

    public ServiceEndpointMetadata ServiceEndpointMetadata { get; private set; }

    private ServiceConfiguration()
    {
    }

    /// <summary>
    /// Returns true if the AuthenticationType == Federation or LiveFederation
    /// </summary>
    private bool ClaimsEnabledService => AuthenticationType == AuthenticationProviderType.Federation || AuthenticationType == AuthenticationProviderType.OnlineFederation;

    public ServiceConfiguration(Uri serviceUri)
      : this(serviceUri, false)
    {
    }

    internal ServiceConfiguration(Uri serviceUri, bool checkForSecondary)
    {
      ServiceUri = serviceUri;
      ServiceEndpointMetadata = ServiceMetadataUtility.RetrieveServiceEndpointMetadata(typeof (TService), ServiceUri, checkForSecondary);
      ClientExceptionHelper.ThrowIfNull(ServiceEndpointMetadata, nameof (ServiceEndpointMetadata));
      if (ServiceEndpointMetadata.ServiceEndpoints.Count == 0)
      {
        var stringBuilder = new StringBuilder();
        if (ServiceEndpointMetadata.MetadataConversionErrors.Count > 0)
        {
          foreach (var metadataConversionError in ServiceEndpointMetadata.MetadataConversionErrors)
            stringBuilder.Append(metadataConversionError.Message);
        }
        throw new InvalidOperationException(ClientExceptionHelper.FormatMessage(0, "The provided uri did not return any Service Endpoints!\n{0}", stringBuilder.ToString()));
      }
      ServiceEndpoints = ServiceEndpointMetadata.ServiceEndpoints;
      if (CurrentServiceEndpoint == null)
        return;
      CrossRealmIssuerEndpoints = new CrossRealmIssuerEndpointCollection();
      SetAuthenticationConfiguration();
      if (checkForSecondary)
      {
        SetEndpointSwitchingBehavior();
      }
      else
      {
        if (CurrentServiceEndpoint.Address.Uri != serviceUri)
          ServiceMetadataUtility.ReplaceEndpointAddress(CurrentServiceEndpoint, serviceUri);
        PrimaryEndpoint = serviceUri;
      }
    }

    /// <summary>
    /// If there is no binding, there is nothing to do.  Otherwise, import the XRM Policy elements and set the issuers if claims.
    /// </summary>
    private void SetAuthenticationConfiguration()
    {
      if (CurrentServiceEndpoint.Binding == null)
        return;
      var xrmPolicy = CurrentServiceEndpoint.Binding.CreateBindingElements().Find<AuthenticationPolicy>();
      if (xrmPolicy == null || !xrmPolicy.PolicyElements.ContainsKey("AuthenticationType"))
        return;
      var policyElement = xrmPolicy.PolicyElements["AuthenticationType"];
      AuthenticationProviderType result;
      if (string.IsNullOrEmpty(policyElement) || !Enum.TryParse<AuthenticationProviderType>(policyElement, out result))
        return;
      switch (result)
      {
        case AuthenticationProviderType.Federation:
          IssuerEndpoints = ServiceMetadataUtility.RetrieveIssuerEndpoints(AuthenticationProviderType.Federation, ServiceEndpoints, true);
          PolicyConfiguration = new ClaimsPolicyConfiguration(xrmPolicy);
          break;
        case AuthenticationProviderType.OnlineFederation:
          PolicyConfiguration = new OnlineFederationPolicyConfiguration(xrmPolicy);
          using (var enumerator = ((OnlinePolicyConfiguration) PolicyConfiguration).OnlineProviders.Values.GetEnumerator())
          {
            while (enumerator.MoveNext())
              IssuerEndpoints = ServiceMetadataUtility.RetrieveLiveIdIssuerEndpoints(enumerator.Current);
            break;
          }
        default:
          PolicyConfiguration = new WindowsPolicyConfiguration(xrmPolicy);
          break;
      }
    }

    public Uri ServiceUri { get; internal set; }

    /// <summary>
    /// This defaults to the first avaialble endpoint in the ServiceEndpoints dictionary if it has not been set.
    /// </summary>
    public ServiceEndpoint CurrentServiceEndpoint
    {
      get
      {
        if (currentServiceEndpoint == null)
        {
          foreach (var serviceEndpoint in ServiceEndpoints.Values)
          {
            if (ServiceUri.Port == serviceEndpoint.Address.Uri.Port && ServiceUri.Scheme == serviceEndpoint.Address.Uri.Scheme)
            {
              currentServiceEndpoint = serviceEndpoint;
              break;
            }
          }
        }
        return currentServiceEndpoint;
      }
      set => currentServiceEndpoint = value;
    }

    /// <summary>
    /// If there is a CurrentServiceEndpoint and the Service has been configured for claims (Federation,) then this
    /// is the endpoint used by the Secure Token Service (STS) to issue the trusted token.
    /// </summary>
    public IssuerEndpoint CurrentIssuer
    {
      get => CurrentServiceEndpoint != null ? ServiceMetadataUtility.GetIssuer(CurrentServiceEndpoint.Binding) : null;
      set
      {
        if (CurrentServiceEndpoint == null)
          return;
        CurrentServiceEndpoint.Binding = ServiceMetadataUtility.SetIssuer(CurrentServiceEndpoint.Binding, value);
      }
    }

    /// <summary>
    /// Identifies whether the constructed service is using Claims (Federation) authentication or legacy AD/RPS.
    /// </summary>
    public AuthenticationProviderType AuthenticationType
    {
      get
      {
        if (PolicyConfiguration is WindowsPolicyConfiguration)
          return AuthenticationProviderType.ActiveDirectory;
        if (PolicyConfiguration is ClaimsPolicyConfiguration)
          return AuthenticationProviderType.Federation;
        if (PolicyConfiguration is LiveIdPolicyConfiguration)
          return AuthenticationProviderType.LiveId;
        return PolicyConfiguration is OnlineFederationPolicyConfiguration ? AuthenticationProviderType.OnlineFederation : AuthenticationProviderType.None;
      }
    }

    /// <summary>
    /// Contains the list of urls and binding information required in order to make a call to a WCF service.  If the service is configured
    /// for On-Premise use only, then the endpoint(s) contained within will NOT require the use of an Issuer Endpoint on the binding.
    /// 
    /// If the service is configured to use Claims (Federation,) then the binding on the service endpoint MUST be configured to use
    /// the appropriate Issuer Endpoint, i.e., UserNamePassword, Kerberos, etc.
    /// </summary>
    public ServiceEndpointDictionary ServiceEndpoints { get; internal set; }

    /// <summary>
    /// The following property contains the urls and binding information required to use a configured Secure Token Service (STS)
    /// for issuing a trusted token that the service endpoint will trust for authentication.
    /// 
    /// The available endpoints can vary, depending on how the administrator of the STS has configured the server, but may include
    /// the following authentication methods:
    /// 
    /// 1.  UserName and Password
    /// 2.  Kerberos
    /// 3.  Certificate
    /// 4.  Asymmetric Token
    /// 5.  Symmetric Token
    /// </summary>
    public IssuerEndpointDictionary IssuerEndpoints { get; internal set; }

    /// <summary>
    /// Contains the STS IssuerEndpoints as determined dynamically by calls to AuthenticateCrossRealm.
    /// </summary>
    public CrossRealmIssuerEndpointCollection CrossRealmIssuerEndpoints { get; internal set; }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    public ChannelFactory<TService> CreateChannelFactory(TokenServiceCredentialType endpointType)
    {
      ClientExceptionHelper.ThrowIfNull(CurrentServiceEndpoint, "CurrentServiceEndpoint");
      if (ClaimsEnabledService)
      {
        var issuerEndpoint = IssuerEndpoints.GetIssuerEndpoint(endpointType);
        if (issuerEndpoint != null)
        {
          lock (_lockObject)
            CurrentServiceEndpoint.Binding = ServiceMetadataUtility.SetIssuer(CurrentServiceEndpoint.Binding, issuerEndpoint);
        }
      }
      var localChannelFactory = CreateLocalChannelFactory();
      localChannelFactory.Credentials.SetSupportInteractive(false);
      return localChannelFactory;
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    public ChannelFactory<TService> CreateChannelFactory(
      ClientAuthenticationType clientAuthenticationType)
    {
      ClientExceptionHelper.ThrowIfNull(CurrentServiceEndpoint, "CurrentServiceEndpoint");
      if (ClaimsEnabledService)
      {
        var issuerEndpoint = IssuerEndpoints.GetIssuerEndpoint(clientAuthenticationType != ClientAuthenticationType.SecurityToken ? TokenServiceCredentialType.Kerberos : (AuthenticationType == AuthenticationProviderType.OnlineFederation ? TokenServiceCredentialType.SymmetricToken : _tokenEndpointType));
        if (issuerEndpoint != null)
        {
          lock (_lockObject)
            CurrentServiceEndpoint.Binding = ServiceMetadataUtility.SetIssuer(CurrentServiceEndpoint.Binding, issuerEndpoint);
        }
      }
      var localChannelFactory = CreateLocalChannelFactory();
      localChannelFactory.Credentials.SetSupportInteractive(false);
      return localChannelFactory;
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    public ChannelFactory<TService> CreateChannelFactory(ClientCredentials clientCredentials)
    {
      ClientExceptionHelper.ThrowIfNull(CurrentServiceEndpoint, "CurrentServiceEndpoint");
      if (ClaimsEnabledService)
      {
        var issuerEndpoint = IssuerEndpoints.GetIssuerEndpoint(GetCredentialsEndpointType(clientCredentials));
        if (issuerEndpoint != null)
        {
          lock (_lockObject)
            CurrentServiceEndpoint.Binding = ServiceMetadataUtility.SetIssuer(CurrentServiceEndpoint.Binding, issuerEndpoint);
        }
      }
      var localChannelFactory = CreateLocalChannelFactory();
      ConfigureCredentials(localChannelFactory, clientCredentials);
      localChannelFactory.Credentials.SetSupportInteractive(clientCredentials != null && clientCredentials.GetSupportInteractive());
      return localChannelFactory;
    }

    /// <summary>
    /// Authenticates based on the client credentials passed in.
    /// </summary>
    /// <param name="clientCredentials">The standard ClientCredentials</param>
    /// <param name="appliesTo"></param>
    /// <param name="crossRealmSts"></param>
    /// <returns>RequestSecurityTokenResponse</returns>
    public SecurityTokenResponse AuthenticateCrossRealm(
      ClientCredentials clientCredentials,
      string appliesTo,
      Uri crossRealmSts)
    {
      if (!(crossRealmSts != null))
        return null;
      var authenticationCredentials = new AuthenticationCredentials();
      authenticationCredentials.AppliesTo = !string.IsNullOrWhiteSpace(appliesTo) ? new Uri(appliesTo) : null;
      authenticationCredentials.KeyType = string.Empty;
      authenticationCredentials.ClientCredentials = clientCredentials;
      authenticationCredentials.SecurityTokenResponse = null;
      var trustConfiguration = TryGetOnlineTrustConfiguration(crossRealmSts);
      authenticationCredentials.EndpointType = trustConfiguration != null ? TokenServiceCredentialType.Username : GetCredentialsEndpointType(clientCredentials);
      authenticationCredentials.IssuerEndpoints = CrossRealmIssuerEndpoints[crossRealmSts];
      if (AuthenticationType == AuthenticationProviderType.OnlineFederation && trustConfiguration == null)
        authenticationCredentials.KeyType = "http://schemas.microsoft.com/idfx/keytype/bearer";
      return AuthenticateInternal(authenticationCredentials);
    }

    /// <summary>Authenticates based on the security token passed in.</summary>
    /// <param name="securityToken"></param>
    /// <param name="appliesTo"></param>
    /// <param name="crossRealmSts"></param>
    /// <returns>RequestSecurityTokenResponse</returns>
    public SecurityTokenResponse AuthenticateCrossRealm(
      SecurityToken securityToken,
      string appliesTo,
      Uri crossRealmSts)
    {
      if (!(crossRealmSts != null))
        return null;
      var authenticationCredentials = new AuthenticationCredentials();
      authenticationCredentials.AppliesTo = !string.IsNullOrWhiteSpace(appliesTo) ? new Uri(appliesTo) : null;
      authenticationCredentials.KeyType = string.Empty;
      authenticationCredentials.ClientCredentials = null;
      authenticationCredentials.SecurityTokenResponse = new SecurityTokenResponse()
      {
        Token = securityToken
      };
      var flag = true;
      if (AuthenticationType == AuthenticationProviderType.OnlineFederation)
      {
        var trustConfiguration = TryGetOnlineTrustConfiguration(crossRealmSts);
        if (trustConfiguration != null && trustConfiguration.Endpoint.GetServiceRoot() == crossRealmSts)
        {
          authenticationCredentials.EndpointType = TokenServiceCredentialType.SymmetricToken;
          flag = false;
        }
      }
      if (flag)
        authenticationCredentials.EndpointType = _tokenEndpointType;
      authenticationCredentials.IssuerEndpoints = CrossRealmIssuerEndpoints[crossRealmSts];
      return AuthenticateInternal(authenticationCredentials);
    }

    private IdentityProviderTrustConfiguration TryGetOnlineTrustConfiguration() => !(PolicyConfiguration is OnlinePolicyConfiguration policyConfiguration) ? null : (IdentityProviderTrustConfiguration) policyConfiguration.OnlineProviders.Values.OfType<OrgIdentityProviderTrustConfiguration>().FirstOrDefault<OrgIdentityProviderTrustConfiguration>();

    private IdentityProviderTrustConfiguration GetLiveTrustConfig<T>() where T : IdentityProviderTrustConfiguration
    {
      var policyConfiguration = PolicyConfiguration as OnlinePolicyConfiguration;
      ClientExceptionHelper.ThrowIfNull(policyConfiguration, "liveConfiguration");
      // ISSUE: variable of a boxed type
      var parameter = (object) policyConfiguration.OnlineProviders.Values.OfType<T>().FirstOrDefault<T>();
      ClientExceptionHelper.ThrowIfNull(parameter, "liveTrustConfig");
      return (IdentityProviderTrustConfiguration) parameter;
    }

    private IdentityProviderTrustConfiguration GetOnlineTrustConfiguration(Uri crossRealmSts)
    {
      var policyConfiguration = PolicyConfiguration as OnlineFederationPolicyConfiguration;
      ClientExceptionHelper.ThrowIfNull(policyConfiguration, "liveFederationConfiguration");
      return policyConfiguration.OnlineProviders.ContainsKey(crossRealmSts) ? policyConfiguration.OnlineProviders[crossRealmSts] : null;
    }

    private IdentityProviderTrustConfiguration TryGetOnlineTrustConfiguration(Uri crossRealmSts) => PolicyConfiguration is OnlineFederationPolicyConfiguration policyConfiguration && policyConfiguration.OnlineProviders.ContainsKey(crossRealmSts) ? policyConfiguration.OnlineProviders[crossRealmSts] : null;

    /// <summary>
    /// Authenticates based on the client credentials passed in.
    /// </summary>
    /// <param name="clientCredentials">The standard ClientCredentials</param>
    /// <returns>RequestSecurityTokenResponse</returns>
    public SecurityTokenResponse Authenticate(ClientCredentials clientCredentials)
    {
      if (CurrentServiceEndpoint != null)
      {
        var authenticationCredentials = Authenticate(new AuthenticationCredentials()
        {
          ClientCredentials = clientCredentials
        });
        if (authenticationCredentials != null && authenticationCredentials.SecurityTokenResponse != null)
          return authenticationCredentials.SecurityTokenResponse;
      }
      return null;
    }

    /// <summary>
    /// Authenticates based on the client credentials passed in.
    /// </summary>
    /// <param name="clientCredentials"></param>
    /// <param name="uri"></param>
    /// <param name="keyType">Optional.  Can be set to Bearer if bearer token required</param>
    /// <returns>RequestSecurityTokenResponse</returns>
    internal SecurityTokenResponse Authenticate(
      ClientCredentials clientCredentials,
      Uri uri,
      string keyType)
    {
      return AuthenticateInternal(new AuthenticationCredentials()
      {
        AppliesTo = uri,
        EndpointType = GetCredentialsEndpointType(clientCredentials),
        KeyType = keyType,
        IssuerEndpoints = IssuerEndpoints,
        ClientCredentials = clientCredentials,
        SecurityTokenResponse = null
      });
    }

    /// <summary>Authenticates based on the security token passed in.</summary>
    /// <param name="securityToken"></param>
    /// <returns>RequestSecurityTokenResponse</returns>
    public SecurityTokenResponse Authenticate(SecurityToken securityToken)
    {
      ClientExceptionHelper.ThrowIfNull(securityToken, nameof (securityToken));
      if (AuthenticationType == AuthenticationProviderType.OnlineFederation)
      {
        var trustConfiguration = TryGetOnlineTrustConfiguration();
        return trustConfiguration == null ? null : AuthenticateCrossRealm(securityToken, trustConfiguration.AppliesTo, trustConfiguration.Endpoint.GetServiceRoot());
      }
      if (CurrentServiceEndpoint == null)
        return null;
      return AuthenticateInternal(new AuthenticationCredentials()
      {
        AppliesTo = CurrentServiceEndpoint.Address.Uri,
        EndpointType = _tokenEndpointType,
        KeyType = string.Empty,
        IssuerEndpoints = IssuerEndpoints,
        ClientCredentials = null,
        SecurityTokenResponse = new SecurityTokenResponse()
        {
          Token = securityToken
        }
      });
    }

    /// <summary>Authenticates based on the security token passed in.</summary>
    /// <param name="securityToken"></param>
    /// <param name="uri"></param>
    /// <param name="keyType">Optional.  Can be set to Bearer if bearer token required</param>
    /// <returns>RequestSecurityTokenResponse</returns>
    internal SecurityTokenResponse Authenticate(
      SecurityToken securityToken,
      Uri uri,
      string keyType)
    {
      ClientExceptionHelper.ThrowIfNull(securityToken, nameof (securityToken));
      if (!(uri != null))
        return null;
      return AuthenticateInternal(new AuthenticationCredentials()
      {
        AppliesTo = uri.GetServiceRoot(),
        EndpointType = _tokenEndpointType,
        KeyType = keyType,
        IssuerEndpoints = IssuerEndpoints,
        ClientCredentials = null,
        SecurityTokenResponse = new SecurityTokenResponse()
        {
          Token = securityToken
        }
      });
    }

    /// <summary>This will default to LiveID auth when on-line.</summary>
    /// <param name="clientCredentials"></param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    public SecurityTokenResponse AuthenticateDevice(ClientCredentials clientCredentials)
    {
      ClientExceptionHelper.ThrowIfNull(clientCredentials, nameof (clientCredentials));
      throw new InvalidOperationException("Authentication to MSA services is not supported.");
    }

    /// <summary>This will default to LiveID auth when on-line.</summary>
    /// <param name="clientCredentials"></param>
    /// <param name="deviceTokenResponse"></param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    public SecurityTokenResponse Authenticate(
      ClientCredentials clientCredentials,
      SecurityTokenResponse deviceTokenResponse)
    {
      ClientExceptionHelper.ThrowIfNull(clientCredentials, nameof (clientCredentials));
      ClientExceptionHelper.ThrowIfNull(deviceTokenResponse, nameof (deviceTokenResponse));
      throw new InvalidOperationException("Authentication to MSA services is not supported.");
    }

    /// <summary>This will default to LiveID auth when on-line.</summary>
    /// <param name="clientCredentials"></param>
    /// <param name="deviceTokenResponse"></param>
    /// <param name="keyType"></param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    public SecurityTokenResponse Authenticate(
      ClientCredentials clientCredentials,
      SecurityTokenResponse deviceTokenResponse,
      string keyType)
    {
      ClientExceptionHelper.ThrowIfNull(clientCredentials, nameof (clientCredentials));
      ClientExceptionHelper.ThrowIfNull(deviceTokenResponse, nameof (deviceTokenResponse));
      ClientExceptionHelper.ThrowIfNullOrEmpty(keyType, nameof (keyType));
      throw new InvalidOperationException("Authentication to MSA services is not supported.");
    }

    public IdentityProvider GetIdentityProvider(string userPrincipalName)
    {
      var trustConfiguration = TryGetOnlineTrustConfiguration();
      return trustConfiguration == null ? null : IdentityProviderLookup.Instance.GetIdentityProvider(trustConfiguration.Endpoint.GetServiceRoot(), trustConfiguration.Endpoint.GetServiceRoot(), userPrincipalName);
    }

    private SecurityTokenResponse AuthenticateInternal(
      AuthenticationCredentials authenticationCredentials)
    {
      ClientExceptionHelper.Assert(AuthenticationType == AuthenticationProviderType.Federation || AuthenticationType == AuthenticationProviderType.OnlineFederation, "Authenticate is not supported when not in claims mode!");
      if (ClaimsEnabledService)
      {
        if (authenticationCredentials.IssuerEndpoint.CredentialType != TokenServiceCredentialType.Kerberos)
          return Issue(authenticationCredentials);
        var flag = false;
        var num = 0;
        do
        {
          try
          {
            return Issue(authenticationCredentials);
          }
          catch (SecurityTokenValidationException)
          {
            flag = false;
            if (authenticationCredentials.IssuerEndpoints.ContainsKey(TokenServiceCredentialType.Windows.ToString()))
            {
              authenticationCredentials.EndpointType = TokenServiceCredentialType.Windows;
              flag = ++num < 2;
            }
          }
          catch (SecurityNegotiationException)
          {
            flag = ++num < 2;
          }
          catch (FaultException)
          {
            if (authenticationCredentials.IssuerEndpoints.ContainsKey(TokenServiceCredentialType.Windows.ToString()))
            {
              authenticationCredentials.EndpointType = TokenServiceCredentialType.Windows;
              flag = ++num < 2;
            }
          }
        }
        while (flag);
      }
      return null;
    }

    /// <summary>
    /// This is the method that actually creates the trust channel factory and issues the request for the token.
    /// </summary>
    /// <returns></returns>
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "[WSTrustChannelFactory] Pending resolution of bug: https://dev.azure.com/dynamicscrm/OneCRM/_workitems/edit/2493634")]
    private SecurityTokenResponse Issue(
      AuthenticationCredentials authenticationCredentials)
    {
      ClientExceptionHelper.ThrowIfNull(authenticationCredentials, nameof (authenticationCredentials));
      ClientExceptionHelper.ThrowIfNull(authenticationCredentials.IssuerEndpoint, "authenticationCredentials.IssuerEndpoint");
      ClientExceptionHelper.ThrowIfNull(authenticationCredentials.AppliesTo, "authenticationCredentials.AppliesTo");
      WSTrustChannelFactory communicationObject1 = null;
      WSTrustChannel communicationObject2 = null;
      try
      {
        authenticationCredentials.RequestType = "http://schemas.microsoft.com/idfx/requesttype/issue";
        communicationObject1 = new WSTrustChannelFactory(authenticationCredentials.IssuerEndpoint.IssuerBinding, authenticationCredentials.IssuerEndpoint.IssuerAddress);
        var issuedToken = authenticationCredentials.SecurityTokenResponse == null || authenticationCredentials.SecurityTokenResponse.Token == null ? (authenticationCredentials.SupportingCredentials == null || authenticationCredentials.SupportingCredentials.SecurityTokenResponse == null || authenticationCredentials.SupportingCredentials.SecurityTokenResponse.Token == null ? null : authenticationCredentials.SupportingCredentials.SecurityTokenResponse.Token) : authenticationCredentials.SecurityTokenResponse.Token;
        if (issuedToken != null)
          communicationObject1.Credentials.SupportInteractive = false;
        else
          ConfigureCredentials(communicationObject1, authenticationCredentials.ClientCredentials);
        communicationObject2 = issuedToken != null ? (WSTrustChannel) communicationObject1.CreateChannelWithIssuedToken(issuedToken) : (WSTrustChannel) communicationObject1.CreateChannel();
        if (communicationObject2 != null)
        {
          var requestSecurityToken = new RequestSecurityToken(authenticationCredentials.RequestType);
          requestSecurityToken.AppliesTo = new EndpointReference(authenticationCredentials.AppliesTo.AbsoluteUri);
          var rst = requestSecurityToken;
          if (!string.IsNullOrEmpty(authenticationCredentials.KeyType))
            rst.KeyType = authenticationCredentials.KeyType;
          RequestSecurityTokenResponse rstr;
          var securityToken = communicationObject2.Issue(rst, out rstr);
          return new SecurityTokenResponse()
          {
            Token = securityToken,
            Response = rstr,
            EndpointType = authenticationCredentials.EndpointType
          };
        }
      }
      finally
      {
        if (communicationObject2 != null)
          ChannelExtensions.Close(communicationObject2);
        if (communicationObject1 != null)
          ChannelExtensions.Close(communicationObject1);
      }
      return null;
    }

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    private void ConfigureCredentials(
      ChannelFactory channelFactory,
      ClientCredentials clientCredentials)
    {
      if (clientCredentials == null)
        return;
      if (clientCredentials.ClientCertificate != null && clientCredentials.ClientCertificate.Certificate != null)
        channelFactory.Credentials.ClientCertificate.Certificate = clientCredentials.ClientCertificate.Certificate;
      else if (clientCredentials.UserName != null && !string.IsNullOrEmpty(clientCredentials.UserName.UserName))
      {
        channelFactory.Credentials.UserName.UserName = clientCredentials.UserName.UserName;
        channelFactory.Credentials.UserName.Password = clientCredentials.UserName.Password;
      }
      else
      {
        if (clientCredentials.Windows == null || clientCredentials.Windows.ClientCredential == null)
          return;
        channelFactory.Credentials.Windows.ClientCredential = clientCredentials.Windows.ClientCredential;
        channelFactory.Credentials.Windows.AllowedImpersonationLevel = clientCredentials.Windows.AllowedImpersonationLevel;
      }
    }

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    private TokenServiceCredentialType GetCredentialsEndpointType(
      ClientCredentials clientCredentials)
    {
      if (clientCredentials != null)
      {
        if (clientCredentials.UserName != null && !string.IsNullOrEmpty(clientCredentials.UserName.UserName))
          return TokenServiceCredentialType.Username;
        if (clientCredentials.ClientCertificate != null && clientCredentials.ClientCertificate.Certificate != null)
          return TokenServiceCredentialType.Certificate;
        if (clientCredentials.Windows != null)
        {
          var clientCredential = clientCredentials.Windows.ClientCredential;
          return TokenServiceCredentialType.Kerberos;
        }
      }
      return TokenServiceCredentialType.Kerberos;
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    private ChannelFactory<TService> CreateLocalChannelFactory()
    {
      lock (_lockObject)
      {
        var endpoint = new ServiceEndpoint(CurrentServiceEndpoint.Contract, CurrentServiceEndpoint.Binding, CurrentServiceEndpoint.Address);
        foreach (var behavior in CurrentServiceEndpoint.Behaviors)
          endpoint.Behaviors.Add(behavior);
        endpoint.IsSystemEndpoint = CurrentServiceEndpoint.IsSystemEndpoint;
        endpoint.ListenUri = CurrentServiceEndpoint.ListenUri;
        endpoint.ListenUriMode = CurrentServiceEndpoint.ListenUriMode;
        endpoint.Name = CurrentServiceEndpoint.Name;
        var localChannelFactory = new ChannelFactory<TService>(endpoint);
        localChannelFactory.Credentials.IssuedToken.CacheIssuedTokens = true;
        return localChannelFactory;
      }
    }
  }
}
