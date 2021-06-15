using System;
using System.IO;
using Common.Constants;
using Core.Enums;
using Core.Objects;
using static System.IO.Path;

namespace Core.Implementations
{
    public class FSFile : FSNode
    {
        public override string Path => Combine(_fileInfo.DirectoryName ?? string.Empty, _fileInfo.Name);
        public override string Name => GetFileNameWithoutExtension(_fileInfo.Name);
        public override string Extension => _fileInfo.Extension;
        public override long Size => _fileInfo.Length >> CommonConstants.Shift;

        public override bool Exists => _fileInfo.Exists;
        public override bool IsLeaf => true;
        public override FSObjectType Type => FSObjectType.File;

        public override DateTime CreationTime => _fileInfo.CreationTime;
        public override DateTime LastAccessTime => _fileInfo.LastAccessTime;
        public override DateTime LastWriteTime => _fileInfo.LastWriteTime;
        
        private readonly FileInfo _fileInfo;

        public FSFile(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }
    }
}