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
        Pedido Checkout();
        int Count();
        Direccion Direccion { get; set; }
        Pago MetodoPago { get; set; }
    }

    public class CartService : ICartService
    {
        public List<CartItem> Productos { get; set; }
        public Direccion Direccion { get; set; }
        public Pago MetodoPago { get; set; }
        public CartService(){
            Direccion = null;
            MetodoPago = null;
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
        public decimal Total()
        {
            decimal total = new decimal();
            foreach (var item in Productos)
            {
                total += item.Producto.Precio * item.Cantidad;
            }
            return total;
        }
        public Pedido Checkout()
        {
            var p = new Pedido();
            if (Direccion == null)
                p.Direccion = "Test Address";
            else
                p.Direccion = this.Direccion.Domicilio;
            p.Total = Total();

            var list = new List<Producto>();
            foreach (var prod in Productos){
                list.Add(prod.Producto);
                Console.WriteLine($"Añadido: {prod.Producto.Id.ToString()} a Pedido");
            }

            p.Productos = list;
            return p;
        }
    }
}