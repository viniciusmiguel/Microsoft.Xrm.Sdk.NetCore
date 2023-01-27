// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.StringFormatName
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
  [DataContract(Name = "StringFormatName", Namespace = "http://schemas.microsoft.com/xrm/2013/Metadata")]
  public sealed class StringFormatName : ConstantsBase<string>
  {
    public static readonly StringFormatName Email = Add<StringFormatName>(nameof (Email));
    public static readonly StringFormatName Text = Add<StringFormatName>(nameof (Text));
    public static readonly StringFormatName TextArea = Add<StringFormatName>(nameof (TextArea));
    public static readonly StringFormatName Url = Add<StringFormatName>(nameof (Url));
    public static readonly StringFormatName TickerSymbol = Add<StringFormatName>(nameof (TickerSymbol));
    public static readonly StringFormatName PhoneticGuide = Add<StringFormatName>(nameof (PhoneticGuide));
    public static readonly StringFormatName VersionNumber = Add<StringFormatName>(nameof (VersionNumber));
    public static readonly StringFormatName Phone = Add<StringFormatName>(nameof (Phone));
    public static readonly StringFormatName Json = Add<StringFormatName>(nameof (Json));
    public static readonly StringFormatName RichText = Add<StringFormatName>(nameof (RichText));

    [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
    static StringFormatName()
    {
    }

    /// <summary>Implicity converts a string to StringFormatName</summary>
    /// <param name="formatName">String value to convert</param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Clients who do not support operator overloading can use the constructor")]
    public static implicit operator StringFormatName(string formatName)
    {
      var stringFormatName = new StringFormatName();
      stringFormatName.Value = formatName;
      return stringFormatName;
    }

    protected override bool ValueExistsInList(string value) => ValidValues.Contains<string>(value, StringComparer.OrdinalIgnoreCase);

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (obj is string strB)
        return string.Compare(Value, strB, StringComparison.OrdinalIgnoreCase) == 0;
      var stringFormatName = obj as StringFormatName;
      return !(stringFormatName == null) && string.Compare(Value, stringFormatName.Value, StringComparison.OrdinalIgnoreCase) == 0;
    }

    public static bool operator ==(StringFormatName stringFormatA, StringFormatName stringFormatB)
    {
      if (stringFormatA == (object) stringFormatB)
        return true;
      return (object) stringFormatA != null && (object) stringFormatB != null && stringFormatA.Equals(stringFormatB);
    }

    public static bool operator !=(StringFormatName stringFormatA, StringFormatName stringFormatB) => !(stringFormatA == stringFormatB);

    public override int GetHashCode() => Value.GetHashCode();
  }
}
