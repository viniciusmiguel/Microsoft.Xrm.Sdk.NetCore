
// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Protocols.WSTrust.Bindings.UserNameWSTrustBinding
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.Crm.Protocols.WSTrust.Bindings
{
  /// <summary>
  /// This class has been in-place ported from WIF 3.5 for legacy support.  It SHOULD NOT be used for any future development but deleted once WS-Trust support has been removed.
  /// </summary>
  internal sealed class UserNameWSTrustBinding : WSTrustBindingBase
  {
    private HttpClientCredentialType _clientCredentialType;

    public UserNameWSTrustBinding()
      : this(SecurityMode.Message, HttpClientCredentialType.None)
    {
    }

    public UserNameWSTrustBinding(SecurityMode securityMode)
      : base(securityMode)
    {
      if (securityMode != SecurityMode.Message)
        return;
      _clientCredentialType = HttpClientCredentialType.None;
    }

    public UserNameWSTrustBinding(SecurityMode mode, HttpClientCredentialType clientCredentialType)
      : base(mode)
    {
      if (!IsHttpClientCredentialTypeDefined(clientCredentialType))
        throw new ArgumentOutOfRangeException(nameof (clientCredentialType));
      _clientCredentialType = mode != SecurityMode.Transport || clientCredentialType == HttpClientCredentialType.Digest || clientCredentialType == HttpClientCredentialType.Basic ? clientCredentialType : throw new InvalidOperationException(ClientExceptionHelper.GetString("ID3225: UserNameWSTrustBinding in SecurityMode.Transport SecurityMode, clientCredentialType must be Digest or Basic. But actual value is '{0}'", clientCredentialType));
    }

    protected override void ApplyTransportSecurity(HttpTransportBindingElement transport)
    {
      if (_clientCredentialType == HttpClientCredentialType.Basic)
        transport.AuthenticationScheme = AuthenticationSchemes.Basic;
      else
        transport.AuthenticationScheme = AuthenticationSchemes.Digest;
    }

    protected override SecurityBindingElement CreateSecurityBindingElement()
    {
      if (SecurityMode == SecurityMode.Message)
        return SecurityBindingElement.CreateUserNameForCertificateBindingElement();
      return SecurityMode == SecurityMode.TransportWithMessageCredential ? SecurityBindingElement.CreateUserNameOverTransportBindingElement() : (SecurityBindingElement) null;
    }

    private static bool IsHttpClientCredentialTypeDefined(HttpClientCredentialType value) => value == HttpClientCredentialType.None || value == HttpClientCredentialType.Basic || value == HttpClientCredentialType.Digest || value == HttpClientCredentialType.Ntlm || value == HttpClientCredentialType.Windows || value == HttpClientCredentialType.Certificate;

    public HttpClientCredentialType ClientCredentialType
    {
      get => _clientCredentialType;
      set
      {
        if (!IsHttpClientCredentialTypeDefined(value))
          throw new ArgumentOutOfRangeException(nameof (value));
        _clientCredentialType = SecurityMode != SecurityMode.Transport || value == HttpClientCredentialType.Digest || value == HttpClientCredentialType.Basic ? value : throw new InvalidOperationException(ClientExceptionHelper.GetString("ID3225: UserNameWSTrustBinding in SecurityMode.Transport SecurityMode, clientCredentialType must be Digest or Basic. But actual value is '{0}'", value));
      }
    }
  }
}
