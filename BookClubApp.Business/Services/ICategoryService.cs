
using BookClubApp.Entity.Entities;

namespace BookClubApp.Business.Services;

public interface ICategoryService
{
    Task<List<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Category category);
    Task SaveChangesAsync();
}

