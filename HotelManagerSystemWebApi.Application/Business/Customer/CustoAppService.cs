using Furion.DynamicApiController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 客户信息控制器
    /// </summary>
    public class CustoAppService: IDynamicApiController
    {
        /// <summary>
        /// 客户信息
        /// </summary>
        private readonly ICustoService _custoService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custoService"></param>
        public CustoAppService(ICustoService custoService)
        {
            _custoService = custoService;
        }

        /// <summary>
        /// 添加客户信息
        /// </summary>
        /// <param name="insertCustomerInfoDto"></param>
        /// <returns></returns>
        public OInsertCustomerInfoDto InsertCustomerInfo(InsertCustomerInfoDto insertCustomerInfoDto)
        {
            return _custoService.InsertCustomerInfo(insertCustomerInfoDto);
        }

        /// <summary>
        /// 更新客户信息
        /// </summary>
        /// <param name="updCustomerInfoDto"></param>
        /// <returns></returns>
        public OUpdCustomerInfoDto UpdCustomerInfoNo(UpdCustomerInfoDto updCustomerInfoDto)
        {
            return _custoService.UpdCustomerInfoNo(updCustomerInfoDto);
        }

        /// <summary>
        /// 更新客户类型(即会员等级)
        /// </summary>
        /// <param name="custoNo"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        //public OUpdCustomerTypeByCustoNoDto UpdCustomerTypeByCustoNo(string custoNo, int userType)
        //{
        //    return _custoService.UpdCustomerTypeByCustoNo(custoNo, userType);
        //}

        /// <summary>
        /// 查询酒店盈利情况
        /// </summary>
        /// <returns></returns>
        public OSelectAllMoneyDto SelectAllMoney()
        {
            return _custoService.SelectAllMoney();
        }

        /// <summary>
        /// 查询所有客户信息
        /// </summary>
        /// <returns></returns>
        public OSelectCustoAllDto SelectCustoAll(SelectCustoAllDto selectCustoAllDto)
        {
            return _custoService.SelectCustoAll(selectCustoAllDto);
        }
    }
}
