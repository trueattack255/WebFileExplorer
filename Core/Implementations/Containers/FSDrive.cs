using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common.Constants;
using Common.Helpers;
using Core.Enums;
using Core.Objects;

namespace Core.Implementations.Containers
{
    public class FSDrive : FSContainer
    {
        public override string Name => _drive.Name;
        public override string Path => _drive.Name;
        public override FSObjectType Type => FSObjectType.Drive;
        public override string Extension => _drive.RootDirectory.Extension;
        public override long Size => (_drive.TotalSize - _drive.AvailableFreeSpace) >> CommonConstants.Shift;
        public override bool Exists => _drive.RootDirectory.Exists;
        public override bool IsLeaf => !FaultWrapper.Do(() => _drive.RootDirectory.GetDirectories().Any());
        public override DateTime CreationTime => _drive.RootDirectory.CreationTime;
        public override DateTime LastAccessTime => _drive.RootDirectory.LastAccessTime;
        public override DateTime LastWriteTime => _drive.RootDirectory.LastWriteTime;
        public override List<FSNode> Objects { get; }
        
        private readonly DriveInfo _drive;

        public FSDrive(DriveInfo driveInfo)
        {
            _drive = driveInfo;

            Objects = new List<FSNode>();
        }
    }
}