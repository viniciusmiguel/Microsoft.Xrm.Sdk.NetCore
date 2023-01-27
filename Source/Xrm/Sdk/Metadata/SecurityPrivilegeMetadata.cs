// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.SecurityPrivilegeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "SecurityPrivilegeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  public sealed class SecurityPrivilegeMetadata : IExtensibleDataObject
  {
    private string _name;
    private Guid _privilegeId;
    private PrivilegeType _privilegeType;
    private bool _canBeBasic;
    private bool _canBeLocal;
    private bool _canBeDeep;
    private bool _canBeGlobal;
    private bool _canBeEntityReference;
    private bool _canBeParentEntityReference;
    private ExtensionDataObject _extensionDataObject;

    internal SecurityPrivilegeMetadata()
    {
    }

    [DataMember]
    public bool CanBeBasic
    {
      get => _canBeBasic;
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] internal set => _canBeBasic = value;
    }

    [DataMember]
    public bool CanBeDeep
    {
      get => _canBeDeep;
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] internal set => _canBeDeep = value;
    }

    [DataMember]
    public bool CanBeGlobal
    {
      get => _canBeGlobal;
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] internal set => _canBeGlobal = value;
    }

    [DataMember]
    public bool CanBeLocal
    {
      get => _canBeLocal;
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] internal set => _canBeLocal = value;
    }

    [DataMember]
    public bool CanBeEntityReference
    {
      get => _canBeEntityReference;
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] internal set => _canBeEntityReference = value;
    }

    [DataMember]
    public bool CanBeParentEntityReference
    {
      get => _canBeParentEntityReference;
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] internal set => _canBeParentEntityReference = value;
    }

    [DataMember]
    public string Name
    {
      get => _name;
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] internal set => _name = value;
    }

    [DataMember]
    public Guid PrivilegeId
    {
      get => _privilegeId;
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] internal set => _privilegeId = value;
    }

    [DataMember]
    public PrivilegeType PrivilegeType
    {
      get => _privilegeType;
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] internal set => _privilegeType = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
