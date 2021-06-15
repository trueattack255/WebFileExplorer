using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Common.Helpers;

namespace Common.Extensions
{
    public static class DirectoryInfoExtensions
    {
        public static long GetDirectorySize(this DirectoryInfo directoryInfo)
        {
            var startDirectorySize = default(long);
            if (directoryInfo == null || !directoryInfo.Exists)
            {
                return startDirectorySize;
            }

            foreach (var fileInfo in FaultWrapper.Do(directoryInfo.GetFiles).EmptyIfNull())
            {
                Interlocked.Add(ref startDirectorySize, fileInfo.Length);
            }

            Parallel.ForEach(FaultWrapper.Do(directoryInfo.GetDirectories).EmptyIfNull(), subDirectory =>
            {
                Interlocked.Add(ref startDirectorySize, GetDirectorySize(subDirectory));
            });

            return startDirectorySize;
        }
    }
}