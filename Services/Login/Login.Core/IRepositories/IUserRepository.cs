using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.Core.Entities;

namespace Login.Core.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> GetUserByCredentials(string userName, string password);
    }
}
