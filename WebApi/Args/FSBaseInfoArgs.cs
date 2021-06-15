using Common.Enums;
using Core.Enums;

namespace WebApi.Args
{
    public class FSBaseInfoArgs
    {
        public string Path { get; set; }
        public SortMode SortMode { get; set; }
        public SortDirection SortDirection { get; set; }
        public FSObjectFilter Filter { get; set; }
    }
}