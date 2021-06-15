using System.IO;
using System.Linq;
using Core.Enums;
using WebApi.Dto;

namespace WebApi.Providers
{
    public class DriveProvider
    {
        public FSNodeBaseInfo[] GetDrives()
        {
            return DriveInfo.GetDrives()
                .Select(x => new FSNodeBaseInfo { Name = x.Name, Path = x.Name, Type = FSObjectType.Drive })
                .ToArray();
        }
    }
}