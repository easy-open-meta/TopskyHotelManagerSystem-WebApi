using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 房间信息控制器
    /// </summary>
    public class RoomController : ControllerBase
    {
        /// <summary>
        /// 房间信息
        /// </summary>
        private readonly IRoomService roomService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomService"></param>
        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        /// <summary>
        /// 根据房间状态获取相应状态的房间信息
        /// </summary>
        /// <param name="stateid"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Room> SelectRoomByRoomState([FromQuery]int stateid)
        {
            return roomService.SelectRoomByRoomState(stateid);
        }

        /// <summary>
        /// 根据房间状态来查询可使用的房间
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Room> SelectCanUseRoomAll()
        {
            return roomService.SelectCanUseRoomAll();
        }

        /// <summary>
        /// 获取所有房间信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Room> SelectRoomAll()
        {
            return roomService.SelectRoomAll();
        }

        /// <summary>
        /// 获取房间分区的信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Room> SelectRoomByTypeName([FromQuery] string TypeName)
        {
            return roomService.SelectRoomByTypeName(TypeName);
        }

        /// <summary>
        /// 根据房间编号查询房间信息
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        [HttpGet]
        public Room SelectRoomByRoomNo([FromQuery] string no)
        {
            return roomService.SelectRoomByRoomNo(no);
        }

        /// <summary>
        /// 根据房间编号退房（退房）
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        [HttpGet]
        public bool UpdateRoomByRoomNo([FromQuery] string room)
        {
            return roomService.UpdateRoomByRoomNo(room);
        }

        /// <summary>
        /// 根据房间编号查询截止到今天住了多少天
        /// </summary>
        /// <param name="roomno"></param>
        /// <returns></returns>
        [HttpGet]
        public object DayByRoomNo([FromQuery] string roomno)
        {
            return roomService.DayByRoomNo(roomno);
        }

        /// <summary>
        /// 根据房间编号修改房间信息（入住）
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateRoomInfo([FromBody]Room r)
        {
            return roomService.UpdateRoomInfo(r);
        }

        /// <summary>
        /// 根据房间编号修改房间信息（预约）
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateRoomInfoWithReser([FromBody] Room r)
        {
            return roomService.UpdateRoomInfoWithReser(r);
        }

        /// <summary>
        /// 查询可入住房间数量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object SelectCanUseRoomAllByRoomState()
        {
            return roomService.SelectCanUseRoomAllByRoomState();
        }

        /// <summary>
        /// 查询已入住房间数量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object SelectNotUseRoomAllByRoomState()
        {
            return roomService.SelectNotUseRoomAllByRoomState();
        }

        /// <summary>
        /// 根据房间编号查询房间价格
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object SelectRoomByRoomPrice([FromQuery]string r)
        {
            return roomService.SelectRoomByRoomPrice(r);
        }

        /// <summary>
        /// 查询脏房数量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object SelectNotClearRoomAllByRoomState()
        {
            return roomService.SelectNotClearRoomAllByRoomState();
        }

        /// <summary>
        /// 查询维修房数量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object SelectFixingRoomAllByRoomState()
        {
            return roomService.SelectFixingRoomAllByRoomState();
        }

        /// <summary>
        /// 查询预约房数量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object SelectReseredRoomAllByRoomState()
        {
            return roomService.SelectReseredRoomAllByRoomState();
        }

        /// <summary>
        /// 根据房间编号更改房间状态
        /// </summary>
        /// <param name="roomno"></param>
        /// <param name="stateid"></param>
        /// <returns></returns>
        [HttpGet]
        public bool UpdateRoomStateByRoomNo([FromQuery]string roomno, int stateid)
        {
            return roomService.UpdateRoomStateByRoomNo(roomno,stateid);
        }

        /// <summary>
        /// 添加房间
        /// </summary>
        /// <param name="rn"></param>
        /// <returns></returns>
        [HttpPost]
        public bool InsertRoom([FromBody]Room rn)
        {
            return roomService.InsertRoom(rn);
        }

        /// <summary>
        /// 查询所有可消费（已住）房间
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Room> SelectRoomByStateAll()
        {
            return roomService.SelectRoomByStateAll();
        }

        /// <summary>
        /// 获取所有房间状态
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<RoomState> SelectRoomStateAll()
        {
            return roomService.SelectRoomStateAll();
        }

        /// <summary>
        /// 根据房间编号查询房间状态编号
        /// </summary>
        /// <param name="roomno"></param>
        /// <returns></returns>
        [HttpGet]
        public object SelectRoomStateIdByRoomNo([FromQuery]string roomno)
        {
            return roomService.SelectRoomStateIdByRoomNo(roomno);
        }

    }
}
