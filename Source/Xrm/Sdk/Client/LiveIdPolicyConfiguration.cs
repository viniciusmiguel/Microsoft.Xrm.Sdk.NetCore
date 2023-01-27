// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.LiveIdPolicyConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Security;
using System.Security.Permissions;

namespace Microsoft.Xrm.Sdk.Client
{
  [SecuritySafeCritical]
  [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
  public sealed class LiveIdPolicyConfiguration : OnlinePolicyConfiguration
  {
    internal LiveIdPolicyConfiguration(AuthenticationPolicy xrmPolicy)
      : base(xrmPolicy)
    {
      var trustConfiguration = new LiveIdentityProviderTrustConfiguration(xrmPolicy);
      OnlineProviders.Add(trustConfiguration.Endpoint.GetServiceRoot(), trustConfiguration);
    }
  }
}
