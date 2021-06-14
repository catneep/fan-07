using fan_07.Data;
using fan_07.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace fan_07.Services
{
    public interface ICredentialService
    {

    }

    public class CredentialService : ICredentialService
    {
        private readonly ApplicationDbContext dbContext;
        public CredentialService(ApplicationDbContext _dbContext){
            dbContext = _dbContext;
        }
    }
}