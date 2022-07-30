using Furion.DynamicApiController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 资产信息控制器
    /// </summary>
    public class CashAppService: IDynamicApiController
    {
        /// <summary>
        /// 资产信息
        /// </summary>
        private readonly ICashService cashService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cashService"></param>
        public CashAppService(ICashService cashService)
        {
            this.cashService = cashService;
        }

        /// <summary>
        /// 添加资产信息
        /// </summary>
        /// <param name="addCashInfoDto"></param>
        /// <returns></returns>
        public OAddCashInfoDto AddCashInfo(AddCashInfoDto addCashInfoDto)
        {
            return cashService.AddCashInfo(addCashInfoDto);
        }

        /// <summary>
        /// 查询资产信息
        /// </summary>
        /// <returns></returns>
        public OCashInfoListDto SelectCashInfoAll(CashInfoListDto cashInfoListDto)
        {
            return cashService.SelectCashInfoAll(cashInfoListDto);
        }

    }
}
