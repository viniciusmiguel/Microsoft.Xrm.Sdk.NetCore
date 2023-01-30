
/*
// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Protocols.WSTrust.Bindings.IssuedTokenWSTrustBinding
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace Microsoft.Crm.Protocols.WSTrust.Bindings
{
  /// <summary>
  /// This class has been in-place ported from WIF 3.5 for legacy support.  It SHOULD NOT be used for any future development but deleted once WS-Trust support has been removed.
  /// </summary>
  internal sealed class IssuedTokenWSTrustBinding : WSTrustBindingBase
  {
    private SecurityAlgorithmSuite _algorithmSuite;
    private Collection<ClaimTypeRequirement> _claimTypeRequirements;
    private EndpointAddress _issuerAddress;
    private Binding _issuerBinding;
    private EndpointAddress _issuerMetadataAddress;
    private SecurityKeyType _keyType;
    private string _tokenType;

    public IssuedTokenWSTrustBinding()
      : this(null, null)
    {
    }

    public IssuedTokenWSTrustBinding(Binding issuerBinding, EndpointAddress issuerAddress)
      : this(issuerBinding, issuerAddress, SecurityMode.Message, TrustVersion.WSTrust13, null)
    {
    }

    public IssuedTokenWSTrustBinding(
      Binding issuerBinding,
      EndpointAddress issuerAddress,
      EndpointAddress issuerMetadataAddress)
      : this(issuerBinding, issuerAddress, SecurityMode.Message, TrustVersion.WSTrust13, issuerMetadataAddress)
    {
    }

    public IssuedTokenWSTrustBinding(
      Binding issuerBinding,
      EndpointAddress issuerAddress,
      string tokenType,
      IEnumerable<ClaimTypeRequirement> claimTypeRequirements)
      : this(issuerBinding, issuerAddress, SecurityKeyType.SymmetricKey, SecurityAlgorithmSuite.Basic256, tokenType, claimTypeRequirements)
    {
    }

    public IssuedTokenWSTrustBinding(
      Binding issuerBinding,
      EndpointAddress issuerAddress,
      SecurityMode mode,
      TrustVersion trustVersion,
      EndpointAddress issuerMetadataAddress)
      : this(issuerBinding, issuerAddress, mode, trustVersion, SecurityKeyType.SymmetricKey, SecurityAlgorithmSuite.Basic256, null, null, issuerMetadataAddress)
    {
    }

    public IssuedTokenWSTrustBinding(
      Binding issuerBinding,
      EndpointAddress issuerAddress,
      SecurityKeyType keyType,
      SecurityAlgorithmSuite algorithmSuite,
      string tokenType,
      IEnumerable<ClaimTypeRequirement> claimTypeRequirements)
      : this(issuerBinding, issuerAddress, SecurityMode.Message, TrustVersion.WSTrust13, keyType, algorithmSuite, tokenType, claimTypeRequirements, null)
    {
    }

    public IssuedTokenWSTrustBinding(
      Binding issuerBinding,
      EndpointAddress issuerAddress,
      SecurityMode mode,
      TrustVersion version,
      SecurityKeyType keyType,
      SecurityAlgorithmSuite algorithmSuite,
      string tokenType,
      IEnumerable<ClaimTypeRequirement> claimTypeRequirements,
      EndpointAddress issuerMetadataAddress)
      : base(mode, version)
    {
      _claimTypeRequirements = new Collection<ClaimTypeRequirement>();
      if (mode != SecurityMode.Message && mode != SecurityMode.TransportWithMessageCredential)
        throw new InvalidOperationException(ClientExceptionHelper.GetString("ID3226: SecurityMode of IssuedTokenBinding must be SecurityMode.Message or SecurityMode.TransportWithMessageCredential. But actual value is '{0}'.", mode));
      if (_keyType == SecurityKeyType.BearerKey && version == TrustVersion.WSTrustFeb2005)
        throw new InvalidOperationException(ClientExceptionHelper.GetString("ID3267: Bearer KeyType is not supported with WSTrustFeb2005 version of WSTrust. Consider using WSTrust13 instead."));
      _keyType = keyType;
      _algorithmSuite = algorithmSuite;
      _tokenType = tokenType;
      _issuerBinding = issuerBinding;
      _issuerAddress = issuerAddress;
      _issuerMetadataAddress = issuerMetadataAddress;
      if (claimTypeRequirements == null)
        return;
      foreach (var claimTypeRequirement in claimTypeRequirements)
        _claimTypeRequirements.Add(claimTypeRequirement);
    }

    private void AddAlgorithmParameters(
      SecurityAlgorithmSuite algorithmSuite,
      TrustVersion trustVersion,
      SecurityKeyType keyType,
      ref IssuedSecurityTokenParameters issuedParameters)
    {
      issuedParameters.AdditionalRequestParameters.Insert(0, CreateEncryptionAlgorithmElement(algorithmSuite.DefaultEncryptionAlgorithm));
      issuedParameters.AdditionalRequestParameters.Insert(0, CreateCanonicalizationAlgorithmElement(algorithmSuite.DefaultCanonicalizationAlgorithm));
      string signatureAlgorithm;
      string encryptionAlgorithm;
      switch (keyType)
      {
        case SecurityKeyType.SymmetricKey:
          signatureAlgorithm = algorithmSuite.DefaultSymmetricSignatureAlgorithm;
          encryptionAlgorithm = algorithmSuite.DefaultEncryptionAlgorithm;
          break;
        case SecurityKeyType.AsymmetricKey:
          signatureAlgorithm = algorithmSuite.DefaultAsymmetricSignatureAlgorithm;
          encryptionAlgorithm = algorithmSuite.DefaultAsymmetricKeyWrapAlgorithm;
          break;
        case SecurityKeyType.BearerKey:
          return;
        default:
          throw new ArgumentOutOfRangeException(nameof (keyType));
      }
      issuedParameters.AdditionalRequestParameters.Insert(0, CreateSignWithElement(signatureAlgorithm));
      issuedParameters.AdditionalRequestParameters.Insert(0, CreateEncryptWithElement(encryptionAlgorithm));
      if (trustVersion == TrustVersion.WSTrustFeb2005)
        return;
      issuedParameters.AdditionalRequestParameters.Insert(0, CreateKeyWrapAlgorithmElement(algorithmSuite.DefaultAsymmetricKeyWrapAlgorithm));
    }

    protected override void ApplyTransportSecurity(HttpTransportBindingElement transport) => throw new NotSupportedException(ClientExceptionHelper.GetString("ID3227: Issued token authentication is not supported for Transport security. IssuedTokenWSTrustBinding.SecurityMode must be set to 'Message' or 'TransportWithMessageCredential'."));

    [SuppressMessage("Microsoft.NetFramework.Analyzers", "CA3075:Insecure DTD processing in XML", Justification = "FxCop Bankruptcy")]
    private XmlElement CreateCanonicalizationAlgorithmElement(string canonicalizationAlgorithm)
    {
      if (canonicalizationAlgorithm == null)
        throw new ArgumentNullException(nameof (canonicalizationAlgorithm));
      var xmlDocument = new XmlDocument();
      XmlElement algorithmElement = null;
      if (TrustVersion == TrustVersion.WSTrust13)
        algorithmElement = xmlDocument.CreateElement("trust", "CanonicalizationAlgorithm", "http://docs.oasis-open.org/ws-sx/ws-trust/200512");
      else if (TrustVersion == TrustVersion.WSTrustFeb2005)
        algorithmElement = xmlDocument.CreateElement("t", "CanonicalizationAlgorithm", "http://schemas.xmlsoap.org/ws/2005/02/trust");
      algorithmElement?.AppendChild(xmlDocument.CreateTextNode(canonicalizationAlgorithm));
      return algorithmElement;
    }

    [SuppressMessage("Microsoft.NetFramework.Analyzers", "CA3075:Insecure DTD processing in XML", Justification = "FxCop Bankruptcy")]
    private XmlElement CreateEncryptionAlgorithmElement(string encryptionAlgorithm)
    {
      if (encryptionAlgorithm == null)
        throw new ArgumentNullException(nameof (encryptionAlgorithm));
      var xmlDocument = new XmlDocument();
      XmlElement algorithmElement = null;
      if (TrustVersion == TrustVersion.WSTrust13)
        algorithmElement = xmlDocument.CreateElement("trust", "EncryptionAlgorithm", "http://docs.oasis-open.org/ws-sx/ws-trust/200512");
      else if (TrustVersion == TrustVersion.WSTrustFeb2005)
        algorithmElement = xmlDocument.CreateElement("t", "EncryptionAlgorithm", "http://schemas.xmlsoap.org/ws/2005/02/trust");
      algorithmElement?.AppendChild(xmlDocument.CreateTextNode(encryptionAlgorithm));
      return algorithmElement;
    }

    [SuppressMessage("Microsoft.NetFramework.Analyzers", "CA3075:Insecure DTD processing in XML", Justification = "FxCop Bankruptcy")]
    private XmlElement CreateEncryptWithElement(string encryptionAlgorithm)
    {
      if (encryptionAlgorithm == null)
        throw new ArgumentNullException(nameof (encryptionAlgorithm));
      var xmlDocument = new XmlDocument();
      XmlElement encryptWithElement = null;
      if (TrustVersion == TrustVersion.WSTrust13)
        encryptWithElement = xmlDocument.CreateElement("trust", "EncryptWith", "http://docs.oasis-open.org/ws-sx/ws-trust/200512");
      else if (TrustVersion == TrustVersion.WSTrustFeb2005)
        encryptWithElement = xmlDocument.CreateElement("t", "EncryptWith", "http://schemas.xmlsoap.org/ws/2005/02/trust");
      encryptWithElement?.AppendChild(xmlDocument.CreateTextNode(encryptionAlgorithm));
      return encryptWithElement;
    }

    [SuppressMessage("Microsoft.NetFramework.Analyzers", "CA3075:Insecure DTD processing in XML", Justification = "FxCop Bankruptcy")]
    private static XmlElement CreateKeyWrapAlgorithmElement(string keyWrapAlgorithm)
    {
      if (keyWrapAlgorithm == null)
        throw new ArgumentNullException(nameof (keyWrapAlgorithm));
      var xmlDocument = new XmlDocument();
      var element = xmlDocument.CreateElement("trust", "KeyWrapAlgorithm", "http://docs.oasis-open.org/ws-sx/ws-trust/200512");
      element.AppendChild(xmlDocument.CreateTextNode(keyWrapAlgorithm));
      return element;
    }

    protected override SecurityBindingElement CreateSecurityBindingElement()
    {
      var issuedParameters = new IssuedSecurityTokenParameters(_tokenType, _issuerAddress, _issuerBinding)
      {
        KeyType = _keyType,
        IssuerMetadataAddress = _issuerMetadataAddress
      };
      issuedParameters.KeySize = _keyType != SecurityKeyType.SymmetricKey ? 0 : _algorithmSuite.DefaultSymmetricKeyLength;
      if (_claimTypeRequirements != null)
      {
        foreach (var claimTypeRequirement in _claimTypeRequirements)
          issuedParameters.ClaimTypeRequirements.Add(claimTypeRequirement);
      }
      AddAlgorithmParameters(_algorithmSuite, TrustVersion, _keyType, ref issuedParameters);
      SecurityBindingElement securityBindingElement;
      if (SecurityMode == SecurityMode.Message)
      {
        securityBindingElement = SecurityBindingElement.CreateIssuedTokenForCertificateBindingElement(issuedParameters);
      }
      else
      {
        if (SecurityMode != SecurityMode.TransportWithMessageCredential)
          throw new InvalidOperationException(ClientExceptionHelper.GetString("ID3226: SecurityMode of IssuedTokenBinding must be SecurityMode.Message or SecurityMode.TransportWithMessageCredential. But actual value is '{0}'.", SecurityMode));
        securityBindingElement = SecurityBindingElement.CreateIssuedTokenOverTransportBindingElement(issuedParameters);
      }
      securityBindingElement.DefaultAlgorithmSuite = _algorithmSuite;
      securityBindingElement.IncludeTimestamp = true;
      return securityBindingElement;
    }

    [SuppressMessage("Microsoft.NetFramework.Analyzers", "CA3075:Insecure DTD processing in XML", Justification = "FxCop Bankruptcy")]
    private XmlElement CreateSignWithElement(string signatureAlgorithm)
    {
      if (signatureAlgorithm == null)
        throw new ArgumentNullException(nameof (signatureAlgorithm));
      var xmlDocument = new XmlDocument();
      XmlElement signWithElement = null;
      if (TrustVersion == TrustVersion.WSTrust13)
        signWithElement = xmlDocument.CreateElement("trust", "SignatureAlgorithm", "http://docs.oasis-open.org/ws-sx/ws-trust/200512");
      else if (TrustVersion == TrustVersion.WSTrustFeb2005)
        signWithElement = xmlDocument.CreateElement("t", "SignatureAlgorithm", "http://schemas.xmlsoap.org/ws/2005/02/trust");
      signWithElement?.AppendChild(xmlDocument.CreateTextNode(signatureAlgorithm));
      return signWithElement;
    }

    public SecurityAlgorithmSuite AlgorithmSuite
    {
      get => _algorithmSuite;
      set => _algorithmSuite = value;
    }

    public Collection<ClaimTypeRequirement> ClaimTypeRequirement => _claimTypeRequirements;

    public EndpointAddress IssuerAddress
    {
      get => _issuerAddress;
      set => _issuerAddress = value;
    }

    public Binding IssuerBinding
    {
      get => _issuerBinding;
      set => _issuerBinding = value;
    }

    public EndpointAddress IssuerMetadataAddress
    {
      get => _issuerMetadataAddress;
      set => _issuerMetadataAddress = value;
    }

    public SecurityKeyType KeyType
    {
      get => _keyType;
      set => _keyType = value;
    }

    public string TokenType
    {
      get => _tokenType;
      set => _tokenType = value;
    }
  }
}
*/
