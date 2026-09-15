

using BookClubApp.Entity.Entities;

namespace BookClubApp.Business.Services;

public interface IAuthorService
{
    Task<List<Author>> GetAllAsync();
    Task<Author?> GetByIdAsync(int id);
    Task AddAsync(Author author);
    Task UpdateAsync(Author author);
    Task DeleteAsync(Author author);
    Task SaveChangesAsync();
}
