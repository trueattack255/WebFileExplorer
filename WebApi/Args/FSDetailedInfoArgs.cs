using System.ComponentModel.DataAnnotations;
using Common.Constants;

namespace WebApi.Args
{
    public class FSDetailedInfoArgs : FSBaseInfoArgs
    {
        [Required]
        [RegularExpression(CommonConstants.PathRegexp, ErrorMessage = "Path validation error")]
        public override string Path { get; set; }
    }
}