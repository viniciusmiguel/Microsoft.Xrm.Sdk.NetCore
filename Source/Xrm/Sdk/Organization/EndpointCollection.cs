// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Organization.EndpointCollection
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Organization
{
  [CollectionDataContract(Name = "EndpointCollection", Namespace = "http://schemas.microsoft.com/xrm/2014/Contracts")]
  public sealed class EndpointCollection : DataCollection<EndpointType, string>
  {
    public static EndpointCollection FromDiscovery(Microsoft.Xrm.Sdk.Discovery.EndpointCollection collection)
    {
      var endpointCollection = new EndpointCollection();
      foreach (var keyValuePair in collection)
        endpointCollection.Add((EndpointType) keyValuePair.Key, keyValuePair.Value);
      return endpointCollection;
    }
  }
}
