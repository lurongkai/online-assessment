using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oas.Domain.Repository;

namespace Oas.Infrastructure.Repository
{
    public class NewsRepository : INewsRepository
    {
        private OasContext _oasContext;
        public NewsRepository(OasContext oasContext) {
            _oasContext = oasContext;
        }

        public IEnumerable<Domain.Application.News> LoadTopNews(int count) {
            throw new NotImplementedException();
        }

        public void CreateNews(Domain.Application.News news) {
            throw new NotImplementedException();
        }
    }
}
