using Common.Enums;
using Core.Enums;

namespace WebApi.Args
{
    public abstract class FSBaseInfoArgs
    {
        public virtual string Path { get; set; }
        public virtual SortMode SortMode { get; set; }
        public virtual SortDirection SortDirection { get; set; }
        public virtual FSObjectFilter Filter { get; set; }
    }
}