using Common.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi.Args
{
    public class FSInfoArgs : FSBaseInfoArgs
    {
        [BindNever]
        public override SortMode SortMode => SortMode.Name;

        [BindNever]
        public override SortDirection SortDirection => SortDirection.Ascending;
    }
}