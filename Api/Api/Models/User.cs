using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Models
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public static async Task<List<User>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                // 模拟查询需要5秒钟
                Thread.Sleep(5000);
                var all = new List<User>()
                {
                    new User (){ ID = 1 , Age = 18, Name="张三" } ,
                    new User (){ ID = 2 , Age = 19, Name="李四" } ,
                    new User (){ ID = 3 , Age = 20, Name="王五" } ,
                };
                return all;
            });
        }

        /// <summary>
        /// 用户登录写日志
        /// </summary>
        /// <returns></returns>
        public static async Task UserLogin()
        {
            await Task.Run(() =>
            {
                // 模拟用户登录需要3秒钟
                Thread.Sleep(3000);
                return Task.CompletedTask;
            });
        }
    }
}
