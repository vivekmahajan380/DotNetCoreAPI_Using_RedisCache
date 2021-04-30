using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using DotNetCoreAPIUsingRedisCache.BusinessLogic;
using DotNetCoreAPIUsingRedisCache.DTOs;

namespace DotNetCoreAPIUsingRedisCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        private readonly IDbContext _dbContext;
        public UserController(IDistributedCache cache)
        {
            _cache = cache;
            _dbContext = new DbContext();
        }

        /// <param name="key">Choose value from 1 - 4.</param>
        [HttpGet]
        [Route("GetUser")]
        public async Task<Tuple<string,User>> GetUser(string key)
        {
            string fetchedFrom = "Data is Fetched From Cache.";
            var data = await _cache.GetStringAsync(key);
            if (data is null)
            {
                data = await _dbContext.GetUserData(key);
                fetchedFrom = "Data is Fetched From DataBase.";
                await addDataToCache(data);
            }
            return new Tuple<string, User>(fetchedFrom, JsonConvert.DeserializeObject<User>(data));
        }        

        private async Task addDataToCache(string jdata)
        {
            var data = JsonConvert.DeserializeObject<User>(jdata);
            var options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);
            await _cache.SetStringAsync(data.Id, jdata, options);
        }
    }
}
