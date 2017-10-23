using System;

namespace LinkShortener.Data.Generators
{
    using Interfaces;

    public class HashGenerator : IHashGenerator
    {
        private readonly Random mRandom = new Random();
        private const String mChars = "abcdefghijclmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        /// <summary>
        /// В данном случае генерируем уникальную строку без учета исходника, что даст возможность хранить одинаковые ссылки для 
        /// одного пользователя
        /// </summary>
        /// <param name="source">В реализации не используется</param>
        /// <returns></returns>
        public String GetHash(String source)
        {
            return RandomString(6);
        }

        private string RandomString(Int32 size)
        {
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = mChars[mRandom.Next(mChars.Length)];
            }
            return new String(buffer);
        }
    }
}
