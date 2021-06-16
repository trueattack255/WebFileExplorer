namespace Common.Exceptions
{
    public class DirectoryNotFoundException : AppBaseException
    {
        public DirectoryNotFoundException(string path) : base($"Не удалось найти часть пути {path}")
        { }
    }
}