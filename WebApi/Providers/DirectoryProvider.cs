using System.IO;
using Common.Enums;
using Core.Comparers;
using Core.Enums;
using Core.Implementations.Containers;
using WebApi.Dto;

namespace WebApi.Providers
{
	internal sealed class DirectoryProvider
	{
		readonly SortMode _sort;
	    readonly SortDirection _sortDirection;
	    
	    readonly DirectoryInfo _directory;

	    internal DirectoryProvider (DirectoryInfo directory, SortMode sort, SortDirection sortDirection) 
	    {
		    _directory = directory;
			_sort = sort;
			_sortDirection = sortDirection;
		}

	    public FSNodeInfo GetInfo(FSObjectFilter filter)
	    {
		    return FSNodeInfo.Projection(GetInfoInternal(filter));
	    }
	    
		public FSNodeExtendedInfo GetDetailedInfo(FSObjectFilter filter)
		{
			return FSNodeExtendedInfo.Projection(GetInfoInternal(filter));
		}

		private FSDirectory GetInfoInternal(FSObjectFilter filter)
		{
			if (!_directory.Exists)
				return null;

			var dir = FSDirectory.Load(_directory, filter);
			var comparer = new FSNodeComparer(_sort, _sortDirection);
			dir.Objects.Sort(comparer);

			return dir;
		}
	}
}
