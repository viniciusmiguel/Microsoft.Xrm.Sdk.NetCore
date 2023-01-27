// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.XrmPolicy
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Diagnostics.CodeAnalysis;
using System.ServiceModel.Channels;

namespace Microsoft.Xrm.Sdk.Client
{
  internal abstract class XrmPolicy : BindingElement
  {
    private readonly PolicyDictionary _policyElements = new();

    internal PolicyDictionary PolicyElements => _policyElements;

    public override BindingElement Clone() => this;

    [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "Needed for interface definition.")]
    public override T GetProperty<T>(BindingContext context) => context.GetInnerProperty<T>();
  }
}
