using BookClubApp.DataAccess.Repositories;
using BookClubApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClubApp.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _repository;

        public CategoryService(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Category category)
        {
            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _repository.Delete(category);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync() => await _repository.GetAllAsync();
        

        public async Task<Category?> GetByIdAsync(int id)=>await _repository.GetByIdAsync(id);

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _repository.Update(category);
            await _repository.SaveChangesAsync();
        }
    }
}
