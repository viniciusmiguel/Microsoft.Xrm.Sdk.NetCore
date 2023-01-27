// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Discovery.ClientPatchInfo
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;

namespace Microsoft.Xrm.Sdk.Discovery
{
  /// <summary>
  /// A strongly typed property bag that gives details about each patch that needs to be installed
  /// on the client.
  /// </summary>
  public sealed class ClientPatchInfo
  {
    private Guid _patchId;
    private string _title;
    private string _description;
    private bool _isMandatory;
    private int _depth;
    private string _linkId;

    /// <summary>The PatchId of the patch that needs to be installed.</summary>
    public Guid PatchId
    {
      get => _patchId;
      set => _patchId = value;
    }

    /// <summary>The Title of the Patch (eg: KB 1234)</summary>
    public string Title
    {
      get => _title;
      set => _title = value;
    }

    /// <summary>
    /// A brief description of the patch (and what problem it resolves).
    /// </summary>
    public string Description
    {
      get => _description;
      set => _description = value;
    }

    /// <summary>A bit to indicate if the patch is mandatory.</summary>
    public bool IsMandatory
    {
      get => _isMandatory;
      set => _isMandatory = value;
    }

    /// <summary>
    /// The depth order in which this patch needs to be installed. Lower depth patches should be installed
    /// first.
    /// </summary>
    public int Depth
    {
      get => _depth;
      set => _depth = value;
    }

    /// <summary>
    /// The link Identifier that is appended to the base URL when download patches.
    /// </summary>
    public string LinkId
    {
      get => _linkId;
      set => _linkId = value;
    }
  }
}
