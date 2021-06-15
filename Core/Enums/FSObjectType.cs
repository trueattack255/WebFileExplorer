namespace Core.Enums
{
    /// <summary>
    /// Представляет типы объектов файловой системы
    /// </summary>
    public enum FSObjectType
    {
        /// <summary>
        /// Диск
        /// </summary>
        Drive = 0,
        
        /// <summary>
        /// Директория
        /// </summary>
        Directory = 1,
        
        /// <summary>
        /// Файл
        /// </summary>
        File = 2
    }
}