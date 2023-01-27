// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.ExecuteTransactionFault
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Fault contract for IOrganizationService service contract.
  /// Use the ExecuteTransactionFault contract to handle ExecuteTransaction Sdk specific errors in SDK client.
  /// </summary>
  [DataContract(Name = "ExecuteTransactionFault", Namespace = "http://schemas.microsoft.com/xrm/7.1/Contracts")]
  [Serializable]
  public sealed class ExecuteTransactionFault : OrganizationServiceFault
  {
    private int _faultedRequestIndex;

    /// <summary>
    /// Gets or sets the zero-based index of the request that failed during execution.
    /// </summary>
    [DataMember]
    public int FaultedRequestIndex
    {
      get => _faultedRequestIndex;
      set => _faultedRequestIndex = value;
    }
  }
}
