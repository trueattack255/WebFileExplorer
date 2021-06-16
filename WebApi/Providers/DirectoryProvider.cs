using System.Linq;
using WebApi.Args;
using WebApi.Contracts;
using WebApi.Dto;
using static WebApi.Helpers.FSDictionaryHelper;

namespace WebApi.Providers
{
	public class DirectoryProvider : IDataProvider<FSNodeInfo[]>
	{
		public FSNodeInfo[] GetData(FSBaseInfoArgs args)
		{
			return GetDirectory(args.Path, args.SortMode, args.SortDirection, args.Filter)
				.Select(FSNodeInfo.Projection)
				.ToArray();
		}
	}
}
