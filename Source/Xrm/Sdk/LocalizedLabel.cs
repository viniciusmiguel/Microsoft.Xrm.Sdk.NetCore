// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.LocalizedLabel
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "LocalizedLabel", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [MetadataName(LogicalName = "LocalizedLabel", LogicalCollectionName = "LocalizedLabelDefinitions")]
  public sealed class LocalizedLabel : MetadataBase
  {
    private string _label;
    private int _languageCode;
    private bool? _isManaged;

    public LocalizedLabel()
    {
    }

    public LocalizedLabel(string label, int languageCode)
    {
      Label = label;
      LanguageCode = languageCode;
    }

    [DataMember]
    public string Label
    {
      get => _label;
      set => _label = value;
    }

    [DataMember]
    public int LanguageCode
    {
      get => _languageCode;
      set => _languageCode = value;
    }

    [DataMember]
    public bool? IsManaged
    {
      get => _isManaged;
      internal set => _isManaged = value;
    }
  }
}
