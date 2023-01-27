// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.LookupView
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  /// <summary>Lookup View</summary>
  [DataContract(Name = "LookupView", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class LookupView : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>The View Id</summary>
    [DataMember]
    public Guid? ViewId { get; set; }

    /// <summary>The View Name</summary>
    [DataMember]
    public string ViewName { get; set; }

    /// <summary>The View Columns</summary>
    [DataMember]
    public ViewColumn[] Columns { get; set; }

    /// <summary>The Fetch Xml</summary>
    [DataMember]
    public string FetchXml { get; set; }

    /// <summary>The Layout Json</summary>
    [DataMember]
    public string LayoutJson { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
