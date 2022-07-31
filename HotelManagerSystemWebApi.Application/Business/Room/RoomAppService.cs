namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 房间信息控制器
    /// </summary>
    public class RoomAppService:IDynamicApiController
    {
        /// <summary>
        /// 房间信息
        /// </summary>
        private readonly IRoomService roomService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomService"></param>
        public RoomAppService(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        /// <summary>
        /// 获取所有房间信息
        /// </summary>
        /// <param name="roomListDto"></param>
        /// <returns></returns>
        public OSelectRoomListDto SelectRoomList(SelectRoomListDto roomListDto)
        {
            return roomService.SelectRoomList(roomListDto);
        }

        /// <summary>
        /// 单条房间信息
        /// </summary>
        /// <param name="roomDto"></param>
        /// <returns></returns>
        public OSelectRoomDto SelectRoom(SelectRoomDto roomDto)
        {
            return roomService.SelectRoom(roomDto);
        }

        /// <summary>
        /// 根据房间编号退房（退房）
        /// </summary>
        /// <param name="updCheckoutRoomDto"></param>
        /// <returns></returns>
        public OUpdCheckoutRoomDto UpdCheckoutRoom(UpdCheckoutRoomDto updCheckoutRoomDto)
        {
            return roomService.UpdCheckoutRoom(updCheckoutRoomDto);
        }

        /// <summary>
        /// 根据房间编号退房（入住）
        /// </summary>
        /// <param name="updCheckInRoomDto"></param>
        /// <returns></returns>
        public OUpdCheckInRoomDto UpdCheckInRoom(UpdCheckInRoomDto updCheckInRoomDto)
        {
            return roomService.UpdCheckInRoom(updCheckInRoomDto);
        }

        /// <summary>
        /// 根据房间编号退房（预约）
        /// </summary>
        /// <param name="reserRoomDto"></param>
        /// <returns></returns>
        public OUpdReserRoomDto UpdReserRoom(UpdReserRoomDto reserRoomDto)
        {
            return roomService.UpdReserRoom(reserRoomDto);
        }

        /// <summary>
        /// 根据房间编号查询截止到今天住了多少天
        /// </summary>
        /// <param name="dayByRoomNoDto"></param>
        /// <returns></returns>
        public ODayByRoomNoDto DayByRoomNo(DayByRoomNoDto dayByRoomNoDto)
        {
            return roomService.DayByRoomNo(dayByRoomNoDto);
        }

        /// <summary>
        /// 添加房间
        /// </summary>
        /// <param name="insertRoomDto"></param>
        /// <returns></returns>
        public OInsertRoomDto InsertRoom(InsertRoomDto insertRoomDto)
        {
            return roomService.InsertRoom(insertRoomDto);
        }
    }
}
