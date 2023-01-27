// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.OnlineFederationPolicyConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Linq;
using System.Security;
using System.Security.Permissions;

namespace Microsoft.Xrm.Sdk.Client
{
  /// <summary>
  /// Used to manage the LiveFederation configuration.  In this configuration, we will have a true STS, but must be able to talk to
  /// MFG for initial authentication when not using HomeRealmUrl.
  /// </summary>
  [SecuritySafeCritical]
  [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
  public sealed class OnlineFederationPolicyConfiguration : OnlinePolicyConfiguration
  {
    private object _lockObject = new();

    internal OnlineFederationPolicyConfiguration(AuthenticationPolicy xrmPolicy)
      : base(xrmPolicy)
    {
      if (!string.IsNullOrEmpty(PolicyHelper.GetPolicyValue(xrmPolicy, "LiveTrustLivePolicy", string.Empty)))
      {
        var trustConfiguration = new LiveIdentityProviderTrustConfiguration(xrmPolicy);
        OnlineProviders.Add(trustConfiguration.Endpoint.GetServiceRoot(), trustConfiguration);
      }
      if (string.IsNullOrEmpty(PolicyHelper.GetPolicyValue(xrmPolicy, "OrgIdPolicy", string.Empty)))
        return;
      var trustConfiguration1 = new OrgIdentityProviderTrustConfiguration(xrmPolicy);
      OnlineProviders.Add(trustConfiguration1.Endpoint.GetServiceRoot(), trustConfiguration1);
    }

    internal void InitializeLiveTrustConfiguration(IdentityProvider identityProvider)
    {
      var trustConfiguration1 = OnlineProviders.Values.OfType<OrgIdentityProviderTrustConfiguration>().FirstOrDefault<OrgIdentityProviderTrustConfiguration>();
      if (trustConfiguration1 == null || string.IsNullOrWhiteSpace(trustConfiguration1.LivePartnerIdentifier) || OnlineProviders.Values.OfType<LiveIdentityProviderTrustConfiguration>().Any<LiveIdentityProviderTrustConfiguration>())
        return;
      lock (_lockObject)
      {
        if (OnlineProviders.Values.OfType<LiveIdentityProviderTrustConfiguration>().Any<LiveIdentityProviderTrustConfiguration>())
          return;
        var xrmPolicy = new AuthenticationPolicy();
        xrmPolicy.PolicyElements.Add("AppliesTo", trustConfiguration1.LivePartnerIdentifier);
        var absoluteUri = identityProvider.ServiceUrl.AbsoluteUri;
        xrmPolicy.PolicyElements["LiveEndpoint"] = absoluteUri;
        var trustConfiguration2 = new LiveIdentityProviderTrustConfiguration(xrmPolicy);
        OnlineProviders.Add(new Uri(absoluteUri), trustConfiguration2);
      }
    }
  }
}
