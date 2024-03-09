using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 用户信息控制器
    /// </summary>
    public class CustoController : ControllerBase
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        private readonly ICustoService customerService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerService"></param>
        public CustoController(ICustoService customerService)
        {
            this.customerService = customerService;
        }

        /// <summary>
        /// 添加客户信息
        /// </summary>
        /// <param name="custo"></param>
        /// <returns></returns>
        [HttpPost]
        public bool InsertCustomerInfo([FromBody] Custo custo)
        {
            return customerService.InsertCustomerInfo(custo);
        }

        /// <summary>
        /// 更新客户信息
        /// </summary>
        /// <param name="custo"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdCustomerInfoByCustoNo([FromBody] Custo custo)
        {
            return customerService.UpdCustomerInfoByCustoNo(custo);
        }

        /// <summary>
        /// 更新客户类型(即会员等级)
        /// </summary>
        /// <param name="custoNo"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        [HttpGet]
        public bool UpdCustomerTypeByCustoNo([FromQuery] string custoNo, int userType)
        {
            return customerService.UpdCustomerTypeByCustoNo(custoNo, userType);
        }

        /// <summary>
        /// 查询酒店盈利情况
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CustoSpend> SelectAllMoney()
        {
            return customerService.SelectAllMoney();
        }

        /// <summary>
        /// 查询所有客户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public OSelectCustoAllDto SelectCustoAll([FromQuery] int pageIndex, int pageSize, bool onlyVip = false)
        {
            return customerService.SelectCustoAll(pageIndex, pageSize, onlyVip);
        }

        /// <summary>
        /// 查询指定客户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public List<Custo> SelectCustoByInfo([FromBody] Custo custo)
        {
            return customerService.SelectCustoByInfo(custo);
        }

        /// <summary>
        /// 根据客户编号查询客户信息
        /// </summary>
        /// <param name="CustoNo"></param>
        /// <returns></returns>
        [HttpGet]
        public Custo SelectCardInfoByCustoNo([FromQuery] string CustoNo)
        {
            return customerService.SelectCardInfoByCustoNo(CustoNo);
        }

    }
}
