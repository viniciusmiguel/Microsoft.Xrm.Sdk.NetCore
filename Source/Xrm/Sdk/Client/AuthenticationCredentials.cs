// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.AuthenticationCredentials
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.Client
{
  public sealed class AuthenticationCredentials
  {
    private ClientCredentials _clientCredentials = new();

    public Uri AppliesTo { get; set; }

    public Uri HomeRealm { get; set; }

    public string UserPrincipalName { get; set; }

    public ClientCredentials ClientCredentials
    {
      get => _clientCredentials;
      set => _clientCredentials = value;
    }

    public SecurityTokenResponse SecurityTokenResponse { get; set; }

    public AuthenticationCredentials SupportingCredentials { get; set; }

    internal IssuerEndpoint IssuerEndpoint => IssuerEndpoints == null ? null : IssuerEndpoints.GetIssuerEndpoint(EndpointType);

    internal TokenServiceCredentialType EndpointType { get; set; }

    internal string RequestType { get; set; }

    internal string KeyType { get; set; }

    internal IssuerEndpointDictionary IssuerEndpoints { get; set; }
  }
}
