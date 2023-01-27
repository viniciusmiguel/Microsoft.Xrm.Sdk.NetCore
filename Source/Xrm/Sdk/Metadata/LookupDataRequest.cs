// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.LookupDataRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  /// <summary>Lookup Data Request</summary>
  [DataContract(Name = "LookupDataRequest", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class LookupDataRequest : IExtensibleDataObject
  {
    private LookupEntityInfo[] _lookupEntityByName;
    private EntityAndAttribute _entityAndAttribute;
    private ExtensionDataObject _extensionDataObject;

    /// <summary>The look up entity by name</summary>
    [DataMember]
    public LookupEntityInfo[] LookupEntityByName
    {
      get => _lookupEntityByName;
      set => _lookupEntityByName = value;
    }

    /// <summary>
    /// The Entity And Attribute to get the realted entity for lookup search
    /// </summary>
    [DataMember]
    public EntityAndAttribute EntityAndAttribute
    {
      get
      {
        if (_entityAndAttribute == null)
          _entityAndAttribute = new EntityAndAttribute();
        return _entityAndAttribute;
      }
      set => _entityAndAttribute = value;
    }

    /// <summary>The App module id</summary>
    [DataMember]
    public Guid? AppId { get; set; }

    /// <summary>The Related Record Id</summary>
    [DataMember]
    public Guid? RelatedRecordId { get; set; }

    /// <summary>The Query String</summary>
    [DataMember]
    public string QueryString { get; set; }

    /// <summary>
    /// The Return Metadata
    /// If its passed as true we will return related metadata in the response also
    /// Otherwise only data will be returned
    /// </summary>
    [DataMember]
    public bool ReturnMetadata { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
