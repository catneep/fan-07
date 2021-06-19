using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fan_07.Data;
using fan_07.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace fan_07.Services
{
    public interface IAdminService
    {
        //CRUD Distribuidores
        Task<List<Distribuidor>> GetDistribuidores();
        Task<Distribuidor> CreateDistribuidor(Distribuidor d);
        Task<Distribuidor> EditDistribuidor(Distribuidor d);
        Task<Distribuidor> DeleteDistribuidor(Distribuidor d);
        Task<Distribuidor> GetDistribuidor(string id);

        //CRUD Usuarios
        Task<List<ApplicationUser>> GetUsers();
        Task<ApplicationUser> CreateUser(ApplicationUser user);
        Task<ApplicationUser> EditUser(ApplicationUser user);
        Task<ApplicationUser> DeleteUser(ApplicationUser user);
        Task<ApplicationUser> GetUser(string id);
        Task<IdentityRole> GetRoles(ApplicationUser user);
    }

    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext dbContext;
        public AdminService(ApplicationDbContext db)
        {
            dbContext = db;
        }

        public async Task<Distribuidor> CreateDistribuidor(Distribuidor d)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ApplicationUser> CreateUser(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Distribuidor> DeleteDistribuidor(Distribuidor d)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ApplicationUser> DeleteUser(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Distribuidor> EditDistribuidor(Distribuidor d)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ApplicationUser> EditUser(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Distribuidor> GetDistribuidor(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Distribuidor>> GetDistribuidores()
        {
            return await dbContext.Distribuidores.ToListAsync();
        }

        public async Task<IdentityRole> GetRoles(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ApplicationUser> GetUser(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ApplicationUser>> GetUsers()
        {
            var l = await dbContext.Users.ToListAsync();
            List<ApplicationUser> result = new();
            foreach (var u in l)
            {
                l.Add(new ApplicationUser{Id = u.Id});
            }
            return result;
        }
    }
}