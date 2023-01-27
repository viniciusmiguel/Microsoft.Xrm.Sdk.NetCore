// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.ExecuteTransactionRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class ExecuteTransactionRequest : OrganizationRequest
  {
    public OrganizationRequestCollection Requests
    {
      get => Parameters.Contains(nameof (Requests)) ? (OrganizationRequestCollection) Parameters[nameof (Requests)] : null;
      set => Parameters[nameof (Requests)] = value;
    }

    public bool? ReturnResponses
    {
      get => Parameters.Contains(nameof (ReturnResponses)) ? (bool?) Parameters[nameof (ReturnResponses)] : new bool?();
      set => Parameters[nameof (ReturnResponses)] = value;
    }

    public ExecuteTransactionRequest()
    {
      RequestName = "ExecuteTransaction";
      Requests = null;
    }
  }
}
