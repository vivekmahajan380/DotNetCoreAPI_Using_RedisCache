using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreAPIUsingRedisCache.DTOs;
using Newtonsoft.Json;

namespace DotNetCoreAPIUsingRedisCache.BusinessLogic
{
    public class DbContext : IDbContext
    {
        private IList<User> users;

        public DbContext()
        {
            users = new List<User>();
            users.Add(new User() { Id = "1", FirstName = "User1_FName", LastName = "User1_LName", Email = "1234@gmail.com" });
            users.Add(new User() { Id = "2", FirstName = "User2_FName", LastName = "User2_LName", Email = "2345@gmail.com" });
            users.Add(new User() { Id = "3", FirstName = "User3_FName", LastName = "User3_LName", Email = "3456@gmail.com" });
            users.Add(new User() { Id = "4", FirstName = "User4_FName", LastName = "User4_LName", Email = "4567@gmail.com" });
        }
        
        public async Task<string> GetUserData(string key)
        {
            await Task.Delay(5000);
            User data = users.Where(x => x.Id == key).FirstOrDefault();
            return JsonConvert.SerializeObject(data);
        }
    }
}
