using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;
using UnityEngine;

class ColorConverter : JsonConverter<Color>
{
    public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        JObject jsonObject = JObject.Load(reader);

        return jsonObject.ToObject<Color>(serializer);
    }

    public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
    {
        var s = Regex.Unescape(JsonUtility.ToJson(value));
        writer.WriteRawValue(s);
    }
}

