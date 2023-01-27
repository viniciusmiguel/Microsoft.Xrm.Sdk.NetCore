// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SdkExceptionBase
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [Serializable]
  public abstract class SdkExceptionBase : Exception
  {
    private const int UnexpectedErrorFaultCode = -2147220970;

    protected SdkExceptionBase(string message)
      : this(message, null)
    {
    }

    protected SdkExceptionBase(Exception innerException)
      : this(null, innerException)
    {
    }

    protected SdkExceptionBase(string message, Exception innerException)
      : base(message, innerException)
    {
      HResult = -2147220970;
    }

    protected SdkExceptionBase(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
