/*
// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceFederatedChannel`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.IdentityModel.Tokens;
using System.Security;
using System.Security.Permissions;
using System.ServiceModel;

namespace Microsoft.Xrm.Sdk.Client
{
  /// <summary>
  /// Class used to manage channels for SDK when claims enabled.
  /// </summary>
  /// <typeparam name="TChannel"></typeparam>
  [SecuritySafeCritical]
  [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
  internal sealed class ServiceFederatedChannel<TChannel> : ServiceChannel<TChannel> where TChannel : class
  {
    private readonly SecurityToken _token;

    public ServiceFederatedChannel(ChannelFactory<TChannel> factory, SecurityToken token)
      : base(factory)
    {
      ClientExceptionHelper.ThrowIfNull(token, nameof (token));
      _token = token;
    }

    [SecuritySafeCritical]
    protected override TChannel CreateChannel() => Factory.CreateChannelWithIssuedToken(_token);
  }
}
*/
