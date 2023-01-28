// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceProxy`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace Microsoft.Xrm.Sdk.Client
{
  public abstract class ServiceProxy<TService> : IDisposable where TService : class
  {
    private ServiceChannel<TService> _serviceChannel;
    private ChannelFactory<TService> _channelFactory;
    private TimeSpan _timeout = ServiceDefaults.DefaultTimeout;
    private bool _autoCloseChannel;

    internal ServiceProxy()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Client.ServiceProxy`1" /> class.
    /// 	This constructor is used when the service management interface and security token have been acquired externally.
    /// 
    /// 	This version can not be used for non-claims authentication.
    /// 
    /// 	Also, with this constructor, the Authenticate call should not be attempted.
    /// </summary>
    /// <param name="serviceManagement"></param>
    /// <param name="securityTokenResponse"></param>
    protected ServiceProxy(
      IServiceManagement<TService> serviceManagement,
      SecurityTokenResponse securityTokenResponse)
      : this(serviceManagement as IServiceConfiguration<TService>, securityTokenResponse)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Client.ServiceProxy`1" /> class.
    /// 	This constructor is used when the service configuration and security token have been acquired externally.
    /// 
    /// 	This version can not be used for non-claims authentication.
    /// 
    /// 	Also, with this constructor, the Authenticate call should not be attempted.
    /// </summary>
    /// <param name="serviceConfiguration"></param>
    /// <param name="securityTokenResponse"></param>
    protected ServiceProxy(
      IServiceConfiguration<TService> serviceConfiguration,
      SecurityTokenResponse securityTokenResponse)
    {
      ClientExceptionHelper.ThrowIfNull(serviceConfiguration, nameof (serviceConfiguration));
      ClientExceptionHelper.ThrowIfNull(serviceConfiguration.CurrentServiceEndpoint, "serviceConfiguration.CurrentServiceEndpoint");
      ClientExceptionHelper.ThrowIfNull(securityTokenResponse, nameof (securityTokenResponse));
      ClientExceptionHelper.ThrowIfNull(securityTokenResponse.Token, "securityTokenResponse.Token");
      ServiceConfiguration = serviceConfiguration;
      SecurityTokenResponse = securityTokenResponse;
      IsAuthenticated = true;
      SetDefaultEndpointSwitchBehavior();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Client.ServiceProxy`1" /> class.
    /// 	This constructor is used when the service configuration has been acquired externally, and Windows-based auth is known to be used already.
    /// 
    /// 	Also, with this constructor, the Authenticate call should not be attempted.
    /// </summary>
    /// <param name="serviceManagement"></param>
    /// <param name="clientCredentials"></param>
    protected ServiceProxy(
      IServiceManagement<TService> serviceManagement,
      ClientCredentials clientCredentials)
      : this(serviceManagement as IServiceConfiguration<TService>, clientCredentials)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Client.ServiceProxy`1" /> class.
    /// 	This constructor is used when the service configuration has been acquired externally, and Windows-based auth is known to be used already.
    /// 
    /// 	Also, with this constructor, the Authenticate call should not be attempted.
    /// </summary>
    /// <param name="serviceConfiguration"></param>
    /// <param name="clientCredentials"></param>
    protected ServiceProxy(
      IServiceConfiguration<TService> serviceConfiguration,
      ClientCredentials clientCredentials)
    {
      ClientExceptionHelper.ThrowIfNull(serviceConfiguration, nameof (serviceConfiguration));
      ClientExceptionHelper.ThrowIfNull(serviceConfiguration.CurrentServiceEndpoint, "serviceConfiguration.CurrentServiceEndpoint");
      ServiceConfiguration = serviceConfiguration;
      SetClientCredentials(clientCredentials);
      IsAuthenticated = true;
      SetDefaultEndpointSwitchBehavior();
    }

    protected ServiceProxy(
      Uri uri,
      Uri homeRealmUri,
      ClientCredentials clientCredentials,
      ClientCredentials deviceCredentials)
    {
      ClientExceptionHelper.ThrowIfNull(uri, nameof (uri));
      IsAuthenticated = false;
      ServiceConfiguration = ServiceConfigurationFactory.CreateConfiguration<TService>(uri);
      SetClientCredentials(clientCredentials);
      HomeRealmUri = homeRealmUri;
      DeviceCredentials = deviceCredentials;
      SetDefaultEndpointSwitchBehavior();
    }

    /// <summary>
    /// 	Calling Authenticate will cause the following things to happen:
    /// 	1.  If the ServiceChannel has already been opened, it will be closed and set to null.
    /// 	2.  The ChannelFactory will be closed and set to null.
    /// 	3.  AuthenticateCore will be called.
    /// </summary>
    public void Authenticate()
    {
      if (_serviceChannel != null)
      {
        _serviceChannel.Close();
        _serviceChannel.Dispose();
        _serviceChannel = null;
      }
      if (_channelFactory != null)
      {
        RemoveChannelFactoryEvents();
        ChannelExtensions.Close(_channelFactory);
        _channelFactory = null;
      }
      AuthenticateCore();
    }

    public SecurityTokenResponse AuthenticateCrossRealm() => AuthenticateCrossRealmCore();

    public SecurityTokenResponse AuthenticateDevice() => AuthenticateDeviceCore();

    public IServiceConfiguration<TService> ServiceConfiguration { get; private set; }

    public IServiceManagement<TService> ServiceManagement => ServiceConfiguration as IServiceManagement<TService>;

    public IEndpointSwitch EndpointSwitch => ServiceConfiguration as IEndpointSwitch;

    public ClientCredentials ClientCredentials { get; private set; }

    public string UserPrincipalName { get; set; }

    public SecurityTokenResponse SecurityTokenResponse { get; protected set; }

    public SecurityTokenResponse HomeRealmSecurityTokenResponse { get; protected set; }

    public Uri HomeRealmUri { get; private set; }

    public ClientCredentials DeviceCredentials { get; private set; }

    public ServiceChannel<TService> ServiceChannel
    {
      get
      {
        ValidateAuthentication();
        return _serviceChannel;
      }
    }

    public TimeSpan Timeout
    {
      get => _timeout;
      set
      {
        _timeout = value;
        RefreshChannelManagers();
      }
    }

    /// <summary>
    /// 	Determines whether the Authenticate call will be made during the ValidateChannel call.
    /// </summary>
    public bool IsAuthenticated { get; private set; }

    /// <summary>
    /// Determines if the proxy object should close the channel automatically on successful
    /// completion of requests. This is set to false when the same proxy object is being
    /// shared between multiple threads.
    /// </summary>
    internal bool AutoCloseChannel
    {
      get => _autoCloseChannel;
      set => _autoCloseChannel = value;
    }

    internal string AppliesTo { get; set; }

    /// <summary>
    /// 	Provided to authenticate a user in a realm other than the realm that CRM Server is located.  This call will attempt to authenticate
    /// 	in the home realm, then use the corresponding token to authenticate to the CRM Server realm STS.  In addition to the normal client credential
    /// 	requirements, the HomeRealmUri is expected to be set in the call to the constructor.
    /// 
    /// 	The resulting SecurityTokenResponse should be the security token that can be used to authenticate against the CRM Server realm STS.
    /// 
    /// 	This method may be overridden in the case that home realm authenticate requires multiple hops, which is not supported by this call.
    /// </summary>
    /// <returns></returns>
    protected virtual SecurityTokenResponse AuthenticateCrossRealmCore()
    {
      ClientExceptionHelper.ThrowIfNull(ServiceConfiguration, "ServiceConfiguration");
      ClientExceptionHelper.ThrowIfNull(HomeRealmUri, "HomeRealmUri");
      if (AppliesTo == null)
      {
        ClientExceptionHelper.ThrowIfNull(ServiceConfiguration.PolicyConfiguration, "ServiceConfiguration.PolicyConfiguration");
        ClientExceptionHelper.ThrowIfNullOrEmpty(ServiceConfiguration.PolicyConfiguration.SecureTokenServiceIdentifier, "ServiceConfiguration.PolicyConfiguration.SecureTokenServiceIdentifier");
        AppliesTo = ServiceConfiguration.PolicyConfiguration.SecureTokenServiceIdentifier;
      }
      return ServiceConfiguration.AuthenticateCrossRealm(ClientCredentials, AppliesTo, HomeRealmUri);
    }

    protected bool? ShouldRetry(MessageSecurityException messageSecurityException, bool? retry) => !retry.HasValue && messageSecurityException.InnerException is FaultException innerException && innerException.Code.IsSenderFault && innerException.Code.SubCode.Name == "BadContextToken" ? new bool?(true) : new bool?(false);

    /// <summary>
    /// 	Checks the IsAuthenticated flag, and if false, calls Authenticate;
    /// 
    /// 	Then checks the service channel, and if null, calls CreateNewChannel;
    /// </summary>
    protected virtual void ValidateAuthentication()
    {
      if (!IsAuthenticated)
        Authenticate();
      if (_serviceChannel != null && !_serviceChannel.IsChannelInvalid)
        return;
      CreateNewServiceChannel();
    }

    /// <summary>
    /// 	Allows the client to authenticate the device for LiveId use
    /// </summary>
    /// <returns></returns>
    protected virtual SecurityTokenResponse AuthenticateDeviceCore()
    {
      if (ServiceConfiguration.AuthenticationType != AuthenticationProviderType.LiveId)
        return null;
      ClientExceptionHelper.ThrowIfNull(DeviceCredentials, "DeviceCredentials");
      return ServiceConfiguration.AuthenticateDevice(DeviceCredentials);
    }

    /// <summary>
    /// 	if the server is in Claims mode (including Live), will attempt to request a new token, otherwise will just mark the proxy as authenticated,
    /// 	so that the default security conversation will take place.
    /// </summary>
    protected virtual void AuthenticateCore()
    {
      ClientExceptionHelper.ThrowIfNull(ServiceConfiguration, "ServiceConfiguration");
      if (ServiceConfiguration.AuthenticationType == AuthenticationProviderType.None)
        IsAuthenticated = true;
      else if (ServiceConfiguration.AuthenticationType == AuthenticationProviderType.ActiveDirectory)
      {
        IsAuthenticated = true;
      }
      else
      {
        if (ClientCredentials == null)
          return;
        SecurityTokenResponse securityTokenResponse = null;
        switch (ServiceConfiguration.AuthenticationType)
        {
          case AuthenticationProviderType.Federation:
            securityTokenResponse = AuthenticateClaims();
            break;
          case AuthenticationProviderType.LiveId:
            throw new InvalidOperationException("Authentication to MSA services is not supported.");
          case AuthenticationProviderType.OnlineFederation:
            securityTokenResponse = AuthenticateOnlineFederation();
            break;
        }
        ClientExceptionHelper.Assert(securityTokenResponse != null && securityTokenResponse.Token != null, "The user authentication failed!");
        SecurityTokenResponse = securityTokenResponse;
        IsAuthenticated = true;
      }
    }

    private SecurityTokenResponse AuthenticateOnlineFederation()
    {
      var authenticationCredentials = new AuthenticationCredentials();
      authenticationCredentials.ClientCredentials = ClientCredentials;
      if (HomeRealmUri == null)
      {
        var str = UserPrincipalName;
        if (string.IsNullOrEmpty(str))
        {
          if (string.IsNullOrEmpty(ClientCredentials.Windows.ClientCredential.UserName))
          {
            ClientExceptionHelper.ThrowIfNullOrEmpty(ClientCredentials.UserName.UserName, "ClientCredentials.UserName.UserName");
            str = ClientCredentials.UserName.UserName;
          }
          else
            str = ClientCredentials.Windows.ClientCredential.UserName;
        }
        authenticationCredentials.UserPrincipalName = str;
      }
      return ServiceManagement.Authenticate(authenticationCredentials)?.SecurityTokenResponse;
    }

    private SecurityTokenResponse AuthenticateClaims()
    {
      if (!(HomeRealmUri != null))
        return ServiceConfiguration.Authenticate(ClientCredentials);
      HomeRealmSecurityTokenResponse = AuthenticateCrossRealm();
      ClientExceptionHelper.Assert(HomeRealmSecurityTokenResponse != null && HomeRealmSecurityTokenResponse.Token != null, "The user authentication failed!");
      return ServiceConfiguration.Authenticate(HomeRealmSecurityTokenResponse.Token);
    }

    /// <summary>
    /// 	If there is a valid channel and it needs to be closed either forcefully or automatically, this will close it, otherwise, it will take no action.
    /// </summary>
    protected virtual void CloseChannel(bool forceClose)
    {
      if (!forceClose && !AutoCloseChannel || _serviceChannel == null)
        return;
      _serviceChannel.Close();
    }

    protected static void SetBindingTimeout(
      Binding binding,
      TimeSpan sendTimeout,
      TimeSpan openTimeout,
      TimeSpan closeTimeout)
    {
      ClientExceptionHelper.ThrowIfNull(binding, nameof (binding));
      binding.OpenTimeout = openTimeout;
      binding.CloseTimeout = closeTimeout;
      binding.SendTimeout = sendTimeout;
    }

    protected ChannelFactory<TService> ChannelFactory
    {
      get
      {
        if (IsChannelFactoryInvalid())
        {
          _channelFactory = SecurityTokenResponse != null ? (SecurityTokenResponse.EndpointType == TokenServiceCredentialType.None || !(HomeRealmUri == null) ? ServiceConfiguration.CreateChannelFactory(ClientAuthenticationType.SecurityToken) : ServiceConfiguration.CreateChannelFactory(SecurityTokenResponse.EndpointType)) : ServiceConfiguration.CreateChannelFactory(ClientCredentials);
          ConfigureEndpoint(_channelFactory.Endpoint, this);
        }
        return _channelFactory;
      }
    }

    /// <summary>Updates the endpoint to have the correct quotas</summary>
    /// <param name="endpoint">Endpoint that needs to be updated</param>
    /// <param name="serviceProxy">The service proxy instance</param>
    internal static void ConfigureEndpoint(
      ServiceEndpoint endpoint,
      ServiceProxy<TService> serviceProxy)
    {
      ClientExceptionHelper.ThrowIfNull(endpoint, nameof (endpoint));
      ClientExceptionHelper.ThrowIfNull(serviceProxy, nameof (serviceProxy));
      foreach (var operation in endpoint.Contract.Operations)
      {
        var operationBehavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
        if (operationBehavior != null)
          operationBehavior.MaxItemsInObjectGraph = int.MaxValue;
      }
      var xrmBinding = new XrmBinding(endpoint.Binding);
      endpoint.Binding = xrmBinding;
      xrmBinding.MaxReceivedMessageSize = int.MaxValue;
      xrmBinding.MaxBufferSize = int.MaxValue;
      xrmBinding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
      xrmBinding.ReaderQuotas.MaxArrayLength = int.MaxValue;
      xrmBinding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
      xrmBinding.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;
      SetBindingTimeout(xrmBinding, serviceProxy.Timeout, serviceProxy.Timeout, serviceProxy.Timeout);
    }

    private void SetClientCredentials(ClientCredentials clientCredentials)
    {
      ClientCredentials = clientCredentials ?? new ClientCredentials();
      if (ServiceConfiguration.AuthenticationType != AuthenticationProviderType.ActiveDirectory)
        return;
      ServiceMetadataUtility.AdjustUserNameForWindows(ClientCredentials);
    }

    /// <summary>
    /// 	Creates a new Service Channel using either the current credentials or security token.
    /// </summary>
    private void CreateNewServiceChannel()
    {
      ChannelFactory.Faulted += new EventHandler(Factory_Faulted);
      ChannelFactory.Opened += new EventHandler(Factory_Opened);
      ChannelFactory.Closed += new EventHandler(Factory_Closed);
      _serviceChannel = SecurityTokenResponse == null || SecurityTokenResponse.Token == null ? new ServiceChannel<TService>(ChannelFactory) : new ServiceFederatedChannel<TService>(ChannelFactory, SecurityTokenResponse.Token);
      _serviceChannel.Timeout = Timeout;
    }

    private void RefreshChannelManagers()
    {
      if (_channelFactory != null)
        SetBindingTimeout(_channelFactory.Endpoint.Binding, _timeout, _timeout, _timeout);
      if (_serviceChannel == null)
        return;
      _serviceChannel.Timeout = _timeout;
    }

    private bool IsChannelFactoryInvalid()
    {
      if (_channelFactory != null)
      {
        switch (_channelFactory.State)
        {
          case CommunicationState.Created:
          case CommunicationState.Opening:
          case CommunicationState.Opened:
            return false;
        }
      }
      return true;
    }

    private void RemoveChannelFactoryEvents()
    {
      if (_channelFactory == null)
        return;
      _channelFactory.Faulted -= new EventHandler(Factory_Faulted);
      _channelFactory.Opened -= new EventHandler(Factory_Opened);
      _channelFactory.Closed -= new EventHandler(Factory_Closed);
    }

    private void Factory_Faulted(object sender, EventArgs e)
    {
      OnFactoryFaulted(new ChannelFaultedEventArgs("The Factory has entered a faulted state.", null));
      if (_channelFactory == null)
        return;
      RemoveChannelFactoryEvents();
      ChannelExtensions.Close(_channelFactory);
      _channelFactory = null;
    }

    protected virtual void OnFactoryFaulted(ChannelFaultedEventArgs args)
    {
      if (FactoryFaulted == null)
        return;
      FactoryFaulted(this, args);
    }

    private void Factory_Closed(object sender, EventArgs e) => OnFactoryClosed(new ChannelEventArgs("The Factory has entered a closed state."));

    protected virtual void OnFactoryClosed(ChannelEventArgs args)
    {
      if (FactoryClosed == null)
        return;
      FactoryClosed(this, args);
    }

    private void Factory_Opened(object sender, EventArgs e) => OnFactoryOpened(new ChannelEventArgs("The Factory has entered an opened state."));

    protected virtual void OnFactoryOpened(ChannelEventArgs args)
    {
      if (FactoryOpened == null)
        return;
      FactoryOpened(this, args);
    }

    public event EventHandler<ChannelFaultedEventArgs> FactoryFaulted;

    public event EventHandler<ChannelEventArgs> FactoryOpened;

    public event EventHandler<ChannelEventArgs> FactoryClosed;

    protected bool? HandleFailover(BaseServiceFault fault, bool? retry) => fault.ErrorCode == -2147176347 && HandleFailover(retry) ? new bool?(true) : new bool?(false);

    protected bool HandleFailover(bool? retry)
    {
      if (!retry.HasValue)
      {
        if (!EndpointSwitch.CanSwitch(ChannelFactory.Endpoint.Address.Uri))
        {
          Dispose(true);
          return true;
        }
        if (EndpointSwitch.HandleEndpointSwitch())
        {
          Dispose(true);
          return true;
        }
      }
      return false;
    }

    public event EventHandler<EndpointSwitchEventArgs> EndpointSwitched
    {
      add => EndpointSwitch.EndpointSwitched += value;
      remove => EndpointSwitch.EndpointSwitched -= value;
    }

    public event EventHandler<EndpointSwitchEventArgs> EndpointSwitchRequired
    {
      add => EndpointSwitch.EndpointSwitchRequired += value;
      remove => EndpointSwitch.EndpointSwitchRequired -= value;
    }

    public bool EndpointAutoSwitchEnabled
    {
      get => EndpointSwitch.EndpointAutoSwitchEnabled;
      set => EndpointSwitch.EndpointAutoSwitchEnabled = value;
    }

    public bool SwitchToAlternateEndpoint()
    {
      if (!EndpointAutoSwitchEnabled || !(EndpointSwitch.AlternateEndpoint != null))
        return false;
      EndpointSwitch.SwitchEndpoint();
      return true;
    }

    private void SetDefaultEndpointSwitchBehavior() => EndpointAutoSwitchEnabled = EndpointSwitch.AlternateEndpoint != null;

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    ~ServiceProxy() => Dispose(false);

    internal void DisposeFactory(bool disposing)
    {
      if (!disposing)
        return;
      if (_channelFactory != null)
      {
        RemoveChannelFactoryEvents();
        ChannelExtensions.Close(_channelFactory);
      }
      _channelFactory = null;
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing)
        return;
      DisposeFactory(disposing);
      if (_serviceChannel != null)
        _serviceChannel.Dispose();
      _serviceChannel = null;
    }
  }
}
