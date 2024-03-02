using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 房间类型控制器
    /// </summary>
    public class RoomTypeController : ControllerBase
    {
        /// <summary>
        /// 房间类型
        /// </summary>
        private readonly IRoomTypeService roomTypeService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomTypeService"></param>
        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            this.roomTypeService = roomTypeService;
        }

        /// <summary>
        /// 获取所有房间类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<RoomType> SelectRoomTypesAll()
        {
            return roomTypeService.SelectRoomTypesAll();
        }

        /// <summary>
        /// 根据房间编号查询房间类型名称
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        [HttpGet]
        public RoomType SelectRoomTypeByRoomNo([FromQuery]string no)
        {
            return roomTypeService.SelectRoomTypeByRoomNo(no);
        }

    }
}
