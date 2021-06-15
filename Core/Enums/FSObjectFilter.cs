namespace Core.Enums
{
    /// <summary>
    /// Представляет типы фильтрации объектов файловой системы
    /// </summary>
    public enum FSObjectFilter
    {
        /// <summary>
        /// Все
        /// </summary>
        All = 0,

        /// <summary>
        /// Только директории
        /// </summary>
        Directories = 1,

        /// <summary>
        /// Только файлы
        /// </summary>
        Files = 2
    }
}
