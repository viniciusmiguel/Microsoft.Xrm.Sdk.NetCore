// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.MemoFormatName
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
  [DataContract(Name = "MemoFormatName", Namespace = "http://schemas.microsoft.com/xrm/9.0/Metadata")]
  public sealed class MemoFormatName : ConstantsBase<string>
  {
    public static readonly MemoFormatName Text = Add<MemoFormatName>(nameof (Text));
    public static readonly MemoFormatName Email = Add<MemoFormatName>(nameof (Email));
    public static readonly MemoFormatName TextArea = Add<MemoFormatName>(nameof (TextArea));
    public static readonly MemoFormatName Json = Add<MemoFormatName>(nameof (Json));
    public static readonly MemoFormatName RichText = Add<MemoFormatName>(nameof (RichText));

    [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
    static MemoFormatName()
    {
    }

    /// <summary>Implicity converts a string to MemoFormatName</summary>
    /// <param name="formatName">String value to convert</param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Clients who do not support operator overloading can use the constructor")]
    public static implicit operator MemoFormatName(string formatName)
    {
      var memoFormatName = new MemoFormatName();
      memoFormatName.Value = formatName;
      return memoFormatName;
    }

    protected override bool ValueExistsInList(string value) => ValidValues.Contains<string>(value, StringComparer.OrdinalIgnoreCase);

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (obj is string strB)
        return string.Compare(Value, strB, StringComparison.OrdinalIgnoreCase) == 0;
      var memoFormatName = obj as MemoFormatName;
      return !(memoFormatName == null) && string.Compare(Value, memoFormatName.Value, StringComparison.OrdinalIgnoreCase) == 0;
    }

    public static bool operator ==(MemoFormatName stringFormatA, MemoFormatName stringFormatB)
    {
      if (stringFormatA == (object) stringFormatB)
        return true;
      return (object) stringFormatA != null && (object) stringFormatB != null && stringFormatA.Equals(stringFormatB);
    }

    public static bool operator !=(MemoFormatName stringFormatA, MemoFormatName stringFormatB) => !(stringFormatA == stringFormatB);

    public override int GetHashCode() => Value.GetHashCode();
  }
}
