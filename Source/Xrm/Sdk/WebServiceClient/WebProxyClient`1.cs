// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.WebServiceClient.WebProxyClient`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Client;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.WebServiceClient
{
  [SuppressMessage("Microsoft.CodeQuality.Analyzers", "CA1063: Implement IDisposable correctly", Justification = "FxCop Bankruptcy")]
  public abstract class WebProxyClient<TService> : ClientBase<TService>, IDisposable where TService : class
  {
    private string _xrmSdkAssemblyFileVersion;

    protected WebProxyClient(Uri serviceUrl, bool useStrongTypes)
      : base(CreateServiceEndpoint(serviceUrl, useStrongTypes, Utilites.DefaultTimeout, null))
    {
    }

    protected WebProxyClient(Uri serviceUrl, Assembly strongTypeAssembly)
      : base(CreateServiceEndpoint(serviceUrl, true, Utilites.DefaultTimeout, strongTypeAssembly))
    {
    }

    protected WebProxyClient(Uri serviceUrl, TimeSpan timeout, bool useStrongTypes)
      : base(CreateServiceEndpoint(serviceUrl, useStrongTypes, timeout, null))
    {
    }

    protected WebProxyClient(Uri serviceUrl, TimeSpan timeout, Assembly strongTypeAssembly)
      : base(CreateServiceEndpoint(serviceUrl, true, timeout, strongTypeAssembly))
    {
    }

    public string HeaderToken { get; set; }

    public string SdkClientVersion { get; set; }

    internal string ClientAppName { get; set; }

    internal string ClientAppVersion { get; set; }

    protected abstract WebProxyClientContextInitializer<TService> CreateNewInitializer();

    internal void ExecuteAction(Action action)
    {
      if (action == null)
        throw new ArgumentNullException(nameof (action));
      using (CreateNewInitializer())
        action();
    }

    internal TResult ExecuteAction<TResult>(Func<TResult> action)
    {
      if (action == null)
        throw new ArgumentNullException(nameof (action));
      using (CreateNewInitializer())
        return action();
    }

    protected static ServiceEndpoint CreateServiceEndpoint(
      Uri serviceUrl,
      bool useStrongTypes,
      TimeSpan timeout,
      Assembly strongTypeAssembly)
    {
      var baseServiceEndpoint = CreateBaseServiceEndpoint(serviceUrl, timeout);
      if (baseServiceEndpoint.EndpointBehaviors.Contains(typeof (ProxyTypesBehavior)))
      {
        var endpointBehavior = baseServiceEndpoint.EndpointBehaviors[typeof (ProxyTypesBehavior)];
        if (endpointBehavior != null)
          baseServiceEndpoint.EndpointBehaviors.Remove(endpointBehavior);
      }
      if (useStrongTypes)
        baseServiceEndpoint.EndpointBehaviors.Add(strongTypeAssembly != null ? new ProxyTypesBehavior(strongTypeAssembly) : (IEndpointBehavior) new ProxyTypesBehavior());
      return baseServiceEndpoint;
    }

    private static ServiceEndpoint CreateBaseServiceEndpoint(Uri serviceUrl, TimeSpan timeout)
    {
      var binding = GetBinding(serviceUrl, timeout);
      var address = new EndpointAddress(serviceUrl, Array.Empty<AddressHeader>());
      var baseServiceEndpoint = new ServiceEndpoint(ContractDescription.GetContract(typeof (TService)), binding, address);
      foreach (var operation in baseServiceEndpoint.Contract.Operations)
      {
        var operationBehavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
        if (operationBehavior != null)
          operationBehavior.MaxItemsInObjectGraph = int.MaxValue;
      }
      return baseServiceEndpoint;
    }

    protected static Binding GetBinding(Uri serviceUrl, TimeSpan timeout)
    {
      var binding = new BasicHttpBinding(serviceUrl.Scheme == "https" ? BasicHttpSecurityMode.Transport : BasicHttpSecurityMode.TransportCredentialOnly);
      binding.MaxReceivedMessageSize = int.MaxValue;
      binding.MaxBufferSize = int.MaxValue;
      binding.SendTimeout = timeout;
      binding.ReceiveTimeout = timeout;
      binding.OpenTimeout = timeout;
      binding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
      binding.ReaderQuotas.MaxArrayLength = int.MaxValue;
      binding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
      binding.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;
      return binding;
    }

    /// <summary>
    ///     Get's the file version of the Xrm Sdk assembly that is loaded in the current client domain.
    ///     For Sdk clients called via the OrganizationServiceProxy this is the version of the local Microsoft.Xrm.Sdk dll used
    ///     by the Client App.
    /// </summary>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Security", "CA2143:TransparentMethodsShouldNotDemandFxCopRule")]
    [SuppressMessage("Microsoft.Security", "CA2141:TransparentMethodsMustNotSatisfyLinkDemandsFxCopRule")]
    [PermissionSet(SecurityAction.Demand, Unrestricted = true)]
    internal string GetXrmSdkAssemblyFileVersion()
    {
      if (string.IsNullOrEmpty(_xrmSdkAssemblyFileVersion))
      {
        var strArray = new string[1]
        {
          "Microsoft.Xrm.Sdk.dll"
        };
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var str in strArray)
        {
          foreach (var assembly in assemblies)
          {
            if (assembly.ManifestModule.Name.Equals(str, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(assembly.Location) && File.Exists(assembly.Location))
            {
              _xrmSdkAssemblyFileVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
              break;
            }
          }
        }
      }
      if (string.IsNullOrEmpty(_xrmSdkAssemblyFileVersion))
        _xrmSdkAssemblyFileVersion = "9.1.2.3";
      return _xrmSdkAssemblyFileVersion;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
    }

    ~WebProxyClient() => Dispose(false);
  }
}
