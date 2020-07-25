using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class UserServices
    {
        public async Task<List<User>> GetAllUserAsync()
        {
            // 模拟去数据库查询
            var res = await User.GetAllAsync();
            return res;
        }

        public async Task UserLog()
        {
            // 模拟去数据库查询
            await User.UserLogin();
        }
    }
}
