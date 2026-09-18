using BookClubApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookClubApp.DataAccess.Repositories
{
    public interface IBookRepository:IGenericRepository<Book>
    {
        Task<List<Book>> GetAllParamsAsync(params Expression<Func<Book, object>>[] includes);
        Task<Book?> GetByIdParamsAsync(int id,params Expression<Func<Book, object>>[] includes);
    }
}
