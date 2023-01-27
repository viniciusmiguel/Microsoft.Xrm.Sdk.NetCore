// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Linq.PagingCookieHelper
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace Microsoft.Xrm.Sdk.Linq
{
  /// <summary>Paging cookie helper class.</summary>
  /// <remarks> Samples of paging cookie.
  /// paging-cookie="<cookie page="2"><name last="C" first="C" /><accountid last="{C8CD170E-40B5-DF11-8E7B-00155D352900}" first="{C8CD170E-40B5-DF11-8E7B-00155D352900}" /></cookie>"&gt;
  /// paging-cookie="<cookie page="2" parentEntityId="{C8CD170E-40B5-DF11-8E7B-00155D352900}" parentAttributeName="accountid" parentEntityObjectTypeCode="1"><name last="C" first="C" /><accountid last="{C8CD170E-40B5-DF11-8E7B-00155D352900}" first="{C8CD170E-40B5-DF11-8E7B-00155D352900}" /></cookie>"&gt;
  /// </remarks>
  internal static class PagingCookieHelper
  {
    public static object[] ToContinuationToken(string pagingCookie, int pageNumber) => Deserialize(pagingCookie, pageNumber).ToArray();

    public static string ToPagingCookie(
      object[] continuationToken,
      out int pageNumber,
      StringBuilder sb)
    {
      return Serialize(continuationToken, out pageNumber, sb);
    }

    private static List<object> Deserialize(string pagingCookie, int pageNumber)
    {
      ClientExceptionHelper.ThrowIfNegative(pageNumber, nameof (pageNumber));
      var objectList = new List<object>();
      try
      {
        using (var xmlReader = CreateXmlReader(pagingCookie))
        {
          xmlReader.Read();
          objectList.Add(pageNumber);
          var attribute1 = xmlReader.GetAttribute("parentEntityId");
          if (!string.IsNullOrEmpty(attribute1))
          {
            objectList.Add(new Guid(attribute1));
            var attribute2 = xmlReader.GetAttribute("parentAttributeName");
            ClientExceptionHelper.ThrowIfNullOrEmpty(attribute2, "parentAttributeName");
            objectList.Add(attribute2);
            var result = -1;
            if (int.TryParse(xmlReader.GetAttribute("parentEntityObjectTypeCode"), out result))
              objectList.Add(result);
            else
              ClientExceptionHelper.ThrowIfNegative(result, "parentOtc");
          }
          while (xmlReader.Read())
          {
            if (xmlReader.NodeType != XmlNodeType.EndElement && (xmlReader.NodeType != XmlNodeType.Element || !(xmlReader.Name == "cookieExtensions")))
            {
              var name = xmlReader.Name;
              ClientExceptionHelper.ThrowIfNullOrEmpty(name, "field");
              objectList.Add(name);
              var str = xmlReader.AttributeCount == 2 ? xmlReader.GetAttribute("last") : throw new NotSupportedException("Malformed XML Passed to in the Paging Cookie. We expect at most two attributes (first/firstNull and last/lastNull)");
              if (str == null)
              {
                if (xmlReader.GetAttribute("lastnull") == null)
                  throw new NotSupportedException("Malformed XML Passed to in the Paging Cookie. Value for attribute last was not specified, and it was not null either.");
                objectList.Add(null);
              }
              else
                objectList.Add(str);
              var attribute3 = xmlReader.GetAttribute("first");
              if (attribute3 == null)
              {
                if (xmlReader.GetAttribute("firstnull") == null)
                  throw new NotSupportedException("Malformed XML Passed to in the Paging Cookie. Value for attribute first was not specified, and it was not null either.");
                objectList.Add(null);
              }
              else
                objectList.Add(attribute3);
            }
          }
        }
      }
      catch (XmlException ex)
      {
        throw new NotSupportedException("Malformed XML in the Paging Cookie", ex);
      }
      catch (FormatException ex)
      {
        throw new NotSupportedException("Malformed XML in the Paging Cookie", ex);
      }
      return objectList;
    }

    private static string Serialize(object[] pagingElements, out int pageNumber, StringBuilder sb)
    {
      pageNumber = 0;
      if (pagingElements == null || pagingElements.Length == 0)
        return null;
      if (pagingElements.Length % 3 != 1)
        throw new NotSupportedException("Skip token has incorrect length");
      pageNumber = pagingElements[0] != null && pagingElements[0].GetType() == typeof (int) && (int) pagingElements[0] >= 0 ? (int) pagingElements[0] : throw new NotSupportedException("Skip token has incorrect page value");
      using (var stringWriter = new StringWriter(sb, CultureInfo.InvariantCulture))
      {
        using (var xmlWriter = CreateXmlWriter(stringWriter))
        {
          xmlWriter.WriteStartElement("cookie");
          xmlWriter.WriteAttributeString("page", pageNumber.ToString(CultureInfo.InvariantCulture));
          var num = 1;
          if (pagingElements[1] != null && pagingElements[1].GetType() == typeof (Guid) && pagingElements[2] != null && pagingElements[2].GetType() == typeof (string) && pagingElements[3] != null && pagingElements[3].GetType() == typeof (int))
          {
            num = 4;
            xmlWriter.WriteAttributeString("parentEntityId", pagingElements[1].ToString());
            xmlWriter.WriteAttributeString("parentAttributeName", (string) pagingElements[2]);
            xmlWriter.WriteAttributeString("parentEntityObjectTypeCode", pagingElements[3].ToString());
          }
          for (var index = num; index < pagingElements.Length; index += 3)
          {
            var pagingElement = (string) pagingElements[index];
            ClientExceptionHelper.ThrowIfNullOrEmpty(pagingElement, "attributeName");
            var empty1 = string.Empty;
            var empty2 = string.Empty;
            var str1 = (string) pagingElements[index + 1];
            var str2 = (string) pagingElements[index + 2];
            xmlWriter.WriteStartElement(pagingElement);
            string localName1;
            if (str1 != null)
            {
              localName1 = "last";
            }
            else
            {
              localName1 = "lastnull";
              str1 = "1";
            }
            string localName2;
            if (str2 != null)
            {
              localName2 = "first";
            }
            else
            {
              localName2 = "firstnull";
              str2 = "1";
            }
            xmlWriter.WriteAttributeString(localName1, str1);
            xmlWriter.WriteAttributeString(localName2, str2);
            xmlWriter.WriteEndElement();
          }
          xmlWriter.WriteEndElement();
        }
        return stringWriter.ToString();
      }
    }

    /// <summary>
    /// Creates an XmlWriter object with secure default property values.
    /// </summary>
    /// <param name="textWriter">Text writer</param>
    /// <returns>New XmlWriter object</returns>
    private static XmlWriter CreateXmlWriter(TextWriter textWriter) => XmlWriter.Create(textWriter, new XmlWriterSettings()
    {
      Encoding = Encoding.UTF8,
      OmitXmlDeclaration = true
    });

    /// <summary>
    /// Creates an XmlReader object with secure default property values.
    /// </summary>
    /// <param name="xml">The string to get the data from.</param>
    /// <returns>the new XmlReader object</returns>
    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "StringReader required for life of XmlReader")]
    private static XmlReader CreateXmlReader(string xml)
    {
      var settings = new XmlReaderSettings()
      {
        CloseInput = true,
        IgnoreWhitespace = true
      };
      return XmlReader.Create(new StringReader(xml), settings);
    }
  }
}
