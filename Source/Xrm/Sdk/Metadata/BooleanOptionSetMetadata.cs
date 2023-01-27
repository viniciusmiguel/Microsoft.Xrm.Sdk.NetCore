// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.BooleanOptionSetMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "BooleanOptionSetMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "BooleanOptionSetMetadata", LogicalCollectionName = "BooleanOptionSetDefinitions")]
  public sealed class BooleanOptionSetMetadata : OptionSetMetadataBase
  {
    private OptionMetadata _trueOption;
    private OptionMetadata _falseOption;

    public BooleanOptionSetMetadata()
    {
    }

    public BooleanOptionSetMetadata(OptionMetadata trueOption, OptionMetadata falseOption)
    {
      TrueOption = trueOption;
      FalseOption = falseOption;
    }

    [DataMember]
    public OptionMetadata TrueOption
    {
      get => _trueOption;
      set => _trueOption = value;
    }

    [DataMember]
    public OptionMetadata FalseOption
    {
      get => _falseOption;
      set => _falseOption = value;
    }
  }
}
