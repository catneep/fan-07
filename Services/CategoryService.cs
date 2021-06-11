using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fan_07.Data;
using fan_07.Models;
using Microsoft.EntityFrameworkCore;

namespace fan_07.Services
{
    public interface ICategoryService
    {
        Task<ICollection<Categoria>> GetCategories();
        Task<Categoria> CreateCategory(Categoria categoria);
        Task<Subcategoria> CreateSubcategory(Subcategoria subcategoria);
        Task<Categoria> ModifyCategory(Categoria categoria);
        Task<Subcategoria> ModifySubcategory(Subcategoria subcategoria);
        Task<Categoria> DeleteCategory(Categoria categoria);
        Task<Subcategoria> DeleteSubcategory(Subcategoria subcategoria);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryService(ApplicationDbContext _dbContext){
            dbContext = _dbContext;
        }
        public Task<Categoria> CreateCategory(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<Subcategoria> CreateSubcategory(Subcategoria subcategoria)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> DeleteCategory(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<Subcategoria> DeleteSubcategory(Subcategoria subcategoria)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Categoria>> GetCategories()
        {
            return await dbContext.Categorias.ToListAsync();
        }

        public Task<Categoria> ModifyCategory(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<Subcategoria> ModifySubcategory(Subcategoria subcategoria)
        {
            throw new NotImplementedException();
        }
    }
}