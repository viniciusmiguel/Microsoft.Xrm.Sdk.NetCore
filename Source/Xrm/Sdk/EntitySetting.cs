// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.EntitySetting
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "EntitySetting", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class EntitySetting : IExtensibleDataObject
  {
    private string _name;
    private Entity _value;
    private EntitySetting[] _childSettings;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public string Name
    {
      get => _name;
      set => _name = value;
    }

    [DataMember]
    public Entity Value
    {
      get => _value;
      set => _value = value;
    }

    [DataMember]
    public EntitySetting[] ChildSettings
    {
      get => _childSettings;
      set => _childSettings = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
