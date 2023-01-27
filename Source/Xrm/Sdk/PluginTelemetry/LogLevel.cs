// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.PluginTelemetry.LogLevel
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

namespace Microsoft.Xrm.Sdk.PluginTelemetry
{
  /// <summary>Defines logging severity levels.</summary>
  public enum LogLevel
  {
    /// <summary>
    /// Logs that contain the most detailed messages.These messages may contain sensitive
    ///     application data. These messages are disabled by default and should never be
    ///     enabled in a production environment.
    /// </summary>
    Trace,
    /// <summary>
    /// Logs that are used for interactive investigation during development. These logs
    ///     should primarily contain information useful for debugging and have no long-term
    ///     value.
    /// </summary>
    Debug,
    /// <summary>
    /// Logs that track the general flow of the application. These logs should have long-term
    ///     value.
    /// </summary>
    Information,
    /// <summary>
    /// Logs that highlight an abnormal or unexpected event in the application flow,
    ///     but do not otherwise cause the application execution to stop.
    /// </summary>
    Warning,
    /// <summary>
    ///  Logs that highlight when the current flow of execution is stopped due to a failure.
    ///     These should indicate a failure in the current activity, not an application-wide
    ///     failure.
    /// </summary>
    Error,
    /// <summary>
    /// Logs that describe an unrecoverable application or system crash, or a catastrophic
    ///     failure that requires immediate attention.
    /// </summary>
    Critical,
    /// <summary>
    ///  Not used for writing log messages. Specifies that a logging category should not
    ///     write any messages.
    /// </summary>
    None,
  }
}
