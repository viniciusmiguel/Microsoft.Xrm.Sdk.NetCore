// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.LookupAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "LookupAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "LookupAttributeMetadata", LogicalCollectionName = "LookupAttributeDefinitions")]
  public sealed class LookupAttributeMetadata : AttributeMetadata
  {
    private string[] _targets;

    public LookupAttributeMetadata()
      : this(new LookupFormat?())
    {
    }

    public LookupAttributeMetadata(LookupFormat? format)
      : base(AttributeTypeCode.Lookup)
    {
      Format = format;
    }

    [DataMember]
    public string[] Targets
    {
      get => _targets;
      set => _targets = value;
    }

    [DataMember]
    public LookupFormat? Format { get; set; }
  }
}
