// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.DiscoveryServiceFault
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Fault contract for IDiscoveryService service contract.
  /// Use the DiscoveryServiceFault contract to handle CRM specific errors in SDK client.
  /// </summary>
  [DataContract(Name = "DiscoveryServiceFault", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [Serializable]
  public sealed class DiscoveryServiceFault : BaseServiceFault
  {
    private DiscoveryServiceFault _innerFault;

    /// <summary>
    /// Gets or sets get the inner exception information that caused the fault
    /// </summary>
    [DataMember]
    public DiscoveryServiceFault InnerFault
    {
      get => _innerFault;
      set => _innerFault = value;
    }

    [IgnoreDataMember]
    internal override BaseServiceFault InnerServiceFault
    {
      get => _innerFault;
      set => _innerFault = (DiscoveryServiceFault) value;
    }
  }
}
