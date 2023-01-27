// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.AuthenticationHelpers
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.Client
{
  /// <summary>
  /// Provides helper methods for generalized authentication context querying
  /// </summary>
  public static class AuthenticationHelpers
  {
    /// <summary>
    /// /// This method is deprecated and will always return false.
    /// </summary>
    /// <typeparam name="TService">The service contract type</typeparam>
    /// <param name="serviceConfiguration">The serviceConfiguration interface instance</param>
    /// <param name="clientCredentials">The client credentials passed to the method</param>
    /// <returns></returns>
    internal static bool ShouldAuthenticateWithLiveId<TService>(
      this IServiceManagement<TService> serviceManagement,
      ClientCredentials clientCredentials)
    {
      ClientExceptionHelper.ThrowIfNull(serviceManagement, nameof (serviceManagement));
      ClientExceptionHelper.ThrowIfNull(clientCredentials, nameof (clientCredentials));
      return false;
    }

    /// <summary>
    /// This method is deprecated and will always return false.
    /// </summary>
    /// <typeparam name="TService">The service contract type</typeparam>
    /// <param name="serviceConfiguration">The serviceConfiguration interface instance</param>
    /// <param name="clientCredentials">The client credentials passed to the method</param>
    /// <returns></returns>
    internal static bool ShouldAuthenticateWithLiveId<TService>(
      this IServiceConfiguration<TService> serviceConfiguration,
      ClientCredentials clientCredentials)
    {
      ClientExceptionHelper.ThrowIfNull(serviceConfiguration, nameof (serviceConfiguration));
      ClientExceptionHelper.ThrowIfNull(clientCredentials, nameof (clientCredentials));
      return false;
    }

    /// <summary>
    /// This method is deprecated and will always return false.
    /// </summary>
    /// <typeparam name="TService">The service contract type</typeparam>
    /// <param name="serviceConfiguration">The serviceConfiguration interface instance</param>
    /// <param name="clientCredentials">The client credentials passed to the method</param>
    /// <returns></returns>
    internal static bool ShouldAuthenticateWithLiveId<TService>(
      this ServiceConfiguration<TService> serviceConfiguration,
      ClientCredentials clientCredentials)
    {
      ClientExceptionHelper.ThrowIfNull(serviceConfiguration, nameof (serviceConfiguration));
      ClientExceptionHelper.ThrowIfNull(clientCredentials, nameof (clientCredentials));
      return false;
    }
  }
}
