// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.EntityAndAttribute
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  /// <summary>Entity And Attribute mapping for lookup</summary>
  [DataContract(Name = "EntityAndAttribute", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class EntityAndAttribute : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Gets or sets the Entity Logical Name</summary>
    [DataMember]
    public string EntityName { get; set; }

    /// <summary>Gets or sets the Lookup Attribute Logical Name</summary>
    [DataMember]
    public string AttributeName { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
