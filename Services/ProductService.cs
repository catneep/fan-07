using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using fan_07.Data;
using fan_07.Models;

namespace fan_07.Services
{
    public interface IProductService
    {
        Task<Producto> Register(Producto p);
        Task<List<Producto>> Search(string filter);
        Task<List<Producto>> GetAll();
        Task<List<Producto>> GetAll(Categoria c);
        Task<List<Producto>> GetAll(Subcategoria s);
        Task<Producto> GetById(string id);
        Task<Producto> Modify(Producto p);
        Task<Producto> Delete(Producto p);
        Task<List<Producto>> GetRelated(Producto p);
    }

    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext dbContext;
        public ProductService(ApplicationDbContext _dbContext){
            dbContext = _dbContext;
        }
        public Task<Producto> Delete(Producto p)
        {
            throw new NotImplementedException();
        }

        public Task<List<Producto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Producto>> GetAll(Categoria c)
        {
            throw new NotImplementedException();
        }

        public Task<List<Producto>> GetAll(Subcategoria s)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Producto>> GetRelated(Producto p)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> Modify(Producto p)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> Register(Producto p)
        {
            throw new NotImplementedException();
        }

        public Task<List<Producto>> Search(string filter)
        {
            throw new NotImplementedException();
        }
    }
}