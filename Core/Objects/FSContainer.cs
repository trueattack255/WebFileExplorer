using System.Collections.Generic;

namespace Core.Objects
{
    public abstract class FSContainer : FSNode
    {
        public abstract List<FSNode> Objects { get; }
    }
}