using System.IO;
using System.Linq;
using Core.Enums;
using WebApi.Args;
using WebApi.Contracts;
using WebApi.Dto;

namespace WebApi.Providers
{
    internal sealed class DriveProvider : IDataProvider<FSNodeBaseInfo[]>
    {
        public FSNodeBaseInfo[] GetData(FSBaseInfoArgs args)
        {
            return DriveInfo.GetDrives()
                .Select(x => new FSNodeBaseInfo { Name = x.Name, Path = x.Name, Type = FSObjectType.Drive })
                .ToArray();
        }
    }
}