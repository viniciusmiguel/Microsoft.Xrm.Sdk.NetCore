// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.UpdateOptionSetRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class UpdateOptionSetRequest : OrganizationRequest
  {
    public OptionSetMetadataBase OptionSet
    {
      get => Parameters.Contains(nameof (OptionSet)) ? (OptionSetMetadataBase) Parameters[nameof (OptionSet)] : null;
      set => Parameters[nameof (OptionSet)] = value;
    }

    public bool MergeLabels
    {
      get => Parameters.Contains(nameof (MergeLabels)) && (bool) Parameters[nameof (MergeLabels)];
      set => Parameters[nameof (MergeLabels)] = value;
    }

    public string SolutionUniqueName
    {
      get => Parameters.Contains(nameof (SolutionUniqueName)) ? (string) Parameters[nameof (SolutionUniqueName)] : null;
      set => Parameters[nameof (SolutionUniqueName)] = value;
    }

    public UpdateOptionSetRequest()
    {
      RequestName = "UpdateOptionSet";
      OptionSet = null;
      MergeLabels = false;
    }
  }
}
