using Login.Core;
using Login.Core.IRepositories;
using Login.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User> , IUserRepository
    {

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<User>> GetUserByCredentials(string userName, string password)
        {
            try
            {
                var _user = await GetAllAsync(_ => _.UserName == userName && _.Password == password);
                if (_user.Any())
                {
                    return _user.ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return new List<User>();
        }
    }
}
