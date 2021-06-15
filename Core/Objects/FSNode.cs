using System;

namespace Core.Objects
{
    public abstract class FSNode : FSObject
    {
        public abstract string Extension { get; }
        public abstract long Size { get; }
        
        public abstract bool Exists { get;}
        public abstract bool IsLeaf { get;}
        
        public abstract DateTime CreationTime { get; }
        public abstract DateTime LastAccessTime { get; }
        public abstract DateTime LastWriteTime { get; }
    }
}