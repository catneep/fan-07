using fan_07.Data;

namespace fan_07.Services
{
    public interface IPaymentService
    {
        
    }

    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext dbContext;
    }
}