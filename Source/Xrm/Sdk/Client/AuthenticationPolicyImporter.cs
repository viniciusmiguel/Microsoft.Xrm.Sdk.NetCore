// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.AuthenticationPolicyImporter
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;
using System.Xml.XPath;

namespace Microsoft.Xrm.Sdk.Client
{
  internal sealed class AuthenticationPolicyImporter : IPolicyImportExtension
  {
    internal const string MsXrm = "ms-xrm";
    internal readonly string MsXrmAuthentication = "//ms-xrm:Authentication";
    internal const string MsXrmSecureTokenServiceMsXrmIdentifier = "//ms-xrm:SecureTokenService/ms-xrm:Identifier";
    internal const string MsXrmLiveTrust = "//ms-xrm:LiveTrust/";
    internal const string MsXrmOrgTrust = "//ms-xrm:OrgTrust/";
    internal const string AuthenticationPolicy = "AuthenticationPolicy";
    internal const string LivePartnerIdentifier = "LivePartnerIdentifier";
    internal const string AppliesTo = "AppliesTo";
    internal const string TrustVersion = "TrustVersion";
    internal const string SecurityMode = "SecurityMode";
    internal const string LivePolicy = "LivePolicy";
    internal const string AuthenticationType = "AuthenticationType";
    internal const string SecureTokenServiceIdentifier = "SecureTokenServiceIdentifier";
    internal const string LiveIdAppliesTo = "LiveIdAppliesTo";
    internal const string LiveTrustTrustVersion = "LiveTrustTrustVersion";
    internal const string LiveTrustSecurityMode = "LiveTrustSecurityMode";
    internal const string LiveTrustLivePolicy = "LiveTrustLivePolicy";
    internal const string LiveTrustLiveIdAppliesTo = "LiveTrustLiveIdAppliesTo";
    internal const string LiveEndpoint = "LiveEndpoint";
    internal const string OrgIdAppliesTo = "OrgIdAppliesTo";
    internal const string OrgIdTrustVersion = "OrgIdTrustVersion";
    internal const string OrgIdSecurityMode = "OrgIdSecurityMode";
    internal const string OrgIdPolicy = "OrgIdPolicy";
    internal const string OrgIdDeviceAppliesTo = "OrgIdDeviceAppliesTo";
    internal const string OrgIdEndpoint = "OrgIdEndpoint";
    internal const string Identifier = "Identifier";
    internal const string OrgIdIdentifier = "OrgIdIdentifier";
    private const string HttpDocsOasisOpenOrgWsSxWsSecuritypolicy = "http://docs.oasis-open.org/ws-sx/ws-securitypolicy/200702";
    private const string HttpSchemasXmlsoapOrgWsPolicy = "http://schemas.xmlsoap.org/ws/2004/09/policy";
    private const string HttpWwwW3OrgAddressing = "http://www.w3.org/2005/08/addressing";
    private readonly IPolicyImportExtension _importer;
    private readonly object _lockObject = new();

    public AuthenticationPolicyImporter(SecurityBindingElementImporter importer) => _importer = importer;

    public void ImportPolicy(MetadataImporter importer, PolicyConversionContext context)
    {
      ImportXrmAuthenticationPolicy(context);
      ImportSecurityPolicy(importer, context);
    }

