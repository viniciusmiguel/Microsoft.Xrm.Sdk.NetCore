// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.FileSasUrlResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "FileSasUrlResponse", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public class FileSasUrlResponse : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Gets or sets the file name.</summary>
    [DataMember]
    public string FileName { get; set; }

    /// <summary>Gets or sets the file size.</summary>
    [DataMember]
    public long FileSizeInBytes { get; set; }

    /// <summary>Gets or sets the mime type.</summary>
    [DataMember]
    public string MimeType { get; set; }

    /// <summary>Gets or sets the SAS url.</summary>
    [DataMember]
    public string SasUrl { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
