// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceChannel`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.Security;
using System.Security.Permissions;
using System.ServiceModel;

namespace Microsoft.Xrm.Sdk.Client
{
  /// <summary>
  /// 	Channel class to manage connections to the SDK endpoints
  /// </summary>
  /// <typeparam name="TChannel"></typeparam>
  [SecuritySafeCritical]
  [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
  public class ServiceChannel<TChannel> : IDisposable where TChannel : class
  {
    private readonly object _lockObject = new();
    private TChannel _channel;
    private TimeSpan _timeout = ServiceDefaults.DefaultTimeout;
    private bool _updateTimeout = true;
    private bool _disposed;

    public ServiceChannel(ChannelFactory<TChannel> factory)
    {
      ClientExceptionHelper.ThrowIfNull(factory, nameof (factory));
      Factory = factory;
    }

    /// <summary>
    /// 	Gets a channel, creates new one if current one is not present or faulted
    /// </summary>
    public TChannel Channel
    {
      get
      {
        if (_channel == null || _disposed || !IsCommunicationObjectValid(CommunicationObject))
        {
          ClientExceptionHelper.ThrowIfNull(Factory, "Factory");
          ConfigureNewChannel();
        }
        lock (_lockObject)
        {
          if (_updateTimeout)
          {
            ((object) _channel as IContextChannel).OperationTimeout = _timeout;
            _updateTimeout = false;
          }
        }
        return _channel;
      }
    }

    /// <summary>Returns the Channel factory used</summary>
    protected ChannelFactory<TChannel> Factory { get; private set; }

    /// <summary>Create a new channel</summary>
    /// <returns></returns>
    [SecuritySafeCritical]
    [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
    protected virtual TChannel CreateChannel() => Factory.CreateChannel();

    protected ICommunicationObject CommunicationObject => (object) _channel as ICommunicationObject;

    internal static bool IsCommunicationObjectValid(ICommunicationObject communicationObject)
    {
      if (communicationObject != null)
      {
        switch (communicationObject.State)
        {
          case CommunicationState.Created:
          case CommunicationState.Opening:
          case CommunicationState.Opened:
            return true;
        }
      }
      return false;
    }

    internal TimeSpan Timeout
    {
      get => _timeout;
      set
      {
        _timeout = value;
        _updateTimeout = true;
      }
    }

    internal bool IsChannelInvalid => _disposed || Factory == null;

    private void ConfigureNewChannel()
    {
      _channel = CreateChannel();
      CommunicationObject.Opened += new EventHandler(Channel_Opened);
      CommunicationObject.Faulted += new EventHandler(Channel_Faulted);
      CommunicationObject.Closed += new EventHandler(Channel_Closed);
    }

    private void RemoveChannelEvents()
    {
      if (CommunicationObject == null)
        return;
      CommunicationObject.Opened -= new EventHandler(Channel_Opened);
      CommunicationObject.Faulted -= new EventHandler(Channel_Faulted);
      CommunicationObject.Closed -= new EventHandler(Channel_Closed);
    }

    public void Open()
    {
      if (CommunicationObject == null)
        return;
      if (CommunicationObject.State != CommunicationState.Created)
        return;
      try
      {
        CommunicationObject.Open();
      }
      catch (Exception ex)
      {
        var args = new ChannelFaultedEventArgs("Exception when opening an SDK channel", ex);
        OnChannelFaulted(args);
        if (args.Cancel)
          return;
        throw;
      }
    }

    public void Abort()
    {
      if (CommunicationObject == null)
        return;
      CommunicationObject.Abort();
    }

    public void Close()
    {
      if (CommunicationObject == null)
        return;
      RemoveChannelEvents();
      ChannelExtensions.Close(CommunicationObject);
    }

    /// <summary>Attaches to Faulted event for cleanup</summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Channel_Faulted(object sender, EventArgs e)
    {
      var channel = (object) _channel as ICommunicationObject;
      _channel = default (TChannel);
      OnChannelFaulted(new ChannelFaultedEventArgs("The channel has entered a faulted state.", null));
      if (channel == null)
        return;
      RemoveChannelEvents();
      ChannelExtensions.Close(channel);
    }

    private void Channel_Closed(object sender, EventArgs e) => OnChannelClosed(new ChannelEventArgs("The channel has entered a closed state."));

    private void Channel_Opened(object sender, EventArgs e) => OnChannelOpened(new ChannelEventArgs("The channel has entered an opened state."));

    protected virtual void OnChannelFaulted(ChannelFaultedEventArgs args)
    {
      if (ChannelFaulted == null)
        return;
      ChannelFaulted(this, args);
    }

    protected virtual void OnChannelClosed(ChannelEventArgs args)
    {
      if (ChannelClosed == null)
        return;
      ChannelClosed(this, args);
    }

    protected virtual void OnChannelOpened(ChannelEventArgs args)
    {
      if (ChannelOpened == null)
        return;
      ChannelOpened(this, args);
    }

    public event EventHandler<ChannelFaultedEventArgs> ChannelFaulted;

    public event EventHandler<ChannelEventArgs> ChannelOpened;

    public event EventHandler<ChannelEventArgs> ChannelClosed;

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    ~ServiceChannel() => Dispose(false);

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "False Positive - disposableFactory")]
    [SuppressMessage("Microsoft.CodeQuality.Analyzers", "CA1063: Implement IDisposable correctly", Justification = "FxCop Bankruptcy")]
    private void Dispose(bool disposing)
    {
      if (_disposed)
        return;
      if (_channel != null)
      {
        try
        {
          Close();
        }
        finally
        {
          _channel = default (TChannel);
        }
      }
      Factory = null;
      if (!disposing)
        return;
      _disposed = true;
    }
  }
}
