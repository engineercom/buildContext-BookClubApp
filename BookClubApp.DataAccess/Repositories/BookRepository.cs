using BookClubApp.DataAccess.Context;
using BookClubApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookClubApp.DataAccess.Repositories;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context): base(context) 
    {
        _context = context;
    }

    public async Task<List<Book>> GetAllParamsAsync(params Expression<Func<Book, object>>[] includes)
    {
        IQueryable<Book> query = _context.Books;
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return await query.ToListAsync();
    }

    public async Task<Book?> GetByIdParamsAsync(int id,params Expression<Func<Book, object>>[] includes)
    {
        IQueryable<Book> query = _context.Books;

        foreach (var include in includes)
        {

            query = query.Include(include);
        }
        return await query.FirstOrDefaultAsync(b=>b.Id==id);
    }
}
