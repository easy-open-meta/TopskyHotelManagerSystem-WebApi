using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 预约信息控制器
    /// </summary>
    public class ReserController : ControllerBase
    {
        /// <summary>
        /// 预约信息
        /// </summary>
        private readonly IReserService reserService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserService"></param>
        public ReserController(IReserService reserService)
        {
            this.reserService = reserService;
        }

        /// <summary>
        /// 获取所有预约信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Reser> SelectReserAll()
        {
            return reserService.SelectReserAll();
        }

        /// <summary>
        /// 根据房间编号获取预约信息
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        [HttpGet]
        public Reser SelectReserInfoByRoomNo([FromQuery] string no)
        {
            return reserService.SelectReserInfoByRoomNo(no);
        }

        /// <summary>
        /// 删除预约信息
        /// </summary>
        /// <param name="reser"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DeleteReserInfo([FromBody] Reser reser)
        {
            return reserService.DeleteReserInfo(reser);
        }

        /// <summary>
        /// 添加预约信息
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPost]
        public bool InserReserInfo([FromBody] Reser r)
        {
            return reserService.InserReserInfo(r);
        }
    }
}
