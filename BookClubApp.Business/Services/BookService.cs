using BookClubApp.DataAccess.Repositories;
using BookClubApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookClubApp.Business.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository; 
    }

    public async Task AddAsync(Book book)
    {
        await _repository.AddAsync(book);
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Book book)
    {
        _repository.Delete(book);
        await _repository.SaveChangesAsync();
    }

    public async Task<List<Book>> GetAllAsync()=>await _repository.GetAllAsync();

    public async Task<List<Book>> GetAllParamsAsync(params Expression<Func<Book, object>>[] includes)
    {
        return await _repository.GetAllParamsAsync(includes);
    }

    public async Task<Book?> GetByIdAsync(int id)=>await _repository.GetByIdAsync(id);

    public async Task<Book?> GetbyIdParamsAsync(int id, params Expression<Func<Book, object>>[] includes)
    {
        return await _repository.GetByIdParamsAsync(id,includes);
    }

    public async Task SaveChangesAsync()
    {
        await _repository.SaveChangesAsync();
    }

    public async Task UpdateAsync(Book book)
    {
        _repository.Update(book);
        await _repository.SaveChangesAsync();
    }
}
