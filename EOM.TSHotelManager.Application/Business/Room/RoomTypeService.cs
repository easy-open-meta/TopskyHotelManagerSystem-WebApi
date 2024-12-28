/*
 * MIT License
 *Copyright (c) 2021 易开元(Easy-Open-Meta)

 *Permission is hereby granted, free of charge, to any person obtaining a copy
 *of this software and associated documentation files (the "Software"), to deal
 *in the Software without restriction, including without limitation the rights
 *to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *copies of the Software, and to permit persons to whom the Software is
 *furnished to do so, subject to the following conditions:

 *The above copyright notice and this permission notice shall be included in all
 *copies or substantial portions of the Software.

 *THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *SOFTWARE.
 *
 */
using EOM.TSHotelManager.Common.Core;
using EOM.TSHotelManager.EntityFramework;
using jvncorelib.EntityLib;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 房间类型接口实现类
    /// </summary>
    public class RoomTypeService : IRoomTypeService
    {
        /// <summary>
        /// 客房类型
        /// </summary>
        private readonly GenericRepository<RoomType> roomTypeRepository;

        /// <summary>
        /// 客房信息
        /// </summary>
        private readonly GenericRepository<Room> roomRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomTypeRepository"></param>
        /// <param name="roomRepository"></param>
        public RoomTypeService(GenericRepository<RoomType> roomTypeRepository, GenericRepository<Room> roomRepository)
        {
            this.roomTypeRepository = roomTypeRepository;
            this.roomRepository = roomRepository;
        }

        #region 获取所有房间类型
        /// <summary>
        /// 获取所有房间类型
        /// </summary>
        /// <returns></returns>
        public List<RoomType> SelectRoomTypesAll(int? isDelete)
        {
            List<RoomType> types = new List<RoomType>();
            if (!isDelete.IsNullOrEmpty())
            {
                types = roomTypeRepository.GetList(a => a.delete_mk == isDelete);

            }
            types = roomTypeRepository.GetList();
            types.ForEach(t =>
            {
                t.DeleteMkNm = t.delete_mk == 0 ? "否" : "是";
            });
            return types;
        }
        #endregion

        #region 根据房间编号查询房间类型名称
        /// <summary>
        /// 根据房间编号查询房间类型名称
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public RoomType SelectRoomTypeByRoomNo(string no)
        {
            RoomType roomtype = new RoomType();
            Room room = new Room();
            room = roomRepository.GetSingle(a => a.RoomNo == no && a.delete_mk != 1);
            roomtype.RoomName = roomTypeRepository.GetSingle(a => a.Roomtype == room.RoomType).RoomName;
            return roomtype;
        }
        #endregion

        /// <summary>
        /// 根据房间类型查询类型配置
        /// </summary>
        /// <param name="roomTypeId"></param>
        /// <returns></returns>
        public RoomType SelectRoomTypeByType(int roomTypeId)
        {
            var roomType = roomTypeRepository.GetSingle(a => a.Roomtype == roomTypeId);
            return roomType;
        }

        /// <summary>
        /// 添加房间状态
        /// </summary>
        /// <param name="roomType"></param>
        /// <returns></returns>
        public bool InsertRoomType(RoomType roomType)
        {
            return roomTypeRepository.Insert(roomType);
        }

        /// <summary>
        /// 更新房间状态
        /// </summary>
        /// <param name="roomType"></param>
        /// <returns></returns>
        public bool UpdateRoomType(RoomType roomType)
        {
            return roomTypeRepository.Update(a => new RoomType
            {
                RoomName = roomType.RoomName,
                RoomRent = roomType.RoomRent,
                RoomDeposit = roomType.RoomDeposit,
                delete_mk = roomType.delete_mk,
                datachg_usr = roomType.datachg_usr
            }, a => a.Roomtype == roomType.Roomtype);
        }

        /// <summary>
        /// 删除房间状态
        /// </summary>
        /// <param name="roomType"></param>
        /// <returns></returns>
        public bool DeleteRoomType(RoomType roomType)
        {
            return roomTypeRepository.Update(a => new RoomType
            {
                delete_mk = 1
            }, a => a.Roomtype == roomType.Roomtype);
        }
    }
}
