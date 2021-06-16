using System.IO;
using System.Linq;
using Common.Enums;
using Core.Comparers;
using Core.Enums;
using Core.Implementations.Containers;
using Core.Objects;
using FS = Common.Exceptions;

namespace WebApi.Helpers
{
    public class FSDictionaryHelper
    {
        private FSDictionaryHelper()
        { }
        
        public static FSNode[] GetDirectory(string path, SortMode sort, SortDirection sortDirection, FSObjectFilter filter)
        {
            var info = new DirectoryInfo(path);

            if (!info.Exists)
                throw new FS.DirectoryNotFoundException(path);

            var directory = FSDirectory.Load(info, filter);
            return directory.Objects
                .OrderBy(x => x, new FSNodeComparer(sort, sortDirection))
                .ToArray();
        }
    }
}