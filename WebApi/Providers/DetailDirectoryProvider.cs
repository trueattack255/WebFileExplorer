using System.Linq;
using WebApi.Args;
using WebApi.Contracts;
using WebApi.Dto;
using static WebApi.Helpers.FSDictionaryHelper;

namespace WebApi.Providers
{
	public class DetailDirectoryProvider : IDataProvider<FSNodeExtendedInfo[]>
	{
		public FSNodeExtendedInfo[] GetData(FSBaseInfoArgs args)
		{
			return GetDirectory(args.Path, args.SortMode, args.SortDirection, args.Filter)
				.Select(FSNodeExtendedInfo.Projection)
				.ToArray();
		}
	}
}
