using System.Linq;
using WebApi.Args;
using WebApi.Contracts;
using WebApi.Dto;
using WebApi.Helpers;

namespace WebApi.Providers
{
    public sealed class DriveProvider : IDataProvider<FSNodeExtendedInfo[]>
    {
        public FSNodeExtendedInfo[] GetData(FSBaseInfoArgs args)
        {
            return FSNodeHelper.GetRoot(args.Path, args.SortMode, args.SortDirection)
                .Select(FSNodeExtendedInfo.Projection)
                .ToArray();
        }
    }
}