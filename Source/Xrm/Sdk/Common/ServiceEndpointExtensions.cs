// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Common.ServiceEndpointExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.ServiceModel.Description;
using System.Linq;

namespace Microsoft.Xrm.Sdk.Common
{
  internal static class ServiceEndpointExtensions
  {
    public static void AddBehavior(this ServiceEndpoint serviceEndpoint, IEndpointBehavior behavior) 
      => serviceEndpoint.EndpointBehaviors.Add(behavior);

    public static void RemoveBehavior(
      this ServiceEndpoint serviceEndpoint,
      IEndpointBehavior behavior)
    {
      serviceEndpoint.EndpointBehaviors.Remove(behavior);
    }

    public static T FindBehavior<T>(this ServiceEndpoint serviceEndpoint) where T : IEndpointBehavior
      => serviceEndpoint.EndpointBehaviors.; //.Find<T>();
  }
}
