using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkShortener.Common.Interfaces.Services
{
    public interface ILinksService
    {
        /// <summary>
        /// Генерурием краткую ссылку
        /// </summary>
        /// <param name="link">Оригинальная ссылка</param>
        /// <returns></returns>
        
        Task<Object> Create(String link);

        /// <summary>
        /// Получаем все сгенерированные ссылки
        /// </summary>
        /// <returns></returns>
        
        Task<IEnumerable<Object>> GetAll();

        /// <summary>
        /// Получаем орининальную ссылку по краткой ссылке
        /// </summary>
        /// <param name="link">Краткая ссылка</param>
        /// <returns></returns>
        
        Task<String> Get(String link);
    }
}
