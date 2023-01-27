﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.CreateCustomerRelationshipsRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/8.1/Contracts")]
  public sealed class CreateCustomerRelationshipsRequest : OrganizationRequest
  {
    public LookupAttributeMetadata Lookup
    {
      get => Parameters.Contains(nameof (Lookup)) ? (LookupAttributeMetadata) Parameters[nameof (Lookup)] : null;
      set => Parameters[nameof (Lookup)] = value;
    }

    public OneToManyRelationshipMetadata[] OneToManyRelationships
    {
      get => Parameters.Contains(nameof (OneToManyRelationships)) ? (OneToManyRelationshipMetadata[]) Parameters[nameof (OneToManyRelationships)] : null;
      set => Parameters[nameof (OneToManyRelationships)] = value;
    }

    public string SolutionUniqueName
    {
      get => Parameters.Contains(nameof (SolutionUniqueName)) ? (string) Parameters[nameof (SolutionUniqueName)] : null;
      set => Parameters[nameof (SolutionUniqueName)] = value;
    }

    public CreateCustomerRelationshipsRequest()
    {
      RequestName = "CreateCustomerRelationships";
      Lookup = null;
      OneToManyRelationships = null;
    }
  }
}
