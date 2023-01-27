// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.OptionSetMetadataBase
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "OptionSetMetadataBase", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [KnownType(typeof (OptionSetMetadata))]
  [KnownType(typeof (BooleanOptionSetMetadata))]
  [MetadataName(LogicalName = "OptionSetMetadataBase", LogicalCollectionName = "GlobalOptionSetDefinitions")]
  public abstract class OptionSetMetadataBase : MetadataBase
  {
    private Label _description;
    private Label _displayName;
    private bool? _isCustomOptionSet;
    private bool? _isGlobal;
    private bool? _isManaged;
    private string _name;
    private string _externalTypeName;
    private OptionSetType? _optionSetType;
    private BooleanManagedProperty _isCustomizable;
    private string _introducedVersion;

    [DataMember]
    public Label Description
    {
      get => _description;
      set => _description = value;
    }

    [DataMember]
    public Label DisplayName
    {
      get => _displayName;
      set => _displayName = value;
    }

    [DataMember]
    public bool? IsCustomOptionSet
    {
      get => _isCustomOptionSet;
      set => _isCustomOptionSet = value;
    }

    [DataMember]
    public bool? IsGlobal
    {
      get => _isGlobal;
      set => _isGlobal = value;
    }

    [DataMember]
    public bool? IsManaged
    {
      get => _isManaged;
      internal set => _isManaged = value;
    }

    [DataMember]
    public BooleanManagedProperty IsCustomizable
    {
      get => _isCustomizable;
      set => _isCustomizable = value;
    }

    [DataMember]
    [Alternatekey]
    public string Name
    {
      get => _name;
      set => _name = value;
    }

    [DataMember]
    public string ExternalTypeName
    {
      get => _externalTypeName;
      set => _externalTypeName = value;
    }

    [DataMember]
    public OptionSetType? OptionSetType
    {
      get => _optionSetType;
      set => _optionSetType = value;
    }

    [DataMember(Order = 60)]
    public string IntroducedVersion
    {
      get => _introducedVersion;
      internal set => _introducedVersion = value;
    }
  }
}
