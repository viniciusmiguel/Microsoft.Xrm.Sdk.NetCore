// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ConstantsBase`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "ConstantsBase", Namespace = "http://schemas.microsoft.com/xrm/2013/Metadata")]
  [KnownType(typeof (DateTimeBehavior))]
  [KnownType(typeof (StringFormatName))]
  [KnownType(typeof (AttributeTypeDisplayName))]
  public abstract class ConstantsBase<T> : IExtensibleDataObject
  {
    protected static readonly IList<T> ValidValues = new List<T>();
    private static readonly object _lock = new();
    private T _value;
    private ExtensionDataObject _extensionDataObject;

    /// <summary>
    /// Represents the current value out of the list of valid values
    /// </summary>
    [DataMember]
    public T Value
    {
      get => _value;
      set => _value = value;
    }

    protected abstract bool ValueExistsInList(T value);

    protected static T2 Create<T2>(T value) where T2 : ConstantsBase<T>, new()
    {
      var obj = new T2();
      obj._value = value;
      return obj;
    }

    protected static T2 Add<T2>(T value) where T2 : ConstantsBase<T>, new()
    {
      lock (_lock)
        ValidValues.Add(value);
      return Create<T2>(value);
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
