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
        public async Task<Categoria> CreateCategory(Categoria categoria)
        {
            await dbContext.Categorias.AddAsync(categoria);
            // foreach (var sub in categoria.Subcategorias)
            // {
            //     await CreateSubcategory(sub);
            // }
            return categoria;
        }

        public async Task<Subcategoria> CreateSubcategory(Subcategoria subcategoria)
        {
            await dbContext.Subcategorias.AddAsync(subcategoria);
            return subcategoria;
        }

        public async Task<Categoria> DeleteCategory(Categoria categoria)
        {
            dbContext.Categorias.Remove(categoria);
            await dbContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Subcategoria> DeleteSubcategory(Subcategoria subcategoria)
        {
            dbContext.Subcategorias.Remove(subcategoria);
            await dbContext.SaveChangesAsync();
            return subcategoria;
        }

        public async Task<ICollection<Categoria>> GetCategories()
        {
            return await dbContext.Categorias.ToListAsync();
        }

        public async Task<Categoria> ModifyCategory(Categoria categoria)
        {
            dbContext.Categorias.Update(categoria);
            await dbContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Subcategoria> ModifySubcategory(Subcategoria subcategoria)
        {
            dbContext.Subcategorias.Update(subcategoria);
            await dbContext.SaveChangesAsync();
            return subcategoria;
        }
    }
}