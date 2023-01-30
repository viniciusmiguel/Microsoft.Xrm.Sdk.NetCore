/*
// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.IServiceManagement`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.ServiceModel;
using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.Client
{
  /// <summary>
  /// This interface does NOT provide support for LiveID based authentication.
  /// </summary>
  /// <typeparam name="TService"></typeparam>
  public interface IServiceManagement<TService>
  {
    /// <summary>
    /// 	This defaults to the first avaialble endpoint in the ServiceEndpoints dictionary if it has not been set.
    /// </summary>
    ServiceEndpoint CurrentServiceEndpoint { get; set; }

    /// <summary>
    /// 	Identifies whether the constructed service is using Claims (Federation) authentication or AD.
    /// </summary>
    AuthenticationProviderType AuthenticationType { get; }

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
    /// 
    /// </summary>
    /// <returns></returns>
    AuthenticationCredentials Authenticate(
      AuthenticationCredentials authenticationCredentials);

    IdentityProvider GetIdentityProvider(string userPrincipalName);
  }
}
*/
