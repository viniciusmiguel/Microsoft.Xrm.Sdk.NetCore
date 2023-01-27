// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.CallerImpersonationScope
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.Xrm.Sdk
{
  public sealed class CallerImpersonationScope : IDisposable
  {
    private bool _disposed;
    private OperationContextScope scope;

    public CallerImpersonationScope(IOrganizationService service, Guid callerId)
    {
      var header = MessageHeader.CreateHeader("CallerId", "http://schemas.microsoft.com/xrm/2011/Contracts", callerId);
      scope = new OperationContextScope((IContextChannel) service);
      OperationContext.Current.OutgoingMessageHeaders.Add(header);
    }

    public void Dispose()
    {
      if (_disposed)
        return;
      if (OperationContext.Current != null)
      {
        OperationContext.Current.OutgoingMessageHeaders.RemoveAll("CallerId", "http://schemas.microsoft.com/xrm/2011/Contracts");
        if (scope != null)
          scope.Dispose();
      }
      _disposed = true;
    }
  }
}
