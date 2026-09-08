using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Pms.Documents
{
    public class FileDto
    {
        //[JsonConverter(typeof(JsonToByteArrayConverter))]
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
    }
}
