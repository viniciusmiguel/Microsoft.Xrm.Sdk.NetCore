// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.PluginTelemetry.ILogger
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Xrm.Sdk.PluginTelemetry
{
  public interface ILogger
  {
    /// <summary>Begins a logical operation scope.</summary>
    /// <typeparam name="TState">The identifier for the scope.</typeparam>
    /// <param name="state">The type of the state to begin scope for.</param>
    /// <returns>An IDisposable that ends the logical operation scope on dispose.</returns>
    IDisposable BeginScope<TState>(TState state);

    /// <summary>Formats the message and creates a scope.</summary>
    /// <param name="messageFormat">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    /// <returns>An IDisposable that ends the logical operation scope on dispose.</returns>
    IDisposable BeginScope(string messageFormat, params object[] args);

    /// <summary>
    /// Checks if the given <paramref name="logLevel" /> is enabled.
    /// </summary>
    /// <param name="logLevel">level to be checked.</param>
    /// <returns><c>true</c> if enabled.</returns>
    bool IsEnabled(LogLevel logLevel);

    /// <summary>Writes a log entry.</summary>
    /// <typeparam name="TState"></typeparam>
    /// <param name="logLevel">Entry will be written on this level.</param>
    /// <param name="eventId">Id of the event.</param>
    /// <param name="state">The entry to be written. Can be also an object.</param>
    /// <param name="exception">The exception related to this entry.</param>
    /// <param name="formatter">Function to create a <c>string</c> message of the state and exception.</param>
    void Log<TState>(
      LogLevel logLevel,
      EventId eventId,
      TState state,
      Exception exception,
      Func<TState, Exception, string> formatter);

    /// <summary>Formats and Writes a log message.</summary>
    /// <param name="logLevel">Entry will be written on this level.</param>
    /// <param name="eventId">Id of the event.</param>
    /// <param name="exception">The exception related to this entry.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void Log(
      LogLevel logLevel,
      EventId eventId,
      Exception exception,
      string message,
      params object[] args);

    /// <summary>Formats and Writes a log message.</summary>
    /// <param name="logLevel">Entry will be written on this level.</param>
    /// <param name="eventId">Id of the event.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void Log(LogLevel logLevel, EventId eventId, string message, params object[] args);

    /// <summary>Formats and Writes a log message.</summary>
    /// <param name="logLevel">Entry will be written on this level.</param>
    /// <param name="exception">The exception related to this entry.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void Log(LogLevel logLevel, Exception exception, string message, params object[] args);

    /// <summary>Formats and Writes a log message.</summary>
    /// <param name="logLevel">Entry will be written on this level.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void Log(LogLevel logLevel, string message, params object[] args);

    /// <summary>Formats and Writes a critical log message.</summary>
    /// <param name="eventId">Id of the event.</param>
    /// <param name="exception">The exception related to this entry.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogCritical(EventId eventId, Exception exception, string message, params object[] args);

    /// <summary>Formats and Writes a critical log message.</summary>
    /// <param name="eventId">Id of the event.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogCritical(EventId eventId, string message, params object[] args);

    /// <summary>Formats and Writes a critical log message.</summary>
    /// <param name="exception">The exception related to this entry.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogCritical(Exception exception, string message, params object[] args);

    /// <summary>Formats and Writes a critical log message.</summary>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogCritical(string message, params object[] args);

    /// <summary>Formats and Writes a debug log message.</summary>
    /// <param name="eventId">Id of the event.</param>
    /// <param name="exception">The exception related to this entry.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogDebug(EventId eventId, Exception exception, string message, params object[] args);

    /// <summary>Formats and Writes a debug log message.</summary>
    /// <param name="eventId">Id of the event.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogDebug(EventId eventId, string message, params object[] args);

    /// <summary>Formats and Writes a debug log message.</summary>
    /// <param name="exception">The exception related to this entry.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogDebug(Exception exception, string message, params object[] args);

    /// <summary>Formats and Writes a debug log message.</summary>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogDebug(string message, params object[] args);

    /// <summary>Formats and Writes an error log message.</summary>
    /// <param name="eventId">Id of the event.</param>
    /// <param name="exception">The exception related to this entry.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogError(EventId eventId, Exception exception, string message, params object[] args);

    /// <summary>Formats and Writes an error log message.</summary>
    /// <param name="eventId">Id of the event.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogError(EventId eventId, string message, params object[] args);

    /// <summary>Formats and Writes an error log message.</summary>
    /// <param name="exception">The exception related to this entry.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogError(Exception exception, string message, params object[] args);

    /// <summary>Formats and Writes an error log message.</summary>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogError(string message, params object[] args);

    /// <summary>Formats and Writes an information log message.</summary>
    /// <param name="eventId">Id of the event.</param>
    /// <param name="exception">The exception related to this entry.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogInformation(
      EventId eventId,
      Exception exception,
      string message,
      params object[] args);

    /// <summary>Formats and Writes an information log message.</summary>
    /// <param name="eventId">Id of the event.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogInformation(EventId eventId, string message, params object[] args);

    /// <summary>Formats and Writes an information log message.</summary>
    /// <param name="exception">The exception related to this entry.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogInformation(Exception exception, string message, params object[] args);

    /// <summary>Formats and Writes an information log message.</summary>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogInformation(string message, params object[] args);

    /// <summary>Formats and Writes a trace log message.</summary>
    /// <param name="eventId">Id of the event.</param>
    /// <param name="exception">The exception related to this entry.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogTrace(EventId eventId, Exception exception, string message, params object[] args);

    /// <summary>Formats and Writes a trace log message.</summary>
    /// <param name="eventId">Id of the event.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogTrace(EventId eventId, string message, params object[] args);

    /// <summary>Formats and Writes a trace log message.</summary>
    /// <param name="exception">The exception related to this entry.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogTrace(Exception exception, string message, params object[] args);

    /// <summary>Formats and Writes a trace log message.</summary>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogTrace(string message, params object[] args);

    /// <summary>Formats and Writes a warning log message.</summary>
    /// <param name="eventId">Id of the event.</param>
    /// <param name="exception">The exception related to this entry.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogWarning(EventId eventId, Exception exception, string message, params object[] args);

    /// <summary>Formats and Writes a warning log message.</summary>
    /// <param name="eventId">Id of the event.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogWarning(EventId eventId, string message, params object[] args);

    /// <summary>Formats and Writes a warning log message.</summary>
    /// <param name="exception">The exception related to this entry.</param>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogWarning(Exception exception, string message, params object[] args);

    /// <summary>Formats and Writes a warning log message.</summary>
    /// <param name="message">Format string of the scope message.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    void LogWarning(string message, params object[] args);

    /// <summary>Publish hot path metric.</summary>
    /// <param name="metricName">name of the metric</param>
    /// <param name="value">value that needs to be published</param>
    void LogMetric(string metricName, long value);

    /// <summary>Publish hot path metric nd add custom dimensions.</summary>
    /// <param name="metricName">name of the metric</param>
    /// <param name="metricDimensions">custom properties that needs to be published</param>
    /// <param name="value">value that needs to be published</param>
    void LogMetric(string metricName, IDictionary<string, string> metricDimensions, long value);

    /// <summary>Add property to customdimensions.</summary>
    /// <param name="propertyName">Name of the property.</param>
    /// <param name="propertyValue">Value of the property.</param>
    void AddCustomProperty(string propertyName, string propertyValue);

    /// <summary>
    /// Executes an action and wrap it inside provided activityName
    /// </summary>
    /// <param name="activityName">Name of the activity that gets logged in telemetry</param>
    /// <param name="action">Action to be performed</param>
    /// <param name="additionalCustomProperties">Additional proeprties to be logged</param>
    void Execute(
      string activityName,
      Action action,
      IEnumerable<KeyValuePair<string, string>> additionalCustomProperties = null);

    /// <summary>
    /// Executes an action and wrap it inside provided activityName
    /// </summary>
    /// <param name="activityName">Name of the activity that gets logged in telemetry</param>
    /// <param name="action">Action to be performed</param>
    /// <param name="additionalCustomProperties">Additional proeprties to be logged</param>
    /// <returns></returns>
    Task ExecuteAsync(
      string activityName,
      Func<Task> action,
      IEnumerable<KeyValuePair<string, string>> additionalCustomProperties = null);
  }
}
