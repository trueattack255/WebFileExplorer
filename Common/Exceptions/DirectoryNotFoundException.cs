namespace Common.Exceptions
{
    public class DirectoryNotFoundException : AppBaseException
    {
        public DirectoryNotFoundException(string path) : base($"Could not find a part of the path {path}")
        { }
    }
}