// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.RetrieveEntityChangesRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveEntityChangesRequest : OrganizationRequest
  {
    public string EntityName
    {
      get => Parameters.Contains(nameof (EntityName)) ? (string) Parameters[nameof (EntityName)] : null;
      set => Parameters[nameof (EntityName)] = value;
    }

    public string DataVersion
    {
      get => Parameters.Contains(nameof (DataVersion)) ? (string) Parameters[nameof (DataVersion)] : null;
      set => Parameters[nameof (DataVersion)] = value;
    }

    public PagingInfo PageInfo
    {
      get => Parameters.Contains(nameof (PageInfo)) ? (PagingInfo) Parameters[nameof (PageInfo)] : null;
      set => Parameters[nameof (PageInfo)] = value;
    }

    public ColumnSet Columns
    {
      get => Parameters.Contains(nameof (Columns)) ? (ColumnSet) Parameters[nameof (Columns)] : null;
      set => Parameters[nameof (Columns)] = value;
    }

    /// <summary>
    /// If GetGlobalMetadataVersion = true,
    /// global CRM metadata version is added
    /// to RetrievEntityChanges API response
    /// </summary>
    public bool GetGlobalMetadataVersion
    {
      get => Parameters.Contains(nameof (GetGlobalMetadataVersion)) && (bool) Parameters[nameof (GetGlobalMetadataVersion)];
      set => Parameters[nameof (GetGlobalMetadataVersion)] = value;
    }

    public RetrieveEntityChangesRequest()
    {
      RequestName = "RetrieveEntityChanges";
      EntityName = null;
      DataVersion = null;
      PageInfo = null;
      Columns = null;
    }
  }
}
