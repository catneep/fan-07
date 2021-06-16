using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using fan_07.Data;
using fan_07.Models;

namespace fan_07.Services
{
    public interface ICartService
    {
        List<CartItem> Productos { get; set; }
        decimal Total();
        Task<Pedido> Checkout(ApplicationUser user, string direccion);
    }

    public class CartService : ICartService
    {
        private readonly ApplicationDbContext dbContext;
        public CartService(ApplicationDbContext _dbContext){
            this.dbContext = _dbContext;
            this.Productos = new List<CartItem>();
        }
        public List<CartItem> Productos { get; set; }

        public async Task<Pedido> Checkout(ApplicationUser user, string direccion)
        {
            Pedido p = new Pedido{
                Total = Total(),
                Usuario = user,
                Direccion = direccion
            };
            await dbContext.Pedidos.AddAsync(p);
            return p;
        }

        public decimal Total()
        {
            decimal total = new decimal();
            foreach (var item in Productos)
            {
                total += item.Producto.Precio * item.Cantidad;
            }
            return total;
        }
    }
}