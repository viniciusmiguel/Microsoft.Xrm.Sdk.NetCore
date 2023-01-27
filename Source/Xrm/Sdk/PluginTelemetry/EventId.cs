// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.PluginTelemetry.EventId
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

namespace Microsoft.Xrm.Sdk.PluginTelemetry
{
  /// <summary>Defines eventId</summary>
  public class EventId
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.PluginTelemetry.EventId" /> class.
    /// Constructor
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    public EventId(int id, string name = null)
    {
      Id = id;
      Name = name;
    }

    /// <summary>Id of event</summary>
    public int Id { get; }

    /// <summary>Name of event</summary>
    public string Name { get; }
  }
}
