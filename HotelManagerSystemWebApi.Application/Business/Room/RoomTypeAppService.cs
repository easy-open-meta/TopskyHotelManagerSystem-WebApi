namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 房间类型控制器
    /// </summary>
    public class RoomTypeAppService:IDynamicApiController
    {
        /// <summary>
        /// 房间类型
        /// </summary>
        private readonly IRoomTypeService _roomTypeService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomTypeService"></param>
        public RoomTypeAppService(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        #region 获取所有房间类型
        /// <summary>
        /// 获取所有房间类型
        /// </summary>
        /// <returns></returns>
        public OSelectRoomTypesAllDto SelectRoomTypesAll(SelectRoomTypesAllDto selectRoomTypesAllDto)
        {
            return _roomTypeService.SelectRoomTypesAll(selectRoomTypesAllDto);
        }
        #endregion

    }
}
