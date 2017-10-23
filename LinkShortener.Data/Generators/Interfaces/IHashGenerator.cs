using System;

namespace LinkShortener.Data.Generators.Interfaces
{
    /// <summary>
    /// Генератор хэшей строк
    /// </summary>
    public interface IHashGenerator
    {
        /// <summary>
        /// Получение нового уникального идентификатора
        /// </summary>
        /// <returns></returns>
        String GetHash(String source);
    }
}
