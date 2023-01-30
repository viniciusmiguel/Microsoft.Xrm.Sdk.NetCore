/*
// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.LiveIdentityProviderTrustConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Security;
using System.Security.Permissions;

namespace Microsoft.Xrm.Sdk.Client
{
  [SecuritySafeCritical]
  [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
  public sealed class LiveIdentityProviderTrustConfiguration : IdentityProviderTrustConfiguration
  {
    internal LiveIdentityProviderTrustConfiguration(AuthenticationPolicy xrmPolicy)
      : base(xrmPolicy)
    {
      AppliesTo = PolicyHelper.GetPolicyValue(XrmPolicy, "AppliesTo", string.Empty);
      Policy = PolicyHelper.GetPolicyValue(XrmPolicy, "LiveTrustLivePolicy", LiveIdAuthenticationConfiguration.DefaultPolicy);
      LiveIdAppliesTo = PolicyHelper.GetPolicyValue(XrmPolicy, "LiveIdAppliesTo", "http://Passport.NET/tb");
    }

    public override Uri Endpoint
    {
      get
      {
        var policyValue = PolicyHelper.GetPolicyValue(XrmPolicy, "LiveEndpoint", null);
        return !string.IsNullOrWhiteSpace(policyValue) ? new Uri(policyValue) : null;
      }
    }
  }
}
*/
