﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.SecurityTokenResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;

namespace Microsoft.Xrm.Sdk.Client
{
  public sealed class SecurityTokenResponse
  {
    public SecurityToken Token { get; set; }

    public RequestSecurityTokenResponse Response { get; set; }

    public TokenServiceCredentialType EndpointType { get; set; }
  }
}