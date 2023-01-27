// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ChannelExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.ServiceModel;

namespace Microsoft.Xrm.Sdk.Client
{
  internal static class ChannelExtensions
  {
    public static void Abort(this ICommunicationObject communicationObject) => communicationObject?.Abort();

    [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "There is already a version that supplies the default parameter.  This is an extension method")]
    public static void Close(this ICommunicationObject communicationObject, bool throwOnException = true)
    {
      if (communicationObject == null)
        return;
      try
      {
        switch (communicationObject.State)
        {
          case CommunicationState.Closing:
            break;
          case CommunicationState.Closed:
            break;
          case CommunicationState.Faulted:
            communicationObject.Abort();
            break;
          default:
            communicationObject.Close();
            break;
        }
      }
      catch (CommunicationException)
      {
        communicationObject.Abort();
      }
      catch (TimeoutException)
      {
        communicationObject.Abort();
      }
      catch (Exception)
      {
        communicationObject.Abort();
        if (!throwOnException)
          return;
        throw;
      }
    }
  }
}
