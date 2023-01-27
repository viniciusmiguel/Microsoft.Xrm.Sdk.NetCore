﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.RetrieveAllEntitiesRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveAllEntitiesRequest : OrganizationRequest
  {
    public EntityFilters EntityFilters
    {
      get => Parameters.Contains(nameof (EntityFilters)) ? (EntityFilters) Parameters[nameof (EntityFilters)] : 0;
      set => Parameters[nameof (EntityFilters)] = value;
    }

    public bool RetrieveAsIfPublished
    {
      get => Parameters.Contains(nameof (RetrieveAsIfPublished)) && (bool) Parameters[nameof (RetrieveAsIfPublished)];
      set => Parameters[nameof (RetrieveAsIfPublished)] = value;
    }

    public RetrieveAllEntitiesRequest()
    {
      RequestName = "RetrieveAllEntities";
      EntityFilters = 0;
      RetrieveAsIfPublished = false;
    }
  }
}
