using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinkShortener.Data.Services
{
    using Common.Interfaces.Services;

    public class LinksService : ILinksService
    {
        public Task<object> Create(String link)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<object>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<String> Get(String link)
        {
            return Task<String>.Factory.StartNew(() => "http://yandex.ru"); 
        }
    }
}
