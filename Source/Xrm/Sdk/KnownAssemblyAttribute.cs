// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.KnownAssemblyAttribute
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Microsoft.Xrm.Sdk
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
  internal sealed class KnownAssemblyAttribute : Attribute, IContractBehavior
  {
    private KnownTypesResolver resolver;

    public KnownAssemblyAttribute() => resolver = new KnownTypesResolver();

    public void AddBindingParameters(
      ContractDescription contractDescription,
      ServiceEndpoint endpoint,
      BindingParameterCollection bindingParameters)
    {
    }

    public void ApplyClientBehavior(
      ContractDescription contractDescription,
      ServiceEndpoint endpoint,
      ClientRuntime clientRuntime)
    {
      CreateMyDataContractSerializerOperationBehaviors(contractDescription);
    }

    public void ApplyDispatchBehavior(
      ContractDescription contractDescription,
      ServiceEndpoint endpoint,
      DispatchRuntime dispatchRuntime)
    {
      CreateMyDataContractSerializerOperationBehaviors(contractDescription);
    }

    public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
    {
    }

    private void CreateMyDataContractSerializerOperationBehaviors(
      ContractDescription contractDescription)
    {
      foreach (var operation in contractDescription.Operations)
        CreateMyDataContractSerializerOperationBehavior(operation);
    }

    private void CreateMyDataContractSerializerOperationBehavior(OperationDescription operation)
    {
      var operationBehavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
      if (operationBehavior == null)
        return;
      operationBehavior.DataContractResolver = resolver;
    }
  }
}
