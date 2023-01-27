// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.ReactivateEntityKeyRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class ReactivateEntityKeyRequest : OrganizationRequest
  {
    public string EntityKeyLogicalName
    {
      get => Parameters.Contains(nameof (EntityKeyLogicalName)) ? (string) Parameters[nameof (EntityKeyLogicalName)] : null;
      set => Parameters[nameof (EntityKeyLogicalName)] = value;
    }

    public string EntityLogicalName
    {
      get => Parameters.Contains(nameof (EntityLogicalName)) ? (string) Parameters[nameof (EntityLogicalName)] : null;
      set => Parameters[nameof (EntityLogicalName)] = value;
    }

    public ReactivateEntityKeyRequest()
    {
      RequestName = "ReactivateEntityKey";
      EntityKeyLogicalName = null;
      EntityLogicalName = null;
    }
  }
}
