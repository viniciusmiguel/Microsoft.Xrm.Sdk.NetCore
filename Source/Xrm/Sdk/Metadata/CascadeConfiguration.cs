// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.CascadeConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "CascadeConfiguration", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  public sealed class CascadeConfiguration : IExtensibleDataObject
  {
    private CascadeType? _cascadeAssign;
    private CascadeType? _cascadeDelete;
    private CascadeType? _cascadeMerge;
    private CascadeType? _cascadeReparent;
    private CascadeType? _cascadeShare;
    private CascadeType? _cascadeUnshare;
    private CascadeType? _cascadeRollupView;
    private CascadeType? _cascadeArchive;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public CascadeType? Assign
    {
      get => _cascadeAssign;
      set => _cascadeAssign = value;
    }

    [DataMember]
    public CascadeType? Delete
    {
      get => _cascadeDelete;
      set => _cascadeDelete = value;
    }

    [DataMember]
    public CascadeType? Archive
    {
      get => _cascadeArchive;
      set => _cascadeArchive = value;
    }

    [DataMember]
    public CascadeType? Merge
    {
      get => _cascadeMerge;
      set => _cascadeMerge = value;
    }

    [DataMember]
    public CascadeType? Reparent
    {
      get => _cascadeReparent;
      set => _cascadeReparent = value;
    }

    [DataMember]
    public CascadeType? Share
    {
      get => _cascadeShare;
      set => _cascadeShare = value;
    }

    [DataMember]
    public CascadeType? Unshare
    {
      get => _cascadeUnshare;
      set => _cascadeUnshare = value;
    }

    [DataMember(Order = 82)]
    public CascadeType? RollupView
    {
      get => _cascadeRollupView;
      set => _cascadeRollupView = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
