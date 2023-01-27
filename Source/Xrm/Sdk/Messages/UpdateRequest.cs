﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.UpdateRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class UpdateRequest : OrganizationRequest
  {
    public Entity Target
    {
      get => Parameters.Contains(nameof (Target)) ? (Entity) Parameters[nameof (Target)] : null;
      set => Parameters[nameof (Target)] = value;
    }

    public ConcurrencyBehavior ConcurrencyBehavior
    {
      get => Parameters.Contains(nameof (ConcurrencyBehavior)) ? (ConcurrencyBehavior) Parameters[nameof (ConcurrencyBehavior)] : ConcurrencyBehavior.Default;
      set => Parameters[nameof (ConcurrencyBehavior)] = value;
    }

    public UpdateRequest()
    {
      RequestName = "Update";
      Target = null;
    }
  }
}
