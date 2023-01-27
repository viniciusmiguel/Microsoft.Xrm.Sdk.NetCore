using Microsoft.Xrm.Sdk.Organization;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Xrm.Sdk.JsonConverters
{
  /// <summary>Converts EndpointCollection from JSON</summary>
  [SecurityCritical]
  internal class EndpointCollectionConverter : JsonConverter<EndpointCollection>
  {
    /// <summary>
    /// <see cref="!:JsonConverter.Read" />
    /// </summary>
    [SecurityCritical]
    public override EndpointCollection Read(
      ref Utf8JsonReader reader,
      Type typeToConvert,
      JsonSerializerOptions options)
    {
      var endpointCollection = new EndpointCollection();
      List<string> stringList1 = null;
      List<string> stringList2 = null;
      var flag = false;
      while (!flag && reader.Read())
      {
        var tokenType = reader.TokenType;
        if (tokenType != (JsonTokenType)2)
        {
          if (tokenType == (JsonTokenType)5)
          {
            if (reader.GetString().ToLowerInvariant() == "keys")
              stringList1 = ReadArray(ref reader);
            else if (reader.GetString().ToLowerInvariant() == "values")
              stringList2 = ReadArray(ref reader);
          }
        }
        else
          flag = true;
      }
      if (stringList1 == null || stringList2 == null)
        return endpointCollection;
      if (stringList1.Count != stringList2.Count)
        throw new JsonException(string.Format("Number of keys({0}) should equal number of values({1})", stringList1.Count, stringList2.Count));
      for (var index = 0; index < stringList1.Count; ++index)
      {
        EndpointType result;
        if (!Enum.TryParse<EndpointType>(stringList1[index], out result))
          throw new JsonException("Unable to parse EndpointType: '" + stringList1[index] + "'");
        endpointCollection.Add(result, stringList2[index]);
      }
      return endpointCollection;
    }

    private List<string> ReadArray(ref Utf8JsonReader reader)
    {
      List<string> stringList = null;
      while (reader.Read())
      {
        switch ((int) reader.TokenType - 1)
        {
          case 0:
          case 1:
            throw new JsonException("Unexpected object");
          case 2:
            stringList = stringList == null ? new List<string>() : throw new JsonException("Unexpected array");
            continue;
          case 3:
            return stringList;
          case 4:
            throw new JsonException();
          case 6:
            if (stringList == null)
              throw new JsonException();
            stringList.Add(reader.GetString());
            continue;
          case 7:
            throw new JsonException();
          default:
            continue;
        }
      }
      throw new JsonException();
    }

    [SecurityCritical]
    public override void Write(
      Utf8JsonWriter writer,
      EndpointCollection value,
      JsonSerializerOptions options)
    {
      throw new NotImplementedException();
    }

    [SecurityCritical]
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof (EndpointCollection) || base.CanConvert(typeToConvert);
  }
}
