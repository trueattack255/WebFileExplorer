using System.IO;
using System.Linq;
using Core.Implementations.Containers;
using WebApi.Args;
using WebApi.Contracts;
using WebApi.Dto;

namespace WebApi.Providers
{
    public sealed class DriveProvider : IDataProvider<FSNodeExtendedInfo[]>
    {
        public FSNodeExtendedInfo[] GetData(FSBaseInfoArgs args)
        {
            return DriveInfo.GetDrives()
                .Select(x => new FSDrive(x))
                .Select(FSNodeExtendedInfo.Projection)
                .ToArray();
        }
    }
}