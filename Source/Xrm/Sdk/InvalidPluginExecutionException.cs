// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.InvalidPluginExecutionException
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;
using System.Security;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Defines an exception to be thrown when plug-in encounter business logic exception.
  /// This exception will be bubbled up to client.
  /// </summary>
  [Serializable]
  public sealed class InvalidPluginExecutionException : Exception, ISerializable
  {
    private OperationStatus _status;
    private PluginHttpStatusCode _httpStatusCode;

    public InvalidPluginExecutionException()
    {
      _status = OperationStatus.Failed;
      _httpStatusCode = PluginHttpStatusCode.NotSet;
    }

    public InvalidPluginExecutionException(OperationStatus status)
      : this(status, string.Empty)
    {
    }

    public InvalidPluginExecutionException(string message)
      : base(message)
    {
      _status = OperationStatus.Failed;
      _httpStatusCode = PluginHttpStatusCode.NotSet;
    }

    public InvalidPluginExecutionException(OperationStatus status, string message)
      : this(status, 0, message)
    {
    }

    public InvalidPluginExecutionException(string message, Exception exception)
      : base(message, exception)
    {
      _status = OperationStatus.Failed;
      _httpStatusCode = exception is InvalidPluginExecutionException ? ((InvalidPluginExecutionException) exception).HttpStatus : PluginHttpStatusCode.NotSet;
    }

    public InvalidPluginExecutionException(OperationStatus status, int errorCode, string message)
      : this(message)
    {
      _status = status;
      if (errorCode == 0)
        return;
      HResult = errorCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.InvalidPluginExecutionException" /> class.
    /// Constructor allowing a specific HTTP status code to be returned when InvalidPluginExecutionException is thrown.
    /// </summary>
    public InvalidPluginExecutionException(string message, PluginHttpStatusCode httpStatus)
      : this(OperationStatus.Failed, 0, message, httpStatus)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.InvalidPluginExecutionException" /> class.
    /// Constructor allowing a specific HTTP status code to be returned when InvalidPluginExecutionException is thrown.
    /// </summary>
    public InvalidPluginExecutionException(
      OperationStatus status,
      int errorCode,
      string message,
      PluginHttpStatusCode httpStatus)
      : this(status, errorCode, message)
    {
      _httpStatusCode = httpStatus;
    }

    private InvalidPluginExecutionException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      _status = (OperationStatus) info.GetValue(nameof (Status), typeof (OperationStatus));
      try
      {
        _httpStatusCode = (PluginHttpStatusCode) info.GetValue(nameof (HttpStatus), typeof (PluginHttpStatusCode));
      }
      catch (Exception)
      {
        _httpStatusCode = PluginHttpStatusCode.NotSet;
      }
    }

    /// <summary>
    /// Gets status of workflow instance after executing StopWorkflow activity.
    /// </summary>
    public OperationStatus Status => _status;

    /// <summary>Get the error code associated with the exception</summary>
    public int ErrorCode => HResult;

    public PluginHttpStatusCode HttpStatus => _httpStatusCode;

    [SecurityCritical]
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      info.AddValue("Status", _status, typeof (OperationStatus));
      info.AddValue("HttpStatus", _httpStatusCode, typeof (PluginHttpStatusCode));
      base.GetObjectData(info, context);
    }
  }
}
