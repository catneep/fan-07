using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fan_07.Data;
using fan_07.Models;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;

namespace fan_07.Services
{
    public interface IPaymentService
    {
        Task<List<Pago>> GetMethods(ApplicationUser user);
        Task<Pago> Create(Pago pago);
        Task<Pago> Get(string id);
        Task<Pago> Modify(Pago pago);
        Task<Pago> Delete(Pago pago);
    }

    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext dbContext;
        public PaymentService(ApplicationDbContext db)
        {
            this.dbContext = db;
        }

        public async Task<Pago> Create(Pago pago)
        {
            await dbContext.MetodosPago.AddAsync(pago);
            await dbContext.SaveChangesAsync();
            return pago;
        }

        public async Task<Pago> Delete(Pago pago)
        {
            dbContext.MetodosPago.Remove(pago);
            await dbContext.SaveChangesAsync();
            return pago;
        }

        public async Task<Pago> Get(string id)
        {
            try
            {
                var parse = Guid.Parse(id);
                return await dbContext.MetodosPago.FirstAsync(p => p.Id == parse);
            } catch (Exception e)
            {
                return null;
            }
            
        }

        public async Task<List<Pago>> GetMethods(ApplicationUser user)
        {
            return await
                dbContext.MetodosPago.Where(p => p.Usuario.Id == user.Id).ToListAsync();
        }

        public async Task<Pago> Modify(Pago pago)
        {
            dbContext.MetodosPago.Update(pago);
            await dbContext.SaveChangesAsync();
            return pago;
        }
    }
}