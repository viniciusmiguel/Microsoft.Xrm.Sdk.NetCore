// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;

namespace Microsoft.Xrm.Sdk
{
  [AttributeUsage(AttributeTargets.Property)]
  public sealed class AttributeLogicalNameAttribute : Attribute
  {
    /// <summary>Gets the CRM logical name of the attribute.</summary>
    public string LogicalName { get; private set; }

    public AttributeLogicalNameAttribute(string logicalName) => LogicalName = !string.IsNullOrWhiteSpace(logicalName) ? logicalName : throw new ArgumentNullException(nameof (logicalName));
  }
}
