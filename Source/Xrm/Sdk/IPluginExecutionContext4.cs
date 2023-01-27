﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.IPluginExecutionContext4
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Extension of IPluginExecutionContext3 adding support for PreEntityImagesCollection and PostEntityImagesCollection
  /// </summary>
  public interface IPluginExecutionContext4 : 
    IPluginExecutionContext3,
    IPluginExecutionContext2,
    IPluginExecutionContext,
    IExecutionContext
  {
    /// <summary>Contains a collection of PreEntityImages</summary>
    EntityImageCollection[] PreEntityImagesCollection { get; }

    /// <summary>Contains a collection of PostEntityImages</summary>
    EntityImageCollection[] PostEntityImagesCollection { get; }
  }
}