    private bool ImportPolicyLegacy(PolicyConversionContext context)
    {
      ImportFailoverPolicy(context);
      var xmlElement = context.GetBindingAssertions().Find("AuthenticationPolicy", "http://schemas.microsoft.com/xrm/2011/Contracts/Services");
      if (xmlElement == null)
        return false;
      var flag = true;
      var xrmPolicyBindingElement = context.BindingElements.Find<AuthenticationPolicy>();
      if (xrmPolicyBindingElement == null)
      {
        xrmPolicyBindingElement = new AuthenticationPolicy();
        context.BindingElements.Insert(0, xrmPolicyBindingElement);
      }
      else if (xrmPolicyBindingElement.PolicyElements.ContainsKey("OrgIdAppliesTo"))
        flag = false;
      context.GetBindingAssertions().Remove(xmlElement);
      if (flag)
      {
        var navigator = xmlElement.CreateNavigator();
        if (navigator != null)
        {
          var nsmgr = new XmlNamespaceManager(navigator.NameTable);
          nsmgr.AddNamespace("ms-xrm", "http://schemas.microsoft.com/xrm/2011/Contracts/Services");
          ExtractValue(xrmPolicyBindingElement, navigator, nsmgr, MsXrmAuthentication, "AuthenticationType");
          ExtractValue(xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:SecureTokenService/ms-xrm:Identifier", "SecureTokenServiceIdentifier");
          ExtractLiveTrustElements(xrmPolicyBindingElement, navigator, nsmgr);
        }
      }
      return true;
    }

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    private bool ImportFailoverPolicy(PolicyConversionContext context)
    {
      var xmlElement = context.GetBindingAssertions().Find("FailoverPolicy", "http://schemas.microsoft.com/xrm/2012/Contracts/Services");
      if (xmlElement == null)
        return false;
      var failoverPolicy = context.BindingElements.Find<FailoverPolicy>();
      if (failoverPolicy == null)
      {
        failoverPolicy = new FailoverPolicy();
        context.BindingElements.Insert(0, failoverPolicy);
      }
      context.GetBindingAssertions().Remove(xmlElement);
      if (true)
      {
        var navigator = xmlElement.CreateNavigator();
        if (navigator != null)
        {
          var nsmgr = new XmlNamespaceManager(navigator.NameTable);
          nsmgr.AddNamespace("ms-xrm", "http://schemas.microsoft.com/xrm/2012/Contracts/Services");
          ExtractValue(failoverPolicy, navigator, nsmgr, "ms-xrm:FailoverAvailable", "FailoverAvailable");
          ExtractValue(failoverPolicy, navigator, nsmgr, "ms-xrm:EndpointEnabled", "EndpointEnabled");
        }
      }
      return true;
    }

    private void ImportXrmAuthenticationPolicy(PolicyConversionContext context)
    {
      var flag = ImportPolicyLegacy(context);
      ImportFailoverPolicy(context);
      var xmlElement = context.GetBindingAssertions().Find("AuthenticationPolicy", "http://schemas.microsoft.com/xrm/2012/Contracts/Services");
      if (xmlElement == null)
        return;
      var xrmPolicyBindingElement = context.BindingElements.Find<AuthenticationPolicy>();
      string str = null;
      if (xrmPolicyBindingElement == null | flag)
      {
        if (flag)
          context.BindingElements.Remove(xrmPolicyBindingElement);
        xrmPolicyBindingElement?.PolicyElements.TryGetValue("AppliesTo", out str);
        xrmPolicyBindingElement = new AuthenticationPolicy();
        if (!string.IsNullOrWhiteSpace(str))
          xrmPolicyBindingElement.PolicyElements.Add("LivePartnerIdentifier", str);
        context.BindingElements.Insert(0, xrmPolicyBindingElement);
      }
      context.GetBindingAssertions().Remove(xmlElement);
      var navigator = xmlElement.CreateNavigator();
      if (navigator == null)
        return;
      var nsmgr = new XmlNamespaceManager(navigator.NameTable);
      nsmgr.AddNamespace("ms-xrm", "http://schemas.microsoft.com/xrm/2012/Contracts/Services");
      ExtractValue(xrmPolicyBindingElement, navigator, nsmgr, MsXrmAuthentication, "AuthenticationType");
      ExtractValue(xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:SecureTokenService/ms-xrm:Identifier", "SecureTokenServiceIdentifier");
      ExtractLiveTrustElements(xrmPolicyBindingElement, navigator, nsmgr);
      ExtractOrgTrustElements(xrmPolicyBindingElement, navigator, nsmgr);
    }

    private static void ExtractLiveTrustElements(
      AuthenticationPolicy xrmPolicyBindingElement,
      XPathNavigator navigator,
      XmlNamespaceManager nsmgr)
    {
      ExtractValue(xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:LiveTrust/ms-xrm:AppliesTo", "AppliesTo");
      ExtractValue(xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:LiveTrust/ms-xrm:TrustVersion", "LiveTrustTrustVersion");
      ExtractValue(xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:LiveTrust/ms-xrm:SecurityMode", "LiveTrustSecurityMode");
      ExtractValue(xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:LiveTrust/ms-xrm:LivePolicy", "LiveTrustLivePolicy");
      ExtractValue(xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:LiveTrust/ms-xrm:LiveIdAppliesTo", "LiveTrustLiveIdAppliesTo");
      ExtractValue(xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:LiveTrust/ms-xrm:LiveEndpoint", "LiveEndpoint");
    }

    private static void ExtractOrgTrustElements(
      AuthenticationPolicy xrmPolicyBindingElement,
      XPathNavigator navigator,
      XmlNamespaceManager nsmgr)
    {
      ExtractValue(xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:OrgTrust/ms-xrm:AppliesTo", "OrgIdAppliesTo");
      ExtractValue(xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:OrgTrust/ms-xrm:TrustVersion", "OrgIdTrustVersion");
      ExtractValue(xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:OrgTrust/ms-xrm:SecurityMode", "OrgIdSecurityMode");
      ExtractValue(xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:OrgTrust/ms-xrm:LivePolicy", "OrgIdPolicy");
      ExtractValue(xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:OrgTrust/ms-xrm:LiveIdAppliesTo", "OrgIdDeviceAppliesTo");
      ExtractValue(xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:OrgTrust/ms-xrm:LiveEndpoint", "OrgIdEndpoint");
      ExtractValue(xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:OrgTrust/ms-xrm:Identifier", "OrgIdIdentifier");
    }

    private static void ExtractValue(
      XrmPolicy xrmPolicy,
      XPathNavigator navigator,
      XmlNamespaceManager nsmgr,
      string query,
      string name)
    {
      var xpathNavigator = navigator.SelectSingleNode(query, nsmgr);
      if (xpathNavigator == null)
        return;
      xrmPolicy.PolicyElements[name] = xpathNavigator.Value;
    }

    /// <summary>
    /// This methods imports a security policy.
    /// For OnlineFederation and LiveId auth type, it updates the metadataImporter to use a custom MetadataExchangeClient which does not automatically resolve references.
    /// This reduces the number of calls to ACS MEX service that we did with the previous implementation.
    /// </summary>
    /// <param name="metadataImporter">The MetadataImporter object</param>
    /// <param name="context">The PolicyConversionContext object</param>
    private void ImportSecurityPolicy(
      MetadataImporter metadataImporter,
      PolicyConversionContext context)
    {
      var flag = true;
      var authenticationPolicy = context.BindingElements.Find<AuthenticationPolicy>();
      AuthenticationProviderType result;
      if (authenticationPolicy != null && authenticationPolicy.PolicyElements.ContainsKey("AuthenticationType") && Enum.TryParse<AuthenticationProviderType>(authenticationPolicy.PolicyElements["AuthenticationType"], out result))
        flag = result != AuthenticationProviderType.OnlineFederation && result != AuthenticationProviderType.LiveId;
      if (_importer == null)
        return;
      if (flag)
        _importer.ImportPolicy(metadataImporter, context);
      else
        ImportSecurityPolicyWithoutMetadata(metadataImporter, context);
    }

    /// <summary>
    /// This methods imports a security policy by using a custom MetadataExchangeClient object which has ResolveMetadataReferences propery set to false
    /// This method was added to reduce the number of calls done to ACS MEX service for OnlineFederation authentication.
    /// </summary>
    /// <param name="metadataImporter">The MetadataImporter object</param>
    /// <param name="context">The PolicyConversionContext object</param>
    private void ImportSecurityPolicyWithoutMetadata(
      MetadataImporter metadataImporter,
      PolicyConversionContext context)
    {
      RemoveIssuerMetadataForOnline(context);
      var metadataExchangeClient = new MetadataExchangeClient(new EndpointAddress(new Uri("http://schemas.xmlsoap.org/ws/2005/05/identity/issuer/self"), Array.Empty<AddressHeader>()));
      metadataExchangeClient.ResolveMetadataReferences = false;
      lock (_lockObject)
      {
        try
        {
          if (metadataImporter.State != null)
            metadataImporter.State["MetadataExchangeClientKey"] = metadataExchangeClient;
          _importer.ImportPolicy(metadataImporter, context);
        }
        finally
        {
          if (metadataImporter.State != null)
            metadataImporter.State.Remove("MetadataExchangeClientKey");
        }
      }
    }

    private static void RemoveIssuerMetadataForOnline(PolicyConversionContext context)
    {
      var xmlElement1 = context.GetBindingAssertions().Find("SignedSupportingTokens", "http://docs.oasis-open.org/ws-sx/ws-securitypolicy/200702");
      if (xmlElement1 == null)
        return;
      var xmlElement2 = xmlElement1["Policy", "http://schemas.xmlsoap.org/ws/2004/09/policy"];
      if (xmlElement2 == null)
        return;
      var xmlElement3 = xmlElement2["IssuedToken", "http://docs.oasis-open.org/ws-sx/ws-securitypolicy/200702"];
      if (xmlElement3 == null)
        return;
      var xmlElement4 = xmlElement3["Issuer", "http://docs.oasis-open.org/ws-sx/ws-securitypolicy/200702"];
      if (xmlElement4 == null)
        return;
      var xmlElement5 = xmlElement4["Metadata", "http://www.w3.org/2005/08/addressing"];
      if (xmlElement5 != null)
        xmlElement5.InnerText = string.Empty;
      var xmlElement6 = xmlElement4["Address", "http://www.w3.org/2005/08/addressing"];
      if (xmlElement6 == null)
        return;
      xmlElement6.InnerText = "urn://none";
    }
  }
}
