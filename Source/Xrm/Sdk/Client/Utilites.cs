// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.Utilites
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Diagnostics;

namespace Microsoft.Xrm.Sdk.Client
{
  internal static class Utilites
  {
    public static TimeSpan DefaultTimeout = new(0, 0, 2, 0);
    private static string _xrmSdkAssemblyFileVersion;

    /// <summary>
    /// Get's the file version of the Xrm Sdk assembly that is loaded in the current client domain.
    /// For Sdk clients called via the OrganizationServiceProxy this is the version of the local Microsoft.Xrm.Sdk dll used by the Client App.
    /// </summary>
    /// <returns></returns>
    internal static string GetXrmSdkAssemblyFileVersion()
    {
      if (string.IsNullOrEmpty(_xrmSdkAssemblyFileVersion))
      {
        var strArray = new string[1]
        {
          "Microsoft.Xrm.Sdk.dll"
        };
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var str in strArray)
        {
          foreach (var assembly in assemblies)
          {
            if (assembly.ManifestModule.Name.Equals(str, StringComparison.OrdinalIgnoreCase))
              _xrmSdkAssemblyFileVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
          }
        }
      }
      return _xrmSdkAssemblyFileVersion;
    }
  }
}
