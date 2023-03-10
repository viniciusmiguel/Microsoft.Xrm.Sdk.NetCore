// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.IWebHttpServiceEndpointPlugin
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.ServiceModel;
using System.ServiceModel.Web;

namespace Microsoft.Xrm.Sdk
{
  [ServiceContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public interface IWebHttpServiceEndpointPlugin
  {
    [OperationContract]
    [WebInvoke(Method = "POST")]
    [FaultContract(typeof (ServiceEndpointFault))]
    string Execute(RemoteExecutionContext executionContext);
  }
}
