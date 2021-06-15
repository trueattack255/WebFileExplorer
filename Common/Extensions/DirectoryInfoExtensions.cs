using System.IO;
using System.Threading;
using System.Threading.Tasks;

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

            foreach (var fileInfo in directoryInfo.GetFiles())
            {
                Interlocked.Add(ref startDirectorySize, fileInfo.Length);
            }

            Parallel.ForEach(directoryInfo.GetDirectories(), subDirectory =>
            {
                Interlocked.Add(ref startDirectorySize, GetDirectorySize(subDirectory));
            });

            return startDirectorySize;
        }
    }
}