using Core.Enums;

namespace Core.Objects
{
    public abstract class FSObject
    {
        public abstract string Name { get;}
        public abstract string Path { get;}

        public abstract FSObjectType Type { get; }
        
        public override string ToString() => Path;
    }
}