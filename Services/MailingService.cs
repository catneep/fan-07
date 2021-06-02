using System;
using System.Threading.Tasks;
using fan_07.Models;

namespace fan_07.Services
{
    public interface IMailingService
    {
        //TODO
        Task<int> GetStatus(Pedido pedido);
        Task<Distribuidor> AssignDistributor();
        
    }
}