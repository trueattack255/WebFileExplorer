using Core.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi.Args
{
    public class FSDriveInfoArgs : FSBaseInfoArgs
    {
        [BindNever] 
        public override string Path { get; set; }

        [BindNever]
        public override FSObjectFilter Filter { get; set; }
    }
}