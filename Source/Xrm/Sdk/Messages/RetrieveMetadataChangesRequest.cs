// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.RetrieveMetadataChangesRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Metadata.Query;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveMetadataChangesRequest : OrganizationRequest
  {
    public EntityQueryExpression Query
    {
      get => Parameters.Contains(nameof (Query)) ? (EntityQueryExpression) Parameters[nameof (Query)] : null;
      set => Parameters[nameof (Query)] = value;
    }

    public DeletedMetadataFilters DeletedMetadataFilters
    {
      get => Parameters.Contains(nameof (DeletedMetadataFilters)) ? (DeletedMetadataFilters) Parameters[nameof (DeletedMetadataFilters)] : 0;
      set => Parameters[nameof (DeletedMetadataFilters)] = value;
    }

    public string ClientVersionStamp
    {
      get => Parameters.Contains(nameof (ClientVersionStamp)) ? (string) Parameters[nameof (ClientVersionStamp)] : null;
      set => Parameters[nameof (ClientVersionStamp)] = value;
    }

    public bool RetrieveAllSettings
    {
      get => Parameters.Contains(nameof (RetrieveAllSettings)) && (bool) Parameters[nameof (RetrieveAllSettings)];
      set => Parameters[nameof (RetrieveAllSettings)] = value;
    }

    public RetrieveMetadataChangesRequest() => RequestName = "RetrieveMetadataChanges";
  }
}
