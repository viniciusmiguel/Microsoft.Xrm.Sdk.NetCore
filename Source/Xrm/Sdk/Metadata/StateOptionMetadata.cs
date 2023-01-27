// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.StateOptionMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  /// <summary>
  /// StateOption represents the name/value combination that can
  /// be used for state values. In addition to the base Option
  /// info, StateOption has an extra field indicating what the default
  /// status for this state is.
  /// </summary>
  [DataContract(Name = "StateOptionMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "StateOptionMetadata", LogicalCollectionName = "StateOptionDefinitions")]
  public sealed class StateOptionMetadata : OptionMetadata
  {
    private int? _defaultStatus;
    private string _invariantName;

    [DataMember]
    public int? DefaultStatus
    {
      get => _defaultStatus;
      set => _defaultStatus = value;
    }

    [DataMember]
    public string InvariantName
    {
      get => _invariantName;
      set => _invariantName = value;
    }
  }
}
