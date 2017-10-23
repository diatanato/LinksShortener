using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkShortener.Common.Interfaces.Services
{
    using Models;

    public interface ILinksService
    {
        /// <summary>
        /// Генерурием короткую ссылку
        /// </summary>
        /// <param name="link">Оригинальная ссылка</param>
        /// <param name="user">Уникальный идентификатор пользователя, создающего ссылку</param>
        /// <returns></returns>

        Task<String> Create(String link, Guid user);

        /// <summary>
        /// Получаем все сгенерированные ссылки для указанного пользователя
        /// </summary>
        /// <returns></returns>

        Task<IEnumerable<ILinkInformation>> GetAll(Guid user);

        /// <summary>
        /// Получаем орининальную ссылку по краткой ссылке
        /// </summary>
        /// <param name="link">Краткая ссылка</param>
        /// <returns></returns>

        Task<String> Get(String link);
    }
}
