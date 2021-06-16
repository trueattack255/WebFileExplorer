using System.Text.Json.Serialization;
using Core.Enums;

namespace WebApi.Dto
{
    public class FSNodeBaseInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public FSObjectType Type { get; set; }
        
        [JsonPropertyName("modified")]
        public string DateModified { get; set; }
    }
}