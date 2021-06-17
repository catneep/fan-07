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
        Task<Pedido> GetPedido(string id);
        Task<List<Pedido>> GetPedidos();
        Task<List<Pedido>> GetPedidos(ApplicationUser user);
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
        public async Task<Pedido> Create(Pedido pedido)
        {
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

        public async Task<Pedido> GetPedido(string id)
        {
            try{
                var parse = Guid.Parse(id);
                return await
                    dbContext.Pedidos.Where(p => p.Id == parse)
                        .Include(p => p.Envio)
                        .ThenInclude(e => e.Distribuidor)
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
                .ToListAsync();
        }

        public async Task<Pedido> Modify(Pedido pedido)
        {
            dbContext.Pedidos.Update(pedido);
            await dbContext.SaveChangesAsync();
            return pedido;
        }
    }
}