/*
// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ProxyTypesBehavior
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Reflection;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Microsoft.Xrm.Sdk.Client
{
  public sealed class ProxyTypesBehavior : IEndpointBehavior
  {
    private Assembly _proxyTypesAssembly;
    private readonly object _lockObject = new();

    public ProxyTypesBehavior()
    {
    }

    public ProxyTypesBehavior(Assembly proxyTypesAssembly) => _proxyTypesAssembly = proxyTypesAssembly;

    void IEndpointBehavior.AddBindingParameters(
      ServiceEndpoint serviceEndpoint,
      BindingParameterCollection bindingParameters)
    {
    }

    void IEndpointBehavior.ApplyClientBehavior(
      ServiceEndpoint serviceEndpoint,
      ClientRuntime behavior)
    {
      foreach (var operation in serviceEndpoint.Contract.Operations)
        UpdateFormatterBehavior(operation);
    }

    void IEndpointBehavior.ApplyDispatchBehavior(
      ServiceEndpoint serviceEndpoint,
      EndpointDispatcher endpointDispatcher)
    {
    }

    void IEndpointBehavior.Validate(ServiceEndpoint serviceEndpoint)
    {
    }

    private void UpdateFormatterBehavior(OperationDescription operationDescription)
    {
      lock (_lockObject)
      {
        var operationBehavior1 = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
        if (operationBehavior1 != null)
        {
          operationBehavior1.DataContractSurrogate = new ProxySerializationSurrogate(_proxyTypesAssembly);
        }
        else
        {
          var operationBehavior2 = new DataContractSerializerOperationBehavior(operationDescription);
          operationDescription.Behaviors.Add(operationBehavior2);
        }
      }
    }
  }
}
*/
