using BookClubApp.DataAccess.Repositories;
using BookClubApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClubApp.Business.Services;

public class BookService : IBookService
{
    private readonly IGenericRepository<Book> _repository;

    public BookService(IGenericRepository<Book> repository)
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
   

    public async Task<Book?> GetByIdAsync(int id)=>await _repository.GetByIdAsync(id);

    public async Task UpdateAsync(Book book)
    {
        _repository.Update(book);
        await _repository.SaveChangesAsync();
    }
}
