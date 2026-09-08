

using Newtonsoft.Json;
using System;

namespace MOD.Pms.Documents
{
    public  class JsonToByteArrayConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(byte[]);
        }

        public override object ReadJson(JsonReader reader, Type objectType,object exisitingValue, JsonSerializer serializer)
        {
           throw new NotImplementedException();
        }

      

   
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            byte[] arr = (byte[])value;
            writer.WriteRaw(BitConverter.ToString(arr).Replace("-", ""));
        }
    }
}