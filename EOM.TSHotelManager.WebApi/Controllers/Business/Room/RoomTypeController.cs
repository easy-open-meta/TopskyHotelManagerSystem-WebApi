using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
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
        public List<RoomType> SelectRoomTypesAll([FromQuery] int? isDelete)
        {
            return roomTypeService.SelectRoomTypesAll(isDelete);
        }

        /// <summary>
        /// 根据房间编号查询房间类型名称
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        [HttpGet]
        public RoomType SelectRoomTypeByRoomNo([FromQuery] string no)
        {
            return roomTypeService.SelectRoomTypeByRoomNo(no);
        }

        /// <summary>
        /// 根据房间类型查询类型配置
        /// </summary>
        /// <param name="roomTypeId"></param>
        /// <returns></returns>
        [HttpGet]
        public RoomType SelectRoomTypeByType([FromQuery] int roomTypeId)
        {
            return roomTypeService.SelectRoomTypeByType(roomTypeId);
        }

        /// <summary>
        /// 添加房间状态
        /// </summary>
        /// <param name="roomType"></param>
        /// <returns></returns>
        [HttpPost]
        public bool InsertRoomType([FromBody] RoomType roomType)
        {
            return roomTypeService.InsertRoomType(roomType);
        }

        /// <summary>
        /// 更新房间状态
        /// </summary>
        /// <param name="roomType"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateRoomType([FromBody] RoomType roomType)
        {
            return roomTypeService.UpdateRoomType(roomType);
        }

        /// <summary>
        /// 删除房间状态
        /// </summary>
        /// <param name="roomType"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DeleteRoomType([FromBody] RoomType roomType)
        {
            return roomTypeService.DeleteRoomType(roomType);
        }
    }
}
