using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using fan_07.Data;
using fan_07.Models;
using Microsoft.EntityFrameworkCore;

namespace fan_07.Services
{
    public interface IProductService
    {
        Task<bool> Exists(Producto p);
        Task<Producto> Register(Producto p);
        Task<List<Producto>> Search(string filter);
        Task<List<Producto>> GetAll();
        Task<List<Producto>> GetAll(Categoria c);
        Task<List<Producto>> GetAll(Subcategoria s);
        Task<Producto> GetById(string id);
        Task<Producto> Modify(Producto p);
        Task<Producto> Delete(Producto p);
        Task<List<Producto>> GetRelated(Producto p);
        Task<List<string>> GetImages(Producto p);
    }

    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext dbContext;
        public ProductService(ApplicationDbContext _dbContext){
            dbContext = _dbContext;
        }
        public async Task<Producto> Delete(Producto p)
        {
            dbContext.Productos.Remove(p);
            await dbContext.SaveChangesAsync();
            return p;
        }

        public async Task<bool> Exists(Producto producto)
        {
            return await dbContext.Productos.AnyAsync(p => p.Id == producto.Id);
        }

        public async Task<List<Producto>> GetAll()
        {
            return await dbContext.Productos.ToListAsync();
        }

        public async Task<List<Producto>> GetAll(Categoria c)
        {
            return await dbContext.Productos
                .Where(p => p.Subcategoria.Categoria.Id == c.Id).ToListAsync();
        }

        public async Task<List<Producto>> GetAll(Subcategoria s)
        {
            return await dbContext.Productos
                .Where(p => p.Subcategoria.Id == s.Id).ToListAsync();
        }

        public async Task<Producto> GetById(string id)
        {
            try
            {
                var parse = Guid.Parse(id);

                var producto =
                    await dbContext.Productos
                    .Include(p => p.Imagenes)
                    .Include(p => p.Subcategoria)
                    .ThenInclude(s => s.Categoria)
                    .FirstAsync(p => p.Id == parse);

                return producto;
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error en formato {e}");
                return null;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Error {e}");
                return null;
            }
            
        }

        public async Task<List<string>> GetImages(Producto producto)
        {
            var images = await dbContext.ImagenesProducto.Where(i => i.Producto.Id == producto.Id).ToListAsync();
            
            var res = new List<string>();

            if (images != null && images.Count > 0)
                foreach (var img in images)
                    res.Add(img.Imagen);
                
            return res;
        }

        public async Task<List<Producto>> GetRelated(Producto producto)
        {
            return await dbContext.Productos
                .Where(p => p.Subcategoria.Id == producto.Subcategoria.Id)
                .Where(p => p.Id != producto.Id)
                .Take(3).ToListAsync();
        }

        public async Task<Producto> Modify(Producto p)
        {
            dbContext.Productos.Update(p);
            await dbContext.SaveChangesAsync();
            return p;
        }

        public async Task<Producto> Register(Producto p)
        {
            await dbContext.Productos.AddAsync(p);
            await dbContext.SaveChangesAsync();
            return p;
        }

        public async Task<List<Producto>> Search(string filter)
        {
            return await dbContext.Productos
                .Where(p => p.Nombre.ToLower().Contains($"{filter.ToLower()}")).ToListAsync();
        }
    }
}