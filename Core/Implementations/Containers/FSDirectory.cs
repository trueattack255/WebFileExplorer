using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common.Constants;
using Common.Extensions;
using Common.Helpers;
using Core.Enums;
using Core.Objects;

namespace Core.Implementations.Containers
{
    public class FSDirectory : FSContainer
    {
        public override string Name => _directory.Name;
        public override string Path => _directory.FullName;
        public override string Extension => _directory.Extension;
        
        public override bool Exists => _directory.Exists;
        public override bool IsLeaf => !FaultWrapper.Do(() => _directory.GetDirectories().Any());

        public override long Size => _size ??= Objects.Sum(x => x.Size);
        
        public override List<FSNode> Objects { get; }
        public override FSObjectType Type => FSObjectType.Directory;

        public override DateTime CreationTime => _directory.CreationTime;
        public override DateTime LastAccessTime => _directory.LastAccessTime;
        public override DateTime LastWriteTime => _directory.LastWriteTime;

        private readonly DirectoryInfo _directory;
        private long? _size;

        public FSDirectory(DirectoryInfo directoryInfo)
        {
            _directory = directoryInfo;

            Objects = new List<FSNode>();
        }

        public static FSDirectory Load(DirectoryInfo directoryInfo, FSObjectFilter filter)
        {
            var instance = new FSDirectory(directoryInfo);
            instance.FillObjects(filter);
            
            return instance;
        }

        private void FillObjects(FSObjectFilter filter)
        {
            switch (filter)
            {
                case FSObjectFilter.Directories:
                    AddChildDirectories();
                    break;
                case FSObjectFilter.Files:
                    AddChildFiles();
                    break;
                default:
                    AddChildDirectories();
                    AddChildFiles();
                    break;
            }

            CalculateChildSize();
        }

        private void CalculateChildSize()
        {
            foreach (var item in Objects.OfType<FSDirectory>())
                item._size = item._directory.GetDirectorySize();
        }

        private void AddChildDirectories()
        {
            Objects.AddRange(FaultWrapper
                .Do(() => _directory.GetDirectories(CommonConstants.SearchTerm, SearchOption.TopDirectoryOnly))
                .EmptyIfNull()
                .Where(x =>
                    !x.Attributes.HasFlag(FileAttributes.Hidden) ||
                    !x.Attributes.HasFlag(FileAttributes.System))
                .Select(x => new FSDirectory(x)));
        }

        private void AddChildFiles()
        {
            Objects.AddRange(FaultWrapper
                .Do(() => _directory.GetFiles(CommonConstants.SearchTerm, SearchOption.TopDirectoryOnly))
                .EmptyIfNull()
                .Where(x =>
                    !x.Attributes.HasFlag(FileAttributes.Hidden) ||
                    !x.Attributes.HasFlag(FileAttributes.System))
                .Select(x => new FSFile(x)));
        }
    }
}