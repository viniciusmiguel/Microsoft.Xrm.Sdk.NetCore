// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.IEnvironmentService
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Interface for plug-ins to get environment specific information.
  /// </summary>
  public interface IEnvironmentService
  {
    /// <summary>Gets the Azure authority host of current environment</summary>
    Uri AzureAuthorityHost { get; }

    /// <summary>Gets the Geo of current environment</summary>
    string Geo { get; }

    /// <summary>Gets the Azure region name of current environment</summary>
    string AzureRegionName { get; }
  }
}
