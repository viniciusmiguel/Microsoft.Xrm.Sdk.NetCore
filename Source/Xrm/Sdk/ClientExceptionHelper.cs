// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.ClientExceptionHelper
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Globalization;
using System.Text;

namespace Microsoft.Xrm.Sdk
{
  internal static class ClientExceptionHelper
  {
    /// <summary>
    /// Throw an CrmArgumentOutOfRangeException if the specified integer is less than zero.
    /// </summary>
    /// <param name="value">Integer value.</param>
    /// <param name="parameterName">Name of the parameter.</param>
    internal static void ThrowIfNegative(int value, string parameterName)
    {
      if (value < 0)
        throw new ArgumentOutOfRangeException(parameterName, value, "Value for this parameter must be equal or greater than zero.");
    }

    /// <summary>
    /// Throw an XrmArgumentNullException if the specified parameter is null.
    /// </summary>
    /// <param name="parameter">Parameter value.</param>
    /// <param name="name">Parameter name.</param>
    internal static void ThrowIfNull(object parameter, string name)
    {
      if (parameter == null)
        throw new ArgumentNullException(name);
    }

    /// <summary>
    /// Throw an XrmArgumentNullException if the specified parameter is null.
    /// </summary>
    /// <param name="parameter">Parameter value.</param>
    /// <param name="name">Parameter name.</param>
    internal static void ThrowIfNullOrEmpty(string parameter, string name)
    {
      if (string.IsNullOrEmpty(parameter))
        throw new ArgumentNullException(name);
    }

    /// <summary>
    /// Throw an XrmArgumentException if the specified parameter is Guid.Empty.
    /// </summary>
    /// <param name="parameter">Parameter value.</param>
    /// <param name="name">Parameter name.</param>
    internal static void ThrowIfGuidEmpty(Guid parameter, string name)
    {
      if (parameter == Guid.Empty)
        throw new ArgumentException("Expected non-empty Guid.", name);
    }

    internal static string FormatMessage(int errorCode, params object[] arguments)
    {
      if (errorCode == 0)
        return BuildErrorTable(string.Empty, arguments);
      var str = errorCode.ToString(CultureInfo.InvariantCulture);
      try
      {
        return string.Format(CultureInfo.InvariantCulture, str, arguments);
      }
      catch (FormatException)
      {
        return BuildErrorTable(str, arguments);
      }
    }

    private static string BuildErrorTable(string message, object[] arguments)
    {
      var stringBuilder = new StringBuilder(message);
      for (var index = 0; index < arguments.Length; ++index)
        stringBuilder.Append(string.Format(CultureInfo.InvariantCulture, "\nData[{0}] = \"{1}\"", index, arguments[index]));
      return stringBuilder.ToString();
    }

    internal static void Assert(bool condition, string message, params object[] args) => Assert(condition, string.Format(CultureInfo.InvariantCulture, message, args));

    internal static void Assert(bool condition, string message)
    {
      InvalidOperationException operationException = null;
      if (!condition)
        operationException = new InvalidOperationException(message);
      if (operationException != null)
        throw operationException;
    }

    internal static string GetString(string value, params object[] args)
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
