// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.CreateEntityRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CreateEntityRequest : OrganizationRequest
  {
    public EntityMetadata Entity
    {
      get => Parameters.Contains(nameof (Entity)) ? (EntityMetadata) Parameters[nameof (Entity)] : null;
      set => Parameters[nameof (Entity)] = value;
    }

    public bool HasActivities
    {
      get => Parameters.Contains(nameof (HasActivities)) && (bool) Parameters[nameof (HasActivities)];
      set => Parameters[nameof (HasActivities)] = value;
    }

    public bool HasNotes
    {
      get => Parameters.Contains(nameof (HasNotes)) && (bool) Parameters[nameof (HasNotes)];
      set => Parameters[nameof (HasNotes)] = value;
    }

    public bool HasFeedback
    {
      get => Parameters.Contains(nameof (HasFeedback)) && (bool) Parameters[nameof (HasFeedback)];
      set => Parameters[nameof (HasFeedback)] = value;
    }

    public StringAttributeMetadata PrimaryAttribute
    {
      get => Parameters.Contains(nameof (PrimaryAttribute)) ? (StringAttributeMetadata) Parameters[nameof (PrimaryAttribute)] : null;
      set => Parameters[nameof (PrimaryAttribute)] = value;
    }

    public string SolutionUniqueName
    {
      get => Parameters.Contains(nameof (SolutionUniqueName)) ? (string) Parameters[nameof (SolutionUniqueName)] : null;
      set => Parameters[nameof (SolutionUniqueName)] = value;
    }

    public CreateEntityRequest()
    {
      RequestName = "CreateEntity";
      Entity = null;
      HasActivities = false;
      HasNotes = false;
      HasFeedback = false;
      PrimaryAttribute = null;
    }
  }
}
