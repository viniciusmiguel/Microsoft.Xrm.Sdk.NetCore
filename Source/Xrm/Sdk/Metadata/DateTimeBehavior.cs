// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.DateTimeBehavior
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
  [DataContract(Name = "DateTimeBehavior", Namespace = "http://schemas.microsoft.com/xrm/7.1/Metadata")]
  public sealed class DateTimeBehavior : ConstantsBase<string>
  {
    [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "Behavior is immutable")]
    public static readonly DateTimeBehavior UserLocal = Add<DateTimeBehavior>(nameof (UserLocal));
    [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "Behavior is immutable")]
    public static readonly DateTimeBehavior DateOnly = Add<DateTimeBehavior>(nameof (DateOnly));
    [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "Behavior is immutable")]
    public static readonly DateTimeBehavior TimeZoneIndependent = Add<DateTimeBehavior>(nameof (TimeZoneIndependent));

    [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
    static DateTimeBehavior()
    {
    }

    /// <summary>Implicity converts a string to Behavior</summary>
    /// <param name="behavior">String value to convert</param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Clients who do not support operator overloading can use the constructor")]
    public static implicit operator DateTimeBehavior(string behavior)
    {
      var dateTimeBehavior = new DateTimeBehavior();
      dateTimeBehavior.Value = behavior;
      return dateTimeBehavior;
    }

    protected override bool ValueExistsInList(string value) => ValidValues.Contains<string>(value, StringComparer.OrdinalIgnoreCase);

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (obj is string strB)
        return string.Compare(Value, strB, StringComparison.OrdinalIgnoreCase) == 0;
      var dateTimeBehavior = obj as DateTimeBehavior;
      return !(dateTimeBehavior == null) && string.Compare(Value, dateTimeBehavior.Value, StringComparison.OrdinalIgnoreCase) == 0;
    }

    public static bool operator ==(DateTimeBehavior behaviorA, DateTimeBehavior behaviorB)
    {
      if (behaviorA == (object) behaviorB)
        return true;
      return (object) behaviorA != null && (object) behaviorB != null && behaviorA.Equals(behaviorB);
    }

    public static bool operator !=(DateTimeBehavior behaviorA, DateTimeBehavior behaviorB) => !(behaviorA == behaviorB);

    public override int GetHashCode() => Value.GetHashCode();
  }
}
