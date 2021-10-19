using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientConsole
{
    public class JsonData
    {
        [JsonPropertyName("LocalTime")]
        public DateTime LocalTime { get; set; }
        [JsonPropertyName("CurrentUser")]
        public string UserName { get; set; }
        [JsonPropertyName("VersionWindow")]
        public string vrWindow { get; set; }
        public JsonData()
        {
            this.LocalTime = DateTime.Now;
            this.UserName = Environment.UserName.ToString();
            this.vrWindow = Environment.OSVersion.ToString();
        }
    }
}
