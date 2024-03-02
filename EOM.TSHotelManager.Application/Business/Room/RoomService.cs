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
using CK.Common;
using EOM.TSHotelManager.Common.Core;
using EOM.TSHotelManager.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 客房信息接口实现类
    /// </summary>
    public class RoomService:IRoomService
    {
        /// <summary>
        /// 客房信息
        /// </summary>
        private readonly PgRepository<Room> roomRepository;

        /// <summary>
        /// 客房状态
        /// </summary>
        private readonly PgRepository<RoomState> roomStateRepository;

        /// <summary>
        /// 客房类型
        /// </summary>
        private readonly PgRepository<RoomType> roomTypeRepository;

        /// <summary>
        /// 客户信息
        /// </summary>
        private readonly PgRepository<Custo> custoRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomRepository"></param>
        /// <param name="roomStateRepository"></param>
        /// <param name="roomTypeRepository"></param>
        /// <param name="custoRepository"></param>
        public RoomService(PgRepository<Room> roomRepository, PgRepository<RoomState> roomStateRepository, PgRepository<RoomType> roomTypeRepository, PgRepository<Custo> custoRepository)
        {
            this.roomRepository = roomRepository;
            this.roomStateRepository = roomStateRepository;
            this.roomTypeRepository = roomTypeRepository;
            this.custoRepository = custoRepository;
        }

        #region 根据房间状态获取相应状态的房间信息
        /// <summary>
        /// 根据房间状态获取相应状态的房间信息
        /// </summary>
        /// <param name="stateid"></param>
        /// <returns></returns>
        public List<Room> SelectRoomByRoomState(int stateid)
        {
            List<RoomState> roomStates = new List<RoomState>();
            roomStates = roomStateRepository.GetList(a => a.delete_mk != 1);
            List<RoomType> roomTypes = new List<RoomType>();
            roomTypes = roomTypeRepository.GetList(a => a.delete_mk != 1);
            List<Room> rooms = new List<Room>();
            rooms = roomRepository.GetList(a => a.delete_mk != 1 && a.RoomStateId == stateid).OrderBy(a => a.RoomNo).ToList();
            rooms.ForEach(source =>
            {
                var roomState = roomStates.FirstOrDefault(a => a.RoomStateId == source.RoomStateId);
                source.RoomState = string.IsNullOrEmpty(roomState.RoomStateName) ? "" : roomState.RoomStateName;
                var roomType = roomTypes.FirstOrDefault(a => a.Roomtype == source.RoomType);
                source.RoomName = string.IsNullOrEmpty(roomType.RoomName) ? "" : roomType.RoomName;
            });
            return rooms;
        }
        #endregion

        #region 根据房间状态来查询可使用的房间
        /// <summary>
        /// 根据房间状态来查询可使用的房间
        /// </summary>
        /// <returns></returns>
        public List<Room> SelectCanUseRoomAll()
        {
            List<RoomState> roomStates = new List<RoomState>();
            roomStates = roomStateRepository.GetList(a => a.delete_mk != 1);
            List<RoomType> roomTypes = new List<RoomType>();
            roomTypes = roomTypeRepository.GetList(a => a.delete_mk != 1);
            List<Room> rooms = new List<Room>();
            rooms = roomRepository.GetList(a => a.delete_mk != 1 && a.RoomStateId == 0).OrderBy(a => a.RoomNo).ToList();
            rooms.ForEach(source =>
            {
                var roomState = roomStates.FirstOrDefault(a => a.RoomStateId == source.RoomStateId);
                source.RoomState = string.IsNullOrEmpty(roomState.RoomStateName) ? "" : roomState.RoomStateName;
                var roomType = roomTypes.FirstOrDefault(a => a.Roomtype == source.RoomType);
                source.RoomName = string.IsNullOrEmpty(roomType.RoomName) ? "" : roomType.RoomName;
            });
            return rooms;
        }
        #endregion

        #region 获取所有房间信息
        /// <summary>
        /// 获取所有房间信息
        /// </summary>
        /// <returns></returns>
        public List<Room> SelectRoomAll()
        {
            List<RoomState> roomStates = new List<RoomState>();
            roomStates = roomStateRepository.GetList(a => a.delete_mk != 1);
            List<RoomType> roomTypes = new List<RoomType>();
            roomTypes = roomTypeRepository.GetList(a => a.delete_mk != 1);
            List<Room> rooms = new List<Room>();
            rooms = roomRepository.GetList(a => a.delete_mk != 1).OrderBy(a => a.RoomNo).ToList();
            var listCustoNo = rooms.Select(a => a.CustoNo).Distinct().ToList();
            List<Custo> custos = new List<Custo>();
            custos = custoRepository.GetList(a => listCustoNo.Contains(a.CustoNo));
            rooms.ForEach(source =>
            {
                var roomState = roomStates.FirstOrDefault(a => a.RoomStateId == source.RoomStateId);
                source.RoomState = string.IsNullOrEmpty(roomState.RoomStateName) ? "" : roomState.RoomStateName;
                var roomType = roomTypes.FirstOrDefault(a => a.Roomtype == source.RoomType);
                source.RoomName = string.IsNullOrEmpty(roomType.RoomName) ? "" : roomType.RoomName;

                var custo = custos.FirstOrDefault(a => a.CustoNo.Equals(source.CustoNo));
                source.CustoName = custo.IsNullOrEmpty() ? "" : custo.CustoName;

                //把入住时间格式化
                source.CheckTimeFormat = string.IsNullOrEmpty(source.CheckTime + "") ? "" 
                : Convert.ToDateTime(source.CheckTime).ToString("yyyy-MM-dd HH:mm");

            });
            return rooms;
        }
        #endregion

        #region 获取房间分区的信息
        /// <summary>
        /// 获取房间分区的信息
        /// </summary>
        /// <returns></returns>
        public List<Room> SelectRoomByTypeName(string TypeName)
        {
            List<RoomState> roomStates = new List<RoomState>();
            roomStates = roomStateRepository.GetList(a => a.delete_mk != 1);
            List<RoomType> roomTypes = new List<RoomType>();
            roomTypes = roomTypeRepository.GetList(a => a.delete_mk != 1 && a.RoomName == TypeName);
            var listTypes = roomTypes.Select(a => a.Roomtype).Distinct().ToList();
            List<Room> rooms = new List<Room>();
            rooms = roomRepository.GetList(a => a.delete_mk != 1 && listTypes.Contains(a.RoomType)).OrderBy(a => a.RoomNo).ToList();
            var listCustoNo = rooms.Select(a => a.CustoNo).Distinct().ToList();
            List<Custo> custos = new List<Custo>();
            custos = custoRepository.GetList(a => listCustoNo.Contains(a.CustoNo));
            rooms.ForEach(source =>
            {
                var roomState = roomStates.FirstOrDefault(a => a.RoomStateId == source.RoomStateId);
                source.RoomState = string.IsNullOrEmpty(roomState.RoomStateName) ? "" : roomState.RoomStateName;
                var roomType = roomTypes.FirstOrDefault(a => a.Roomtype == source.RoomType);
                source.RoomName = string.IsNullOrEmpty(roomType.RoomName) ? "" : roomType.RoomName;

                var custo = custos.FirstOrDefault(a => a.CustoNo.Equals(source.CustoNo));
                source.CustoName = custo.IsNullOrEmpty() ? "" : custo.CustoName;

            });
            return rooms;
        }
        #endregion

        #region 根据房间编号查询房间信息
        /// <summary>
        /// 根据房间编号查询房间信息
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public Room SelectRoomByRoomNo(string no)
        {
            List<RoomState> roomStates = new List<RoomState>();
            roomStates = roomStateRepository.GetList(a => a.delete_mk != 1);
            Room room = new Room();
            room = roomRepository.GetSingle(a => a.delete_mk != 1 && a.RoomNo == no);
            var roomSate = roomStates.FirstOrDefault(a => a.RoomStateId == room.RoomStateId);
            room.RoomState = string.IsNullOrEmpty(roomSate.RoomStateName) ? "" : roomSate.RoomStateName;
            var roomType = roomTypeRepository.GetSingle(a => a.Roomtype == room.RoomType);
            room.RoomName = string.IsNullOrEmpty(roomType.RoomName) ? "" : roomType.RoomName;
            return room;
        }
        #endregion

        #region 根据房间编号退房（退房）
        /// <summary>
        /// 根据房间编号退房（退房）
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public bool UpdateRoomByRoomNo(string room)
        {
            return roomRepository.Update(a => new Room()
            {
                CustoNo = null,
                CheckTime = null,
                CheckOutTime = DateTime.Now,
                RoomStateId = 3
            },a => a.RoomNo == room);
        }
        #endregion

        #region 根据房间编号查询截止到今天住了多少天
        /// <summary>
        /// 根据房间编号查询截止到今天住了多少天
        /// </summary>
        /// <param name="roomno"></param>
        /// <returns></returns>
        public object DayByRoomNo(string roomno)
        {
            return Math.Abs(((TimeSpan)(roomRepository.GetSingle(a => a.RoomNo == roomno).CheckTime - DateTime.Now)).Days);
        }
        #endregion

        #region 根据房间编号修改房间信息（入住）
        /// <summary>
        /// 根据房间编号修改房间信息（入住）
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool UpdateRoomInfo(Room r)
        {
            return roomRepository.Update(a => new Room()
            {
                CheckTime = r.CheckTime,
                RoomStateId = r.RoomStateId,
                CustoNo = r.CustoNo
            },a => a.RoomNo == r.RoomNo);
        }
        #endregion

        #region 根据房间编号修改房间信息（预约）
        /// <summary>
        /// 根据房间编号修改房间信息（预约）
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool UpdateRoomInfoWithReser(Room r)
        {
            return roomRepository.Update(a => new Room()
            {
                RoomStateId = r.RoomStateId,
                datachg_usr = r.datachg_usr
            }, a => a.RoomNo == r.RoomNo);
        }
        #endregion

        #region 查询可入住房间数量
        /// <summary>
        /// 查询可入住房间数量
        /// </summary>
        /// <returns></returns>
        public object SelectCanUseRoomAllByRoomState()
        {
            return roomRepository.GetList(a => a.RoomStateId == 0 && a.delete_mk != 1).OrderBy(a => a.RoomNo).Count();
        }
        #endregion

        #region 查询已入住房间数量
        /// <summary>
        /// 查询已入住房间数量
        /// </summary>
        /// <returns></returns>
        public object SelectNotUseRoomAllByRoomState()
        {
            return roomRepository.GetList(a => a.RoomStateId == 1 && a.delete_mk != 1).OrderBy(a => a.RoomNo).Count();
        }
        #endregion

        #region 根据房间编号查询房间价格
        /// <summary>
        /// 根据房间编号查询房间价格
        /// </summary>
        /// <returns></returns>
        public object SelectRoomByRoomPrice(string r)
        {
            return roomRepository.GetSingle(a => a.RoomNo == r).RoomMoney;
        }
        #endregion

        #region 查询脏房数量
        /// <summary>
        /// 查询脏房数量
        /// </summary>
        /// <returns></returns>
        public object SelectNotClearRoomAllByRoomState()
        {
            return roomRepository.GetList(a => a.RoomStateId == 3 && a.delete_mk != 1).OrderBy(a => a.RoomNo).Count();
        }
        #endregion

        #region 查询维修房数量
        /// <summary>
        /// 查询维修房数量
        /// </summary>
        /// <returns></returns>
        public object SelectFixingRoomAllByRoomState()
        {
            return roomRepository.GetList(a => a.RoomStateId == 2 && a.delete_mk != 1).OrderBy(a => a.RoomNo).Count();
        }
        #endregion

        #region 查询预约房数量
        /// <summary>
        /// 查询预约房数量
        /// </summary>
        /// <returns></returns>
        public object SelectReseredRoomAllByRoomState()
        {
            return roomRepository.GetList(a => a.RoomStateId == 4 && a.delete_mk != 1).OrderBy(a => a.RoomNo).Count();
        }
        #endregion

        #region 根据房间编号更改房间状态
        /// <summary>
        /// 根据房间编号更改房间状态
        /// </summary>
        /// <param name="roomno"></param>
        /// <param name="stateid"></param>
        /// <returns></returns>
        public bool UpdateRoomStateByRoomNo(string roomno, int stateid)
        {
            return roomRepository.Update(a => new Room()
            {
                RoomStateId = stateid
            },a => a.RoomNo == roomno);
        }
        #endregion

        #region 添加房间
        /// <summary>
        /// 添加房间
        /// </summary>
        /// <param name="rn"></param>
        /// <returns></returns>
        public bool InsertRoom(Room rn)
        {
            try
            {
                return roomRepository.Insert(rn);
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 查询所有可消费（已住）房间
        /// <summary>
        /// 查询所有可消费（已住）房间
        /// </summary>
        /// <returns></returns>
        public List<Room> SelectRoomByStateAll()
        {
            List<RoomState> roomStates = new List<RoomState>();
            roomStates = roomStateRepository.GetList(a => a.delete_mk != 1);
            List<RoomType> roomTypes = new List<RoomType>();
            roomTypes = roomTypeRepository.GetList(a => a.delete_mk != 1);
            List<Room> rooms = new List<Room>();
            rooms = roomRepository.GetList(a => a.delete_mk != 1 && a.RoomStateId == 1).OrderBy(a => a.RoomNo).ToList();
            rooms.ForEach(source =>
            {
                var roomState = roomStates.FirstOrDefault(a => a.RoomStateId == source.RoomStateId);
                source.RoomState = string.IsNullOrEmpty(roomState.RoomStateName) ? "" : roomState.RoomStateName;
                var roomType = roomTypes.FirstOrDefault(a => a.Roomtype == source.RoomType);
                source.RoomName = string.IsNullOrEmpty(roomType.RoomName) ? "" : roomType.RoomName;
            });
            return rooms;
        }
        #endregion

        #region 获取所有房间状态
        /// <summary>
        /// 获取所有房间状态
        /// </summary>
        /// <returns></returns>
        public List<RoomState> SelectRoomStateAll()
        {
            List<RoomState> rs = new List<RoomState>();
            rs = roomStateRepository.GetList(a => a.delete_mk != 1);
            return rs;
        }
        #endregion

        #region 根据房间编号查询房间状态编号
        /// <summary>
        /// 根据房间编号查询房间状态编号
        /// </summary>
        /// <param name="roomno"></param>
        /// <returns></returns>
        public object SelectRoomStateIdByRoomNo(string roomno)
        {
            return roomRepository.GetSingle(a => a.RoomNo == roomno).RoomStateId;
        }
        #endregion
    }
}
