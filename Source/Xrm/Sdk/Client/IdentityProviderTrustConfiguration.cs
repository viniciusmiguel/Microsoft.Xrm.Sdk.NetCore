// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.IdentityProviderTrustConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Crm.Protocols.WSTrust.Bindings;
using System;
using System.Security;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;

namespace Microsoft.Xrm.Sdk.Client
{
  [SecuritySafeCritical]
  [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
  public abstract class IdentityProviderTrustConfiguration
  {
    private TrustVersion _trustVersion = TrustVersion.WSTrustFeb2005;
    private SecurityMode _securityMode = SecurityMode.TransportWithMessageCredential;

    internal AuthenticationPolicy XrmPolicy { get; private set; }

    internal IdentityProviderTrustConfiguration()
    {
    }

    internal IdentityProviderTrustConfiguration(AuthenticationPolicy xrmPolicy) => XrmPolicy = xrmPolicy;

    public abstract Uri Endpoint { get; }

    internal Binding Binding
    {
      get
      {
        var binding = new UserNameWSTrustBinding();
        binding.TrustVersion = _trustVersion;
        binding.SecurityMode = _securityMode;
        return binding;
      }
    }

    public string Policy { get; set; }

    public string LiveIdAppliesTo { get; set; }

    public string AppliesTo { get; set; }

    internal TrustVersion TrustVersion
    {
      get => _trustVersion;
      set => _trustVersion = value;
    }

    internal SecurityMode SecurityMode
    {
      get => _securityMode;
      set => _securityMode = value;
    }
  }
}
