using System.IO;
using Common.Enums;
using Core.Comparers;
using Core.Enums;
using Core.Implementations.Containers;
using FS = Common.Exceptions;

namespace WebApi.Helpers
{
    public class FSDictionaryHelper
    {
        private FSDictionaryHelper()
        { }
        
        public static FSDirectory GetDirectory(string path, SortMode sort, SortDirection sortDirection, FSObjectFilter filter)
        {
            var info = new DirectoryInfo(path);

            if (!info.Exists)
                throw new FS.DirectoryNotFoundException(path);

            var directory = FSDirectory.Load(info, filter);
            var comparer = new FSNodeComparer(sort, sortDirection);
            directory.Objects.Sort(comparer);

            return directory;
        }
    }
}