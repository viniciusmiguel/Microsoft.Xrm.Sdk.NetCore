// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.OptionMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "OptionMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [KnownType(typeof (StateOptionMetadata))]
  [KnownType(typeof (StatusOptionMetadata))]
  [MetadataName(LogicalName = "OptionMetadata", LogicalCollectionName = "OptionDefinitions")]
  public class OptionMetadata : MetadataBase
  {
    private int? _optionValue;
    private Label _label;
    private Label _description;
    private string _color;
    private bool? _isManaged;
    private int[] _parentValues;
    private string _externalValue;

    public OptionMetadata() => _externalValue = string.Empty;

    public OptionMetadata(int value)
      : this()
    {
      Value = new int?(value);
    }

    public OptionMetadata(int value, IEnumerable<int> parentOptionValues)
      : this(null, new int?(value), parentOptionValues)
    {
    }

    public OptionMetadata(Label label, int? value)
    {
      Label = label;
      Value = value;
    }

    public OptionMetadata(Label label, int? value, IEnumerable<int> parentOptionValues)
    {
      Label = label;
      Value = value;
      _externalValue = string.Empty;
      if (parentOptionValues == null)
        return;
      if (!(parentOptionValues is int[] numArray))
        numArray = parentOptionValues.ToArray<int>();
      ParentValues = numArray;
    }

    [DataMember]
    public int? Value
    {
      get => _optionValue;
      set => _optionValue = value;
    }

    [DataMember]
    public Label Label
    {
      get => _label;
      set => _label = value;
    }

    [DataMember]
    public Label Description
    {
      get => _description;
      set => _description = value;
    }

    [DataMember]
    public string Color
    {
      get => _color;
      set => _color = value;
    }

    [DataMember]
    public bool? IsManaged
    {
      get => _isManaged;
      internal set => _isManaged = value;
    }

    [DataMember]
    public string ExternalValue
    {
      get => _externalValue;
      set => _externalValue = value;
    }

    [DataMember(Order = 91)]
    public int[] ParentValues
    {
      get => _parentValues;
      set => _parentValues = value;
    }
  }
}
