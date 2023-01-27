// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.CanBeReferencingRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CanBeReferencingRequest : OrganizationRequest
  {
    public string EntityName
    {
      get => Parameters.Contains(nameof (EntityName)) ? (string) Parameters[nameof (EntityName)] : null;
      set => Parameters[nameof (EntityName)] = value;
    }

    public CanBeReferencingRequest()
    {
      RequestName = "CanBeReferencing";
      EntityName = null;
    }
  }
}
