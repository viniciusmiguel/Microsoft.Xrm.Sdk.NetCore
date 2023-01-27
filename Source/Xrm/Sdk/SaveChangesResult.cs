// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SaveChangesResult
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;

namespace Microsoft.Xrm.Sdk
{
  public sealed class SaveChangesResult
  {
    public OrganizationRequest Request { get; private set; }

    public OrganizationResponse Response { get; private set; }

    public Exception Error { get; private set; }

    internal SaveChangesResult(OrganizationRequest request, OrganizationResponse response)
    {
      Request = request;
      Response = response;
    }

    internal SaveChangesResult(OrganizationRequest request, Exception error)
    {
      Request = request;
      Error = error;
    }
  }
}
