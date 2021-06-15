using Core.Enums;

namespace WebApi.Dto
{
    public class FSNodeBaseInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public FSObjectType Type { get; set; }
    }
}