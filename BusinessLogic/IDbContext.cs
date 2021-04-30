using System.Threading.Tasks;
using DotNetCoreAPIUsingRedisCache.DTOs;

namespace DotNetCoreAPIUsingRedisCache.BusinessLogic
{
    public interface IDbContext
    {
        Task<string> GetUserData(string key);
    }
}