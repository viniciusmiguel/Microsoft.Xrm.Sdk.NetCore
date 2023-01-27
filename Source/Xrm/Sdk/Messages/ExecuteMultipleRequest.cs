// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.ExecuteMultipleRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class ExecuteMultipleRequest : OrganizationRequest
  {
    public OrganizationRequestCollection Requests
    {
      get => Parameters.Contains(nameof (Requests)) ? (OrganizationRequestCollection) Parameters[nameof (Requests)] : null;
      set => Parameters[nameof (Requests)] = value;
    }

    public ExecuteMultipleSettings Settings
    {
      get => Parameters.Contains(nameof (Settings)) ? (ExecuteMultipleSettings) Parameters[nameof (Settings)] : null;
      set => Parameters[nameof (Settings)] = value;
    }

    public ExecuteMultipleRequest()
    {
      RequestName = "ExecuteMultiple";
      Requests = null;
      Settings = null;
    }
  }
}
