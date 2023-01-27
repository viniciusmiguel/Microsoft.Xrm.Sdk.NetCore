// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ViewColumn
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  /// <summary>View Column</summary>
  [DataContract(Name = "ViewColumn", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class ViewColumn : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>The Entity Logical Name</summary>
    [DataMember]
    public string EntityLogicalName { get; set; }

    /// <summary>The Attribute Logical Name</summary>
    [DataMember]
    public string AttributeLogicalName { get; set; }

    /// <summary>The Data Type</summary>
    [DataMember]
    public string DataType { get; set; }

    /// <summary>The Format</summary>
    [DataMember]
    public string Format { get; set; }

    /// <summary>The alias</summary>
    [DataMember]
    public string Alias { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
