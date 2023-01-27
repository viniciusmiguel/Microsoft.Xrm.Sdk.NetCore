// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.GlobalSearchConfigurations
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "GlobalSearchConfigurations", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  [Serializable]
  public sealed class GlobalSearchConfigurations : IExtensibleDataObject
  {
    private string searchProviderName;
    private string searchProviderResultsPage;
    private bool isLocalized;
    private bool isEnabled;
    private bool isSearchBoxVisible;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    public GlobalSearchConfigurations()
    {
    }

    public GlobalSearchConfigurations(
      string searchProviderName,
      string searchProviderResultsPage,
      bool isLocalized,
      bool isEnabled,
      bool isSearchBoxVisible)
    {
      this.searchProviderName = searchProviderName;
      this.searchProviderResultsPage = searchProviderResultsPage;
      this.isLocalized = isLocalized;
      this.isEnabled = isEnabled;
      this.isSearchBoxVisible = isSearchBoxVisible;
    }

    [DataMember]
    public string SearchProviderName
    {
      get => searchProviderName;
      internal set => searchProviderName = value;
    }

    [DataMember]
    public string SearchProviderResultsPage
    {
      get => searchProviderResultsPage;
      internal set => searchProviderResultsPage = value;
    }

    [DataMember]
    public bool IsLocalized
    {
      get => isLocalized;
      internal set => isLocalized = value;
    }

    [DataMember]
    public bool IsEnabled
    {
      get => isEnabled;
      internal set => isEnabled = value;
    }

    [DataMember]
    public bool IsSearchBoxVisible
    {
      get => isSearchBoxVisible;
      internal set => isSearchBoxVisible = value;
    }

    ExtensionDataObject IExtensibleDataObject.ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
