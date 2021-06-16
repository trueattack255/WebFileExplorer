using System.ComponentModel.DataAnnotations;
using Common.Constants;
using Common.Enums;
using Core.Enums;

namespace WebApi.Args
{
    public class FSBaseInfoArgs
    {
        [Required]
        [RegularExpression(CommonConstants.PathRegexp, ErrorMessage = "Path validation error")]
        public virtual string Path { get; set; }
        public virtual SortMode SortMode { get; set; }
        public virtual SortDirection SortDirection { get; set; }
        public virtual FSObjectFilter Filter { get; set; }
    }
}