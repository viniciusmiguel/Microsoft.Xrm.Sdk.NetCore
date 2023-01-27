// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.ScalarInputParameter
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "ScalarInputParameter", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public class ScalarInputParameter
  {
    public ScalarInputParameter()
    {
    }

    public ScalarInputParameter(string name, string value)
    {
      Name = name;
      Value = value;
    }

    [DataMember(IsRequired = true, Order = 0)]
    public string Name { get; set; }

    [DataMember(IsRequired = true, Order = 1)]
    public string Value { get; set; }
  }
}
