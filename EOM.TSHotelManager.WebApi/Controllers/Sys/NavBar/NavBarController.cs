using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 导航控件模块控制器
    /// </summary>
    public class NavBarController : ControllerBase
    {
        /// <summary>
        /// 导航控件
        /// </summary>
        private readonly INavBarService navBarService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="navBarService"></param>
        public NavBarController(INavBarService navBarService)
        {
            this.navBarService = navBarService;
        }

        /// <summary>
        /// 导航控件列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<NavBar> NavBarList()
        {
            return navBarService.NavBarList();
        }

    }
}
