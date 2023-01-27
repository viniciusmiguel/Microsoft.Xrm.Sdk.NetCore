// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.ManagedProperty`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Represents an instance of an managed property.</summary>
  [DataContract(Name = "ManagedProperty{0}", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [KnownType(typeof (BooleanManagedProperty))]
  [KnownType(typeof (AttributeRequiredLevel))]
  public abstract class ManagedProperty<T> : IExtensibleDataObject
  {
    private T _value;
    private bool _canBeChanged;
    private string _logicalName;
    private ExtensionDataObject _extensionDataObject;

    protected ManagedProperty()
      : this(null)
    {
    }

    protected ManagedProperty(string managedPropertyLogicalName)
    {
      _logicalName = managedPropertyLogicalName;
      _canBeChanged = true;
    }

    /// <summary>
    /// Value of the attribute that this managed property refers.
    /// </summary>
    [DataMember]
    public T Value
    {
      get => _value;
      set => _value = value;
    }

    /// <summary>
    /// Whether it is valid to change the Value of this managed property.
    /// </summary>
    [DataMember]
    public bool CanBeChanged
    {
      get => _canBeChanged;
      set => _canBeChanged = value;
    }

    /// <summary>The logical name of the managed property definition.</summary>
    [DataMember]
    public string ManagedPropertyLogicalName
    {
      get => _logicalName;
      internal set => _logicalName = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
