// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.DeleteOptionValueRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class DeleteOptionValueRequest : OrganizationRequest
  {
    public string OptionSetName
    {
      get => Parameters.Contains(nameof (OptionSetName)) ? (string) Parameters[nameof (OptionSetName)] : null;
      set => Parameters[nameof (OptionSetName)] = value;
    }

    public string AttributeLogicalName
    {
      get => Parameters.Contains(nameof (AttributeLogicalName)) ? (string) Parameters[nameof (AttributeLogicalName)] : null;
      set => Parameters[nameof (AttributeLogicalName)] = value;
    }

    public string EntityLogicalName
    {
      get => Parameters.Contains(nameof (EntityLogicalName)) ? (string) Parameters[nameof (EntityLogicalName)] : null;
      set => Parameters[nameof (EntityLogicalName)] = value;
    }

    public int Value
    {
      get => Parameters.Contains(nameof (Value)) ? (int) Parameters[nameof (Value)] : 0;
      set => Parameters[nameof (Value)] = value;
    }

    public string SolutionUniqueName
    {
      get => Parameters.Contains(nameof (SolutionUniqueName)) ? (string) Parameters[nameof (SolutionUniqueName)] : null;
      set => Parameters[nameof (SolutionUniqueName)] = value;
    }

    public DeleteOptionValueRequest()
    {
      RequestName = "DeleteOptionValue";
      Value = 0;
    }
  }
}
