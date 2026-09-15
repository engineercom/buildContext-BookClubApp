using BookClubApp.DataAccess.Repositories;
using BookClubApp.Entity.Entities;


namespace BookClubApp.Business.Services;

public class AuthorService : IAuthorService
{
    private readonly IGenericRepository<Author> _repository;

    public AuthorService(IGenericRepository<Author> repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(Author author)
    {
       await _repository.AddAsync(author);
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Author author)
    {
       _repository.Delete(author);
        await _repository.SaveChangesAsync();
    }

    public async Task<List<Author>> GetAllAsync() => await _repository.GetAllAsync();
   

    public async Task<Author?> GetByIdAsync(int id)=>await _repository.GetByIdAsync(id);
   

    public async Task UpdateAsync(Author author)
    {
        _repository.Update(author);
        await _repository.SaveChangesAsync();
    }
}
