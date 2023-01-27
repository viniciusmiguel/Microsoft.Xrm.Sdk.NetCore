// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SaveChangesException
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;

namespace Microsoft.Xrm.Sdk
{
  [Serializable]
  public sealed class SaveChangesException : Exception
  {
    private const string _message = "An error occured while processing this request.";

    public SaveChangesResultCollection Results { get; private set; }

    public SaveChangesException()
    {
    }

    public SaveChangesException(string message)
      : base(message)
    {
    }

    public SaveChangesException(string message, Exception exception)
      : base(message, exception)
    {
    }

    public SaveChangesException(SaveChangesResultCollection results)
      : this("An error occured while processing this request.", results)
    {
    }

    public SaveChangesException(string message, SaveChangesResultCollection results)
      : this(message, GetException(results), results)
    {
    }

    public SaveChangesException(Exception innerException, SaveChangesResultCollection results)
      : this("An error occured while processing this request.", innerException, results)
    {
    }

    public SaveChangesException(
      string message,
      Exception innerException,
      SaveChangesResultCollection results)
      : base(message, innerException)
    {
      Results = results;
    }

    private SaveChangesException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    [SecurityCritical]
    public override void GetObjectData(SerializationInfo info, StreamingContext context) => base.GetObjectData(info, context);

    private static Exception GetException(IEnumerable<SaveChangesResult> results) => results.Where<SaveChangesResult>(r => r.Error != null).Select<SaveChangesResult, Exception>(r => r.Error).FirstOrDefault<Exception>();
  }
}
