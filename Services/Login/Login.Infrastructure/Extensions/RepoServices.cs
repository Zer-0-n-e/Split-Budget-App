using Login.Core;
using Login.Core.IRepositories;
using Login.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Infrastructure.Extensions
{
    public static class RepoServices
    {
        public static IServiceCollection AddRepoServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            return serviceCollection;
        }
    }
}
