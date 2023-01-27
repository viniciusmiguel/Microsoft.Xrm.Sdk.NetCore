// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.XrmBinding
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.ServiceModel.Channels;
using System.Xml;

namespace Microsoft.Xrm.Sdk.Client
{
  public sealed class XrmBinding : CustomBinding
  {
    private TransportBindingElement _transportElement;
    private MtomMessageEncodingBindingElement _mtomMessageEncodingElement;
    private TextMessageEncodingBindingElement _textMessageEncodingElement;

    internal XrmBinding(Binding binding)
      : base(binding)
    {
      if (binding == null)
        throw new ArgumentNullException(nameof (binding));
      Initialize();
    }

    public int MaxBufferSize
    {
      get => _transportElement is HttpTransportBindingElement transportElement ? transportElement.MaxBufferSize : -1;
      set
      {
        if (_transportElement is HttpTransportBindingElement transportElement)
          transportElement.MaxBufferSize = value;
        if (_mtomMessageEncodingElement == null)
          return;
        _mtomMessageEncodingElement.MaxBufferSize = value;
      }
    }

    public long MaxReceivedMessageSize
    {
      get => _transportElement != null ? _transportElement.MaxReceivedMessageSize : -1L;
      set
      {
        if (_transportElement == null)
          return;
        _transportElement.MaxReceivedMessageSize = value;
      }
    }

    public XmlDictionaryReaderQuotas ReaderQuotas
    {
      get
      {
        if (_textMessageEncodingElement != null)
          return _textMessageEncodingElement.ReaderQuotas;
        return _mtomMessageEncodingElement != null ? _mtomMessageEncodingElement.ReaderQuotas : null;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException(nameof (value));
        if (_mtomMessageEncodingElement != null)
          value.CopyTo(_mtomMessageEncodingElement.ReaderQuotas);
        if (_textMessageEncodingElement == null)
          return;
        value.CopyTo(_textMessageEncodingElement.ReaderQuotas);
      }
    }

    public override string Scheme => _transportElement == null ? string.Empty : _transportElement.Scheme;

    private void Initialize()
    {
      _transportElement = Elements.Find<TransportBindingElement>();
      _mtomMessageEncodingElement = Elements.Find<MtomMessageEncodingBindingElement>();
      _textMessageEncodingElement = Elements.Find<TextMessageEncodingBindingElement>();
    }
  }
}
