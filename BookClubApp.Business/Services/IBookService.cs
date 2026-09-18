using BookClubApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookClubApp.Business.Services;

public interface IBookService
{
    Task<List<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id);
    Task AddAsync(Book book);
    Task UpdateAsync(Book book);
    Task DeleteAsync(Book book);

    Task SaveChangesAsync();
    //IBookRepository'e sonradan eklenenler
    Task<List<Book>> GetAllParamsAsync(params Expression<Func<Book, object>>[] includes);
    Task<Book?> GetbyIdParamsAsync(int id, params Expression<Func<Book, object>>[] includes);
   

}
