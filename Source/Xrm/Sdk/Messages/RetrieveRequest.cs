// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.RetrieveRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveRequest : OrganizationRequest
  {
    public EntityReference Target
    {
      get => Parameters.Contains(nameof (Target)) ? (EntityReference) Parameters[nameof (Target)] : null;
      set => Parameters[nameof (Target)] = value;
    }

    public ColumnSet ColumnSet
    {
      get => Parameters.Contains(nameof (ColumnSet)) ? (ColumnSet) Parameters[nameof (ColumnSet)] : null;
      set => Parameters[nameof (ColumnSet)] = value;
    }

    public RelationshipQueryCollection RelatedEntitiesQuery
    {
      get => Parameters.Contains(nameof (RelatedEntitiesQuery)) ? (RelationshipQueryCollection) Parameters[nameof (RelatedEntitiesQuery)] : null;
      set => Parameters[nameof (RelatedEntitiesQuery)] = value;
    }

    public bool ReturnNotifications
    {
      get => Parameters.Contains(nameof (ReturnNotifications)) && (bool) Parameters[nameof (ReturnNotifications)];
      set => Parameters[nameof (ReturnNotifications)] = value;
    }

    public RetrieveRequest()
    {
      RequestName = "Retrieve";
      Target = null;
      ColumnSet = null;
    }
  }
}
