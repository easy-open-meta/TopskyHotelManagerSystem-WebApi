using Furion.DynamicApiController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 预约房间控制器
    /// </summary>
    public  class ReserAppService: IDynamicApiController
    {
        /// <summary>
        /// 预约房间
        /// </summary>
        private readonly IReserService _reserService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserService"></param>
        public ReserAppService(IReserService reserService)
        {
            _reserService = reserService;
        }

        /// <summary>
        /// 获取所有预约信息
        /// </summary>
        /// <param name="selectReserAllDto"></param>
        /// <returns></returns>
        public OSelectReserAllDto SelectReserAll(SelectReserAllDto selectReserAllDto)
        {
            return this._reserService.SelectReserAll(selectReserAllDto);
        }

        /// <summary>
        /// 添加预约信息
        /// </summary>
        /// <param name="inserReserInfoDto"></param>
        /// <returns></returns>
        public OInserReserInfoDto InserReserInfo(InserReserInfoDto inserReserInfoDto)
        {
            return this._reserService.InserReserInfo(inserReserInfoDto);
        }
    }
}
