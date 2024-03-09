using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 监管统计控制器
    /// </summary>
    public class CheckInfoController : ControllerBase
    {
        /// <summary>
        /// 监管统计
        /// </summary>
        private readonly ICheckInfoService checkInfoService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="checkInfoService"></param>
        public CheckInfoController(ICheckInfoService checkInfoService)
        {
            this.checkInfoService = checkInfoService;
        }

        /// <summary>
        /// 查询所有监管统计信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CheckInfo> SelectCheckInfoAll()
        {
            return checkInfoService.SelectCheckInfoAll();
        }
    }
}
