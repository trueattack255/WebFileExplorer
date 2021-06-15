using WebApi.Args;
using WebApi.Contracts;
using WebApi.Dto;
using static WebApi.Helpers.FSDictionaryHelper;

namespace WebApi.Providers
{
	internal class DetailDirectoryProvider : IDataProvider<FSNodeExtendedInfo>
	{
		public FSNodeExtendedInfo GetData(FSBaseInfoArgs args)
		{
			return FSNodeExtendedInfo.Projection(GetDirectory(args.Path, args.SortMode, args.SortDirection, args.Filter));
		}
	}
}
