// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.ConvertDateAndTimeBehaviorRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class ConvertDateAndTimeBehaviorRequest : OrganizationRequest
  {
    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "This is required to set the collection from the Client.", MessageId = "")]
    public EntityAttributeCollection Attributes
    {
      get => Parameters.Contains(nameof (Attributes)) ? (EntityAttributeCollection) Parameters[nameof (Attributes)] : null;
      set => Parameters[nameof (Attributes)] = value;
    }

    public string ConversionRule
    {
      get => Parameters.Contains(nameof (ConversionRule)) ? (string) Parameters[nameof (ConversionRule)] : null;
      set => Parameters[nameof (ConversionRule)] = value;
    }

    public int TimeZoneCode
    {
      get => Parameters.Contains(nameof (TimeZoneCode)) ? (int) Parameters[nameof (TimeZoneCode)] : 0;
      set => Parameters[nameof (TimeZoneCode)] = value;
    }

    public bool AutoConvert
    {
      get => Parameters.Contains(nameof (AutoConvert)) && (bool) Parameters[nameof (AutoConvert)];
      set => Parameters[nameof (AutoConvert)] = value;
    }

    public ConvertDateAndTimeBehaviorRequest()
    {
      RequestName = "ConvertDateAndTimeBehavior";
      AutoConvert = true;
      Attributes = null;
    }
  }
}
