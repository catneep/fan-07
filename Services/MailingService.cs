using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fan_07.Data;
using fan_07.Models;
using Microsoft.EntityFrameworkCore;

namespace fan_07.Services
{
    public interface IMailingService
    {
        Task<Distribuidor> RegisterDistribuidor(Distribuidor d);
        Task<Distribuidor> GetDistribuidor(string id);
        Task<Pedido> GetPedido(string id);
        Task<List<Pedido>> GetPedidos();
        Task<List<Pedido>> GetPedidos(ApplicationUser user);
        Task<List<Direccion>> GetDirecciones(ApplicationUser user);
        Task<Pedido> Create(Pedido pedido);
        Task<Pedido> Modify(Pedido pedido);
        Task<Pedido> Delete(Pedido pedido);
    }

    public class MailingService : IMailingService
    {
        private readonly ApplicationDbContext dbContext;
        public MailingService(ApplicationDbContext db)
        {
            this.dbContext = db;
        }
        private DateTime estimateDate(DateTime dateTime, int days)
        {
            DateTime dt = dateTime.AddDays(days);
            return dt;
        }
        public async Task<Pedido> Create(Pedido pedido)
        {
            var distTemp = new Distribuidor{
                Nombre = "Estafeta",
                Correo = "a@a.com",
                Telefono = "5555555555",
                Costo = new decimal(100),
                Dias = 4
            };

            pedido.Envio = new Envio{
                Distribuidor = distTemp,
                FechaEstimada = estimateDate(pedido.Fecha, distTemp.Dias)
            };

            var list = new List<Producto>();
            foreach (var i in pedido.Productos)
            {
                list.Add(
                    await dbContext.Productos.Where(p => p.Id == i.Id)
                    .Include(p => p.Imagenes)
                    .Include(p => p.Subcategoria)
                    .ThenInclude(s => s.Categoria)
                    .FirstAsync()
                );
            }
            pedido.Productos = list;

            await dbContext.Pedidos.AddAsync(pedido);
            await dbContext.SaveChangesAsync();
            return pedido;
        }

        public async Task<Pedido> Delete(Pedido pedido)
        {
            dbContext.Pedidos.Remove(pedido);
            await dbContext.SaveChangesAsync();
            return pedido;
        }

        public async Task<List<Direccion>> GetDirecciones(ApplicationUser user)
        {
            return await dbContext.Direcciones.Where(d => d.Usuario.Id == user.Id).ToListAsync();
        }

        public async Task<Pedido> GetPedido(string id)
        {
            try{
                var parse = Guid.Parse(id);
                return await
                    dbContext.Pedidos.Where(p => p.Id == parse)
                        .Include(p => p.Productos)
                        .ThenInclude(pr => pr.Subcategoria)
                        .ThenInclude(s => s.Categoria)

                        .Include(p => p.Productos)
                        .ThenInclude(pr => pr.Imagenes)

                        .Include(p => p.Envio)
                        .ThenInclude(e => e.Distribuidor)

                        .Include(p => p.Usuario)

                        .FirstAsync();
            } catch (Exception e){
                Console.WriteLine($"{e.Message}");
                return null;
            }
        }

        public async Task<List<Pedido>> GetPedidos()
        {
            return await dbContext.Pedidos
                .Include(p => p.Envio)
                .ThenInclude(e => e.Distribuidor)
                .ToListAsync();
        }

        public async Task<List<Pedido>> GetPedidos(ApplicationUser user)
        {
            return await
                dbContext.Pedidos.Where(p => p.Usuario.Id == user.Id)
                .Include(p => p.Envio)
                .ThenInclude(e => e.Distribuidor)
                .Include(p => p.Productos)
                .ThenInclude(pr => pr.Imagenes)
                .Include(p => p.Productos)
                .ThenInclude(pr => pr.Subcategoria)
                .ThenInclude(s => s.Categoria)
                .ToListAsync();
        }

        public async Task<Pedido> Modify(Pedido pedido)
        {
            dbContext.Pedidos.Update(pedido);
            await dbContext.SaveChangesAsync();
            return pedido;
        }

        public Task<Distribuidor> RegisterDistribuidor(Distribuidor d)
        {
            throw new NotImplementedException();
        }

        public Task<Distribuidor> GetDistribuidor(string id)
        {
            throw new NotImplementedException();
        }
    }
}