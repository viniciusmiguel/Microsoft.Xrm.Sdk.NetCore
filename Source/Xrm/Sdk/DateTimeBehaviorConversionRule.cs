// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.DateTimeBehaviorConversionRule
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Class to verify and translate ConversionRule param value from ConvertDateAndTimeBehaviorRequest to the correct type
  /// </summary>
  public sealed class DateTimeBehaviorConversionRule : ConstantsBase<string>
  {
    [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "DateTimeBehaviorConversionRule is immutable")]
    public static readonly DateTimeBehaviorConversionRule SpecificTimeZone = Add<DateTimeBehaviorConversionRule>(nameof (SpecificTimeZone));
    [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "DateTimeBehaviorConversionRule is immutable")]
    public static readonly DateTimeBehaviorConversionRule CreatedByTimeZone = Add<DateTimeBehaviorConversionRule>(nameof (CreatedByTimeZone));
    [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "DateTimeBehaviorConversionRule is immutable")]
    public static readonly DateTimeBehaviorConversionRule OwnerTimeZone = Add<DateTimeBehaviorConversionRule>(nameof (OwnerTimeZone));
    [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "DateTimeBehaviorConversionRule is immutable")]
    public static readonly DateTimeBehaviorConversionRule LastUpdatedByTimeZone = Add<DateTimeBehaviorConversionRule>(nameof (LastUpdatedByTimeZone));

    [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
    static DateTimeBehaviorConversionRule()
    {
    }

    /// <summary>Implicity converts a string to value</summary>
    /// <param name="conversionRule">String value to convert</param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Clients who do not support operator overloading can use the constructor")]
    public static implicit operator DateTimeBehaviorConversionRule(string conversionRule)
    {
      var behaviorConversionRule = new DateTimeBehaviorConversionRule();
      behaviorConversionRule.Value = conversionRule;
      return behaviorConversionRule;
    }

    protected override bool ValueExistsInList(string value) => ValidValues.Contains<string>(value, StringComparer.OrdinalIgnoreCase);

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (obj is string strB)
        return string.Compare(Value, strB, StringComparison.OrdinalIgnoreCase) == 0;
      var behaviorConversionRule = obj as DateTimeBehaviorConversionRule;
      return !(behaviorConversionRule == null) && string.Compare(Value, behaviorConversionRule.Value, StringComparison.OrdinalIgnoreCase) == 0;
    }

    public static bool operator ==(
      DateTimeBehaviorConversionRule conversionRuleA,
      DateTimeBehaviorConversionRule conversionRuleB)
    {
      if (conversionRuleA == (object) conversionRuleB)
        return true;
      return (object) conversionRuleA != null && (object) conversionRuleB != null && conversionRuleA.Equals(conversionRuleB);
    }

    public static bool operator !=(
      DateTimeBehaviorConversionRule conversionRuleA,
      DateTimeBehaviorConversionRule conversionRuleB)
    {
      return !(conversionRuleA == conversionRuleB);
    }

    public override int GetHashCode() => Value.GetHashCode();
  }
}
