/*
// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Protocols.WSTrust.Bindings.ClientExceptionHelper
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Globalization;

namespace Microsoft.Crm.Protocols.WSTrust.Bindings
{
  public static class ClientExceptionHelper
  {
    public static string GetString(string value, params object[] args)
    {
      var format = value;
      if (string.IsNullOrEmpty(value))
        return value;
      if (args != null && args.Length != 0)
        format = string.Format(CultureInfo.CurrentCulture, format, args);
      return format;
    }
  }
}
*/
