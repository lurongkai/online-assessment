using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oas.Domain.Application;

namespace Oas.Domain.Repository
{
    public interface INewsRepository
    {
        IEnumerable<News> LoadTopNews(int count);
        void CreateNews(News news);
    }
}
