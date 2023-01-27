// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.AttributeTypeDisplayName
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "AttributeTypeDisplayName", Namespace = "http://schemas.microsoft.com/xrm/2013/Metadata")]
  public sealed class AttributeTypeDisplayName : ConstantsBase<string>
  {
    public static readonly AttributeTypeDisplayName BooleanType = Add<AttributeTypeDisplayName>(nameof (BooleanType));
    public static readonly AttributeTypeDisplayName CustomerType = Add<AttributeTypeDisplayName>(nameof (CustomerType));
    public static readonly AttributeTypeDisplayName DateTimeType = Add<AttributeTypeDisplayName>(nameof (DateTimeType));
    public static readonly AttributeTypeDisplayName DecimalType = Add<AttributeTypeDisplayName>(nameof (DecimalType));
    public static readonly AttributeTypeDisplayName DoubleType = Add<AttributeTypeDisplayName>(nameof (DoubleType));
    public static readonly AttributeTypeDisplayName IntegerType = Add<AttributeTypeDisplayName>(nameof (IntegerType));
    public static readonly AttributeTypeDisplayName LookupType = Add<AttributeTypeDisplayName>(nameof (LookupType));
    public static readonly AttributeTypeDisplayName MemoType = Add<AttributeTypeDisplayName>(nameof (MemoType));
    public static readonly AttributeTypeDisplayName MoneyType = Add<AttributeTypeDisplayName>(nameof (MoneyType));
    public static readonly AttributeTypeDisplayName OwnerType = Add<AttributeTypeDisplayName>(nameof (OwnerType));
    public static readonly AttributeTypeDisplayName PartyListType = Add<AttributeTypeDisplayName>(nameof (PartyListType));
    public static readonly AttributeTypeDisplayName PicklistType = Add<AttributeTypeDisplayName>(nameof (PicklistType));
    public static readonly AttributeTypeDisplayName StateType = Add<AttributeTypeDisplayName>(nameof (StateType));
    public static readonly AttributeTypeDisplayName StatusType = Add<AttributeTypeDisplayName>(nameof (StatusType));
    public static readonly AttributeTypeDisplayName StringType = Add<AttributeTypeDisplayName>(nameof (StringType));
    public static readonly AttributeTypeDisplayName UniqueidentifierType = Add<AttributeTypeDisplayName>(nameof (UniqueidentifierType));
    public static readonly AttributeTypeDisplayName CalendarRulesType = Add<AttributeTypeDisplayName>(nameof (CalendarRulesType));
    public static readonly AttributeTypeDisplayName VirtualType = Add<AttributeTypeDisplayName>(nameof (VirtualType));
    public static readonly AttributeTypeDisplayName BigIntType = Add<AttributeTypeDisplayName>(nameof (BigIntType));
    public static readonly AttributeTypeDisplayName ManagedPropertyType = Add<AttributeTypeDisplayName>(nameof (ManagedPropertyType));
    public static readonly AttributeTypeDisplayName EntityNameType = Add<AttributeTypeDisplayName>(nameof (EntityNameType));
    public static readonly AttributeTypeDisplayName ImageType = Add<AttributeTypeDisplayName>(nameof (ImageType));
    /// <summary>
    /// Attribute type to allow multiple values to be selected on Picklist
    /// </summary>
    public static readonly AttributeTypeDisplayName MultiSelectPicklistType = Add<AttributeTypeDisplayName>(nameof (MultiSelectPicklistType));
    public static readonly AttributeTypeDisplayName FileType = Add<AttributeTypeDisplayName>(nameof (FileType));
    public static readonly AttributeTypeDisplayName CustomType = Add<AttributeTypeDisplayName>(nameof (CustomType));

    [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
    static AttributeTypeDisplayName()
    {
    }

    /// <summary>
    /// Implicity converts a string to AttributeTypeDisplayName
    /// </summary>
    /// <param name="formatName">String value to convert</param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Clients who do not support operator overloading can use the constructor")]
    public static implicit operator AttributeTypeDisplayName(string attributeTypeDisplayName)
    {
      var attributeTypeDisplayName1 = new AttributeTypeDisplayName();
      attributeTypeDisplayName1.Value = attributeTypeDisplayName;
      return attributeTypeDisplayName1;
    }

    protected override bool ValueExistsInList(string value) => ValidValues.Contains<string>(value, StringComparer.OrdinalIgnoreCase);

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (obj is string strB)
        return string.Compare(Value, strB, StringComparison.OrdinalIgnoreCase) == 0;
      var attributeTypeDisplayName = obj as AttributeTypeDisplayName;
      return !(attributeTypeDisplayName == null) && string.Compare(Value, attributeTypeDisplayName.Value, StringComparison.OrdinalIgnoreCase) == 0;
    }

    public static bool operator ==(
      AttributeTypeDisplayName attributeTypeDisplayNameA,
      AttributeTypeDisplayName attributeTypeDisplayNameB)
    {
      if (attributeTypeDisplayNameA == (object) attributeTypeDisplayNameB)
        return true;
      return (object) attributeTypeDisplayNameA != null && (object) attributeTypeDisplayNameB != null && attributeTypeDisplayNameA.Equals(attributeTypeDisplayNameB);
    }

    public static bool operator !=(
      AttributeTypeDisplayName attributeTypeDisplayNameA,
      AttributeTypeDisplayName attributeTypeDisplayNameB)
    {
      return !(attributeTypeDisplayNameA == attributeTypeDisplayNameB);
    }

    public override int GetHashCode() => Value.GetHashCode();
  }
}
