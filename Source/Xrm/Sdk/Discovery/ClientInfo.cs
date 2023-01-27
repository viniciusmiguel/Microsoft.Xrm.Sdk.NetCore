// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Discovery.ClientInfo
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;

namespace Microsoft.Xrm.Sdk.Discovery
{
  /// <summary>
  /// A property bag encapsulating all the properties of the client that is requesting patches.
  /// </summary>
  public sealed class ClientInfo
  {
    private Guid[] _patchIds;
    private ClientTypes _clientType;
    private Guid _userId;
    private Guid _organizationId;
    private int _languageCode;
    private string _officeVersion;
    private string _osVersion;
    private string _crmVersion;

    /// <summary>
    /// List of patches that the client already has installed.
    /// </summary>
    public Guid[] PatchIds
    {
      get => _patchIds;
      set => _patchIds = value;
    }

    /// <summary>
    /// The type of client which is querying for patches. (Desktop\Laptop\DM Client).
    /// </summary>
    public ClientTypes ClientType
    {
      get => _clientType;
      set => _clientType = value;
    }

    /// <summary>The CRM user id of the client.</summary>
    public Guid UserId
    {
      get => _userId;
      set => _userId = value;
    }

    /// <summary>
    /// The Organization Id for which the client has been configured.
    /// </summary>
    public Guid OrganizationId
    {
      get => _organizationId;
      set => _organizationId = value;
    }

    /// <summary>
    /// The language code for which the client has been configured.
    /// </summary>
    public int LanguageCode
    {
      get => _languageCode;
      set => _languageCode = value;
    }

    /// <summary>The Office Version installed on the client machine.</summary>
    public string OfficeVersion
    {
      get => _officeVersion;
      set => _officeVersion = value;
    }

    /// <summary>
    /// The operating system version that the client is running.
    /// </summary>
    public string OSVersion
    {
      get => _osVersion;
      set => _osVersion = value;
    }

    /// <summary>The CRM version that the client is running.</summary>
    public string CrmVersion
    {
      get => _crmVersion;
      set => _crmVersion = value;
    }
  }
}
