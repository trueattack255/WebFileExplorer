using System.IO;
using Common.Enums;
using Core.Comparers;
using Core.Enums;
using Core.Implementations.Containers;
using WebApi.Args;
using WebApi.Contracts;
using WebApi.Dto;
using static WebApi.Helpers.FSDictionaryHelper;

namespace WebApi.Providers
{
	internal class DirectoryProvider : IDataProvider<FSNodeInfo>
	{
		public FSNodeInfo GetData(FSBaseInfoArgs args)
		{
			return FSNodeInfo.Projection(GetDirectory(args.Path, args.SortMode, args.SortDirection, args.Filter));
		}
	}
}
