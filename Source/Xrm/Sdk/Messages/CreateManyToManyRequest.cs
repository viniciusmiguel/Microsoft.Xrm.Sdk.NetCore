// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.CreateManyToManyRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CreateManyToManyRequest : OrganizationRequest
  {
    public string IntersectEntitySchemaName
    {
      get => Parameters.Contains(nameof (IntersectEntitySchemaName)) ? (string) Parameters[nameof (IntersectEntitySchemaName)] : null;
      set => Parameters[nameof (IntersectEntitySchemaName)] = value;
    }

    public ManyToManyRelationshipMetadata ManyToManyRelationship
    {
      get => Parameters.Contains(nameof (ManyToManyRelationship)) ? (ManyToManyRelationshipMetadata) Parameters[nameof (ManyToManyRelationship)] : null;
      set => Parameters[nameof (ManyToManyRelationship)] = value;
    }

    public string SolutionUniqueName
    {
      get => Parameters.Contains(nameof (SolutionUniqueName)) ? (string) Parameters[nameof (SolutionUniqueName)] : null;
      set => Parameters[nameof (SolutionUniqueName)] = value;
    }

    public CreateManyToManyRequest()
    {
      RequestName = "CreateManyToMany";
      IntersectEntitySchemaName = null;
      ManyToManyRelationship = null;
    }
  }
}
