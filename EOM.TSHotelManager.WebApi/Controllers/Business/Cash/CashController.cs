using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 资产信息控制器
    /// </summary>
    public class CashController : ControllerBase
    {
        /// <summary>
        /// 资产信息
        /// </summary>
        private readonly ICashService cashService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cashService"></param>
        public CashController(ICashService cashService)
        {
            this.cashService = cashService;
        }

        /// <summary>
        /// 添加资产信息
        /// </summary>
        /// <param name="cash"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddCashInfo([FromBody]Cash cash)
        {
            return cashService.AddCashInfo(cash);
        }

        /// <summary>
        /// 查询资产信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Cash> SelectCashInfoAll()
        {
            return cashService.SelectCashInfoAll();
        }

    }
}
