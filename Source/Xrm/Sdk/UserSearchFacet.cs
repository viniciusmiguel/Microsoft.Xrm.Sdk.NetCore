// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.UserSearchFacet
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "UserSearchFacet", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  [Serializable]
  public sealed class UserSearchFacet : IExtensibleDataObject
  {
    private string attributeLogicalName;
    private string attributeTypeName;
    private string attributeDisplayName;
    private int facetOrder;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    public UserSearchFacet()
    {
    }

    public UserSearchFacet(
      string attributeLogicalName,
      string attributeTypeName,
      string attributeDisplayName,
      int facetOrder)
    {
      this.attributeLogicalName = attributeLogicalName;
      this.attributeTypeName = attributeTypeName;
      this.attributeDisplayName = attributeDisplayName;
      this.facetOrder = facetOrder;
    }

    [DataMember]
    public string AttributeLogicalName
    {
      get => attributeLogicalName;
      internal set => attributeLogicalName = value;
    }

    [DataMember]
    public string AttributeTypeName
    {
      get => attributeTypeName;
      internal set => attributeTypeName = value;
    }

    [DataMember]
    public string AttributeDisplayName
    {
      get => attributeDisplayName;
      internal set => attributeDisplayName = value;
    }

    [DataMember]
    public int FacetOrder
    {
      get => facetOrder;
      internal set => facetOrder = value;
    }

    ExtensionDataObject IExtensibleDataObject.ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
