// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Label
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "Label", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class Label : IExtensibleDataObject
  {
    private LocalizedLabelCollection _locLabels;
    private LocalizedLabel _userLocLabel;
    private ExtensionDataObject _extensionDataObject;

    public Label()
    {
    }

    public Label(string label, int languageCode)
    {
      _locLabels = new LocalizedLabelCollection();
      _locLabels.Add(new LocalizedLabel(label, languageCode));
    }

    public Label(LocalizedLabel userLocalizedLabel, LocalizedLabel[] labels)
    {
      _userLocLabel = userLocalizedLabel;
      if (labels == null)
        return;
      _locLabels = new LocalizedLabelCollection(labels);
    }

    public Label(LocalizedLabel userLocalizedLabel, List<LocalizedLabel> labels)
    {
      _userLocLabel = userLocalizedLabel;
      if (labels == null)
        return;
      _locLabels = new LocalizedLabelCollection(labels);
    }

    [DataMember]
    public LocalizedLabelCollection LocalizedLabels
    {
      get
      {
        if (_locLabels == null)
          _locLabels = new LocalizedLabelCollection();
        return _locLabels;
      }
      private set => _locLabels = value;
    }

    [DataMember]
    public LocalizedLabel UserLocalizedLabel
    {
      get => _userLocLabel;
      set => _userLocLabel = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
