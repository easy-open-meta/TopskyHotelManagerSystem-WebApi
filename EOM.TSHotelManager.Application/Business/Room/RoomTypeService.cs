﻿/*
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
using System.Collections.Generic;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 房间类型接口实现类
    /// </summary>
    public class RoomTypeService:IRoomTypeService
    {
        /// <summary>
        /// 客房类型
        /// </summary>
        private readonly PgRepository<RoomType> roomTypeRepository;

        /// <summary>
        /// 客房信息
        /// </summary>
        private readonly PgRepository<Room> roomRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomTypeRepository"></param>
        /// <param name="roomRepository"></param>
        public RoomTypeService(PgRepository<RoomType> roomTypeRepository, PgRepository<Room> roomRepository)
        {
            this.roomTypeRepository = roomTypeRepository;
            this.roomRepository = roomRepository;
        }

        #region 获取所有房间类型
        /// <summary>
        /// 获取所有房间类型
        /// </summary>
        /// <returns></returns>
        public List<RoomType> SelectRoomTypesAll()
        {
            List<RoomType> types = new List<RoomType>();
            types = roomTypeRepository.GetList(a => a.delete_mk != 1);
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
            roomtype.RoomName = roomTypeRepository.GetSingle(a => a.Roomtype == room.RoomStateId).RoomName;
            return roomtype;
        }
        #endregion
    }
}
