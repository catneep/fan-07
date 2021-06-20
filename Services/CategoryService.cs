using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using fan_07.Data;
using fan_07.Models;
using Microsoft.EntityFrameworkCore;

namespace fan_07.Services
{
    public interface ICategoryService
    {
        Task<bool> Exists(Categoria c);
        Task<bool> Exists(Subcategoria s);
        Task<Categoria> GetForProduct(Producto producto);
        Task<Categoria> GetCategory(string id);
        Task<Categoria> GetCategoryByName(string name);
        Task<Subcategoria> GetSubcategoryByName(string name);
        Task<ICollection<Categoria>> GetCategories();
        Task<ICollection<Subcategoria>> GetSubcategories(Categoria categoria);
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
            await dbContext.SaveChangesAsync();
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

        public async Task<bool> Exists(Categoria cat)
        {
            return await
                dbContext.Categorias.AnyAsync(c => c.Id == cat.Id);
        }

        public async Task<bool> Exists(Subcategoria sub)
        {
            return await
                dbContext.Subcategorias.AnyAsync(s => s.Id == sub.Id);
        }

        public async Task<ICollection<Categoria>> GetCategories()
        {
            return await dbContext.Categorias
            .Include(c => c.Subcategorias)
            .ToListAsync();
        }

        public async Task<Categoria> GetCategory(string id)
        {
            return await dbContext.Categorias.Where(c => c.Id == Guid.Parse(id))
            .Include(c => c.Subcategorias)
            .FirstAsync();
        }

        public async Task<Categoria> GetCategoryByName(string name)
        {
            return await dbContext.Categorias.Where(c => c.Nombre == name)
            .Include(c => c.Subcategorias)
            .FirstOrDefaultAsync();
        }

        public async Task<Categoria> GetForProduct(Producto producto)
        {
            return await dbContext.Categorias.Where(c => c.Id == producto.Subcategoria.Categoria.Id)
            .Include(c => c.Subcategorias)
            .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Subcategoria>> GetSubcategories(Categoria categoria)
        {
            return await dbContext.Subcategorias.Where(s => s.Categoria.Id == categoria.Id)
            .ToListAsync();
        }

        public async Task<Subcategoria> GetSubcategoryByName(string name)
        {
            return
                await dbContext.Subcategorias.Where(s => s.Nombre == name)
                .FirstOrDefaultAsync();
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