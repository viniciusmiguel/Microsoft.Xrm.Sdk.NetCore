
/*
// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Protocols.WSTrust.Bindings.WSTrustBindingBase
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;

namespace Microsoft.Crm.Protocols.WSTrust.Bindings
{
  /// <summary>
  /// This class has been in-place ported from WIF 3.5 for legacy support.  It SHOULD NOT be used for any future development but deleted once WS-Trust support has been removed.
  /// </summary>
  internal abstract class WSTrustBindingBase : Binding
  {
    private bool _enableRsaProofKeys;
    private SecurityMode _securityMode;
    private TrustVersion _trustVersion;

    protected WSTrustBindingBase(SecurityMode securityMode)
      : this(securityMode, TrustVersion.WSTrust13)
    {
    }

    protected WSTrustBindingBase(SecurityMode securityMode, TrustVersion trustVersion)
    {
      _securityMode = SecurityMode.Message;
      _trustVersion = TrustVersion.WSTrust13;
      if (trustVersion == null)
        throw new ArgumentNullException(nameof (trustVersion));
      ValidateTrustVersion(trustVersion);
      ValidateSecurityMode(securityMode);
      _securityMode = securityMode;
      _trustVersion = trustVersion;
    }

    protected virtual SecurityBindingElement ApplyMessageSecurity(
      SecurityBindingElement securityBindingElement)
    {
      if (securityBindingElement == null)
        throw new ArgumentNullException(nameof (securityBindingElement));
      securityBindingElement.MessageSecurityVersion = TrustVersion.WSTrustFeb2005 != _trustVersion ? MessageSecurityVersion.WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10 : MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10;
      if (_enableRsaProofKeys)
      {
        var securityTokenParameters1 = new RsaSecurityTokenParameters();
        securityTokenParameters1.InclusionMode = SecurityTokenInclusionMode.Never;
        securityTokenParameters1.RequireDerivedKeys = false;
        var securityTokenParameters2 = securityTokenParameters1;
        securityBindingElement.OptionalEndpointSupportingTokenParameters.Endorsing.Add(securityTokenParameters2);
      }
      return securityBindingElement;
    }

    protected abstract void ApplyTransportSecurity(HttpTransportBindingElement transport);

    public override BindingElementCollection CreateBindingElements()
    {
      var elementCollection = new BindingElementCollection();
      elementCollection.Clear();
      if (_securityMode == SecurityMode.Message || _securityMode == SecurityMode.TransportWithMessageCredential)
        elementCollection.Add(ApplyMessageSecurity(CreateSecurityBindingElement()));
      elementCollection.Add(CreateEncodingBindingElement());
      elementCollection.Add(CreateTransportBindingElement());
      return elementCollection.Clone();
    }

    protected virtual MessageEncodingBindingElement CreateEncodingBindingElement() => new TextMessageEncodingBindingElement()
    {
      ReaderQuotas = {
        MaxArrayLength = 2097152,
        MaxStringContentLength = 2097152
      }
    };

    protected abstract SecurityBindingElement CreateSecurityBindingElement();

    protected virtual HttpTransportBindingElement CreateTransportBindingElement()
    {
      var transport = _securityMode != SecurityMode.Message ? new HttpsTransportBindingElement() : new HttpTransportBindingElement();
      transport.MaxReceivedMessageSize = 2097152L;
      if (_securityMode == SecurityMode.Transport)
        ApplyTransportSecurity(transport);
      return transport;
    }

    protected static void ValidateSecurityMode(SecurityMode securityMode)
    {
      if (securityMode != SecurityMode.None && securityMode != SecurityMode.Message && securityMode != SecurityMode.Transport && securityMode != SecurityMode.TransportWithMessageCredential)
        throw new ArgumentOutOfRangeException(nameof (securityMode));
      if (securityMode == SecurityMode.None)
        throw new InvalidOperationException(ClientExceptionHelper.GetString("ID3224: SecurityMode cannot be SecurityMode.None."));
    }

    protected static void ValidateTrustVersion(TrustVersion trustVersion)
    {
      if (trustVersion != TrustVersion.WSTrust13 && trustVersion != TrustVersion.WSTrustFeb2005)
        throw new ArgumentOutOfRangeException(nameof (trustVersion));
    }

    public bool EnableRsaProofKeys
    {
      get => _enableRsaProofKeys;
      set => _enableRsaProofKeys = value;
    }

    public override string Scheme
    {
      get
      {
        var transportBindingElement = CreateBindingElements().Find<TransportBindingElement>();
        return transportBindingElement == null ? string.Empty : transportBindingElement.Scheme;
      }
    }

    public SecurityMode SecurityMode
    {
      get => _securityMode;
      set
      {
        ValidateSecurityMode(value);
        _securityMode = value;
      }
    }

    public TrustVersion TrustVersion
    {
      get => _trustVersion;
      set
      {
        if (value == null)
          throw new ArgumentNullException(nameof (value));
        ValidateTrustVersion(value);
        _trustVersion = value;
      }
    }
  }
}
*/
