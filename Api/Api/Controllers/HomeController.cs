using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {

            return Ok(1);
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllUser")]
        public async Task<ActionResult> GetAllUser()
        {
            /**
             * 异步方法 需要async/await配对使用
             * 可以先执行异步方法,在做其他不关联的业务操作
             * 最后使用 await 获取返回的数据, 这样相当于其他线程在执行任务
             * 等获取到了 await 的数据,在做相关联的操作
             */

            var usersTask = new UserServices().GetAllUserAsync();
            User user = null;
            {
                // 其他业务操作执行6秒
                Thread.Sleep(6000);
                user = new User() { ID = 4, Age = 21, Name = "赵六" };
            }
            var res = await usersTask;
            res.Add(user);
            return Ok(res);
        }

        /// <summary>
        /// 模拟用户登录写日志
        /// 异步无返回值
        /// </summary>
        /// <returns></returns>
        [HttpGet("UserLog")]
        public async Task<ActionResult> UserLog()
        {
            await new UserServices().UserLog();
            return Ok(1);
        }
    }
}
