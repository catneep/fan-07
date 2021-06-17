using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using fan_07.Models;

namespace fan_07.Services
{
    public interface ICartService
    {
        List<CartItem> Productos { get; set; }
        decimal Total();
        int Count();
    }

    public class CartService : ICartService
    {
        public CartService(){
            if (Productos == null)
                Productos = new List<CartItem>();
        }

        public int Count()
        {
            int result = 0;
            foreach (var item in Productos)
            {
                result += item.Cantidad;
            }
            return result;
        }

        public List<CartItem> Productos { get; set; }

        // public async Task<Pedido> Checkout(ApplicationUser user, string direccion)
        // {
        //     Pedido p = new Pedido{
        //         Total = Total(),
        //         Usuario = user,
        //         Direccion = direccion
        //     };
        //     return p;
        // }

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