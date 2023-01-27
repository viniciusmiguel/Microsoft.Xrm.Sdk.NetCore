// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.WebServiceClient.UserType
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

namespace Microsoft.Xrm.Sdk.WebServiceClient
{
  /// <summary>
  /// Enumeration of the different type of user.  This can be a crm user or
  /// an ExternalParty user calling the sdk.  The type is used to help
  /// identify application calls for impersonations.
  /// </summary>
  public enum UserType
  {
    CrmUser,
    ExternalPartyUser,
  }
}
