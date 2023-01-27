// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.IServiceConfiguration`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.Client
{
  public interface IServiceConfiguration<TService>
  {
    /// <summary>
    /// 	If there is a CurrentServiceEndpoint and the Service has been configured for claims (Federation,) then this
    /// 	is the endpoint used by the Secure Token Service (STS) to issue the trusted token.
    /// </summary>
    IssuerEndpoint CurrentIssuer { get; set; }

    /// <summary>
    /// 	This defaults to the first avaialble endpoint in the ServiceEndpoints dictionary if it has not been set.
    /// </summary>
    ServiceEndpoint CurrentServiceEndpoint { get; set; }

    /// <summary>
    /// 	Identifies whether the constructed service is using Claims (Federation) authentication or AD.
    /// </summary>
    AuthenticationProviderType AuthenticationType { get; }

    /// <summary>
    /// 	Contains the list of urls and binding information required in order to make a call to a WCF service.  If the service is configured
    /// 	for On-Premise use only, then the endpoint(s) contained within will NOT require the use of an Issuer Endpoint on the binding.
    /// 
    /// 	If the service is configured to use Claims (Federation,) then the binding on the service endpoint MUST be configured to use
    /// 	the appropriate Issuer Endpoint, i.e., UserNamePassword, Kerberos, etc.
    /// </summary>
    ServiceEndpointDictionary ServiceEndpoints { get; }

    /// <summary>
    /// 	The following property contains the urls and binding information required to use a configured Secure Token Service (STS)
    /// 	for issuing a trusted token that the service endpoint will trust for authentication.
    /// 
    /// 	The available endpoints can vary, depending on how the administrator of the STS has configured the server, but may include
    /// 	the following authentication methods:
    /// 
    /// 	1.  UserName and Password
    /// 	2.  Kerberos
    /// 	3.  Certificate
    /// 	4.  Asymmetric Token
    /// 	5.  Symmetric Token
    /// </summary>
    IssuerEndpointDictionary IssuerEndpoints { get; }

    /// <summary>
    /// 	Contains the STS IssuerEndpoints as determined dynamically by calls to AuthenticateCrossRealm.
    /// </summary>
    CrossRealmIssuerEndpointCollection CrossRealmIssuerEndpoints { get; }

    PolicyConfiguration PolicyConfiguration { get; }

    /// <summary>
    /// 	Creates a client factory that uses the default Kerberos credentials (i.e., clientAuthenticationType = ClientAuthenticationType.Kerberos.)
    /// </summary>
    /// <returns></returns>
    ChannelFactory<TService> CreateChannelFactory();

    /// <summary>
    /// 	Creates a channel factory that uses the default Kerberos credentials (clientAuthenticationType = ClientAuthenticationType.Kerberos, )
    /// 	<example>
    /// 		var channel = channelFactory.CreateChannel();
    /// 	</example>
    /// 	or allows the usage of a Security Token during channel creation later (clientAuthenticationType = ClientAuthenticationType.SecurityToken )
    /// 	<example>
    /// 		var channel = channelFactory.CreateChannelWithIssuedToken(SecurityToken);
    /// 	</example>
    /// </summary>
    /// <param name="clientAuthenticationType"></param>
    /// <returns></returns>
    ChannelFactory<TService> CreateChannelFactory(ClientAuthenticationType clientAuthenticationType);

    /// <summary>
    /// 	Creates a channel factory that uses the credential type used when getting the Token Response
    /// </summary>
    /// <param name="clientCredentials"></param>
    /// <returns></returns>
    ChannelFactory<TService> CreateChannelFactory(TokenServiceCredentialType endpointType);

    /// <summary>
    /// 	Creates a channel factory that supports passing the client credentials, regardless of whether in Federation Authentication mode or not.
    /// 
    /// 	Windows and UserName are the currently supported settings.
    /// </summary>
    /// <param name="clientCredentials"></param>
    /// <returns></returns>
    ChannelFactory<TService> CreateChannelFactory(ClientCredentials clientCredentials);

    /// <summary>
    /// 	Authenticates against the Trusted CRM Secure Token Service using client credentials supporting both
    /// 	Username and Windows (when in Federation mode) and returns a wrapper with both the RequestSecurityTokenResponse and the SecurityToken.
    /// 
    /// 	Will return null when in ActiveDirectory mode.
    /// </summary>
    /// <param name="clientCredentials">A ClientCredentialsinstance with the Windows credentials or the UserName/Password</param>
    /// <returns>SecurityTokenResponse that contains both the RTSR and the SecurityToken</returns>
    SecurityTokenResponse Authenticate(ClientCredentials clientCredentials);

    /// <summary>
    /// 	Authenticates against the Trusted CRM Secure Token Service using a Security Token retrieved from
    /// 	an Identity Provider other than the Trusted CRM Secure Token Service (when in Federation mode) and
    /// 	returns a wrapper with both the RequestSecurityTokenResponse and the SecurityToken.
    /// </summary>
    /// <param name="securityToken">A Security Token issued from an Identity Provider.</param>
    /// <returns>SecurityTokenResponse that contains both the RTSR and the SecurityToken</returns>
    SecurityTokenResponse Authenticate(SecurityToken securityToken);

    /// <summary>
    /// 	Authenticates against a remote Secure Token Service using client credentials supporting both
    /// 	Username and Windows (when in Federation mode) and returns a wrapper with both the RequestSecurityTokenResponse and the SecurityToken.
    /// 
    /// 	Will throw a NotSupportedException when in ActiveDirectory mode.
    /// </summary>
    /// <param name="clientCredentials">A ClientCredentials instance with the Windows credentials or the UserName/Password</param>
    /// <param name="appliesTo">The identifier of the STS to authenticate on behalf of</param>
    /// <param name="crossRealmSts">The uri of the cross realm STS metadata endpoint</param>
    /// <returns>SecurityTokenResponse that contains both the RTSR and the SecurityToken</returns>
    SecurityTokenResponse AuthenticateCrossRealm(
      ClientCredentials clientCredentials,
      string appliesTo,
      Uri crossRealmSts);

    /// <summary>
    /// 	Authenticates against a remote Secure Token Service using a Security Token retrieved from
    /// 	an Identity Provider (when in Federation mode) and
    /// 	returns a wrapper with both the RequestSecurityTokenResponse and the SecurityToken.
    /// 
    /// 	Will throw a NotSupportedException when in ActiveDirectory mode.
    /// </summary>
    /// <param name="securityToken">A Security Token issued from an Identity Provider.</param>
    /// 
    ///             ///
    ///             <param name="appliesTo">The identifier of the STS to authenticate on behalf of</param>
    /// <param name="crossRealmSts">The uri of the cross realm STS metadata endpoint</param>
    /// <returns>SecurityTokenResponse that contains both the RTSR and the SecurityToken</returns>
    SecurityTokenResponse AuthenticateCrossRealm(
      SecurityToken securityToken,
      string appliesTo,
      Uri crossRealmSts);

    /// <summary>
    /// 	Authenticates a user against Windows Live ID.  The UserName.UserName and UserName.Password MUST be populated
    /// 	with the user name and password, and the SecurityToken must be set to a valid device security token.
    /// </summary>
    /// <param name="clientCredentials">A ClintCredentials instance with the UserName.UserName and UserName.Password set.</param>
    /// <param name="deviceSecurityToken">A Security Token response received from authenticating the user's device with Windows Live ID.</param>
    /// <returns>SecurityTokenResponse that contains both the RTSR and the SecurityToken</returns>
    SecurityTokenResponse Authenticate(
      ClientCredentials clientCredentials,
      SecurityTokenResponse deviceSecurityToken);

    /// <summary>
    /// 	Authenticates a registered device against Windows Live ID.  The UserName.UserName and UserName.Password MUST be populated
    /// 	with the device name and password.
    /// </summary>
    /// <param name="clientCredentials">A ClintCredentials instance with the UserName.UserName and UserName.Password set.</param>
    /// <returns>SecurityTokenResponse that contains both the RTSR and the SecurityToken</returns>
    SecurityTokenResponse AuthenticateDevice(ClientCredentials clientCredentials);

    IdentityProvider GetIdentityProvider(string userPrincipalName);
  }
}
