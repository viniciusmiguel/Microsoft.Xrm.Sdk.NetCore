// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Money
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Money</summary>
  [DataContract(Name = "Money", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class Money : IExtensibleDataObject
  {
    private Decimal _value;
    private ExtensionDataObject _extensionDataObject;

    public Money()
    {
    }

    public Money(Decimal value) => _value = value;

    [DataMember]
    public Decimal Value
    {
      get => _value;
      set => _value = value;
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Money money))
        return false;
      return this == money || _value.Equals(money._value);
    }

    public override int GetHashCode() => _value.GetHashCode();

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
