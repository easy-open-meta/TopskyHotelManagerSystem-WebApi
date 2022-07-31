/*
 * MIT License
 *Copyright (c) 2021 咖啡与网络(java-and-net)

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
using System;
using System.Collections.Generic;
using System.Linq;
using Furion.DependencyInjection;
using HotelManagerSystemWebApi.Application;
using HotelManagerSystemWebApi.Core;



namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 客房信息接口实现类
    /// </summary>
    public class RoomService:IRoomService, ITransient
    {
        /// <summary>
        /// 房间信息
        /// </summary>
        private readonly IRepository<Room> _roomRepository;

        /// <summary>
        /// 房间类型
        /// </summary>
        private readonly IRepository<RoomType> _roomTypeRepository;

        /// <summary>
        /// 房间状态
        /// </summary>
        private readonly IRepository<RoomState> _roomStateRepository;

        /// <summary>
        /// 房间信息
        /// </summary>
        private readonly IRepository<Custo> _custoRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomRepository"></param>
        public RoomService(IRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }
        
        /// <summary>
        /// 获取所有房间信息
        /// </summary>
        /// <param name="roomListDto"></param>
        /// <returns></returns>
        public OSelectRoomListDto SelectRoomList(SelectRoomListDto roomListDto)
        {
            OSelectRoomListDto oRoomListDto = new OSelectRoomListDto();

            var where = LinqExpression.Create<Room>(a => a.delete_mk != 1);

            //房间号码
            if (!roomListDto.RoomNo.IsNullOrEmpty())
            {
                where = where.And(a => a.RoomNo.Contains(roomListDto.RoomNo));
            }
            //客户编号
            if (!roomListDto.CustoNo.IsNullOrEmpty())
            {
                where = where.And(a => a.CustoNo.Contains(roomListDto.CustoNo));
            }
            //房间状态
            if (!roomListDto.RoomStateId.IsNullOrEmpty())
            {
                where = where.And(a => a.RoomStateId == roomListDto.RoomStateId);
            }
            //房间类型
            if (!roomListDto.RoomType.IsNullOrEmpty())
            {
                where = where.And(a => a.RoomType == roomListDto.RoomType);
            }
            //删除标记
            if (!roomListDto.delete_mk.IsNullOrEmpty())
            {
                where = where.And(a => a.delete_mk == roomListDto.delete_mk);
            }

            //查询出所有房间类型
            var listSource = _roomRepository.AsQueryable(where).ToList()
                .CopyToModel<Room, Temp_Room>();

            //客户编号
            var listCustoNo = listSource.Select(a => a.CustoNo).Distinct().ToList();
            var listCusto = this._custoRepository.AsQueryable(a => listCustoNo.Contains(a.CustoNo)).ToList();

            //房间状态
            var listRoomStateId = listSource.Select(a => a.RoomStateId).Distinct().ToList();
            var listRoomState = this._roomStateRepository.AsQueryable().ToList();

            //房间类型
            var listRoomTypeId = listSource.Select(a => a.RoomType).Distinct().ToList();
            var listRoomType = this._roomTypeRepository.AsQueryable().ToList();

            listSource.ForEach(source =>
            {
                //客户
                var customer = listCusto.Find(a => a.CustoNo.Equals(source.CustoNo));
                source.CustoNm = customer.IsNullOrEmpty() ? "" : customer.CustoName;

                //房间状态
                var roomState = listRoomState.Find(a => a.RoomStateId == source.RoomStateId);
                source.RoomStateNm = roomState.IsNullOrEmpty() ? "" : roomState.RoomStateName;

                //房间类型
                var roomType = listRoomType.Find(a => a.Roomtype == source.RoomType);
                source.RoomTypeNm = roomType.IsNullOrEmpty() ? "" : roomType.RoomName;

            });

            oRoomListDto.listSource = listSource;
            oRoomListDto.total = listSource.Count;
            oRoomListDto.OK();

            return oRoomListDto;
        }

        /// <summary>
        /// 单条房间信息
        /// </summary>
        /// <param name="selectRoomDto"></param>
        /// <returns></returns>
        public OSelectRoomDto SelectRoom(SelectRoomDto selectRoomDto)
        {
            OSelectRoomDto oSelectRoomDto = new OSelectRoomDto();

            //查询房间信息
            var source = this._roomRepository.Single(a => a.RoomNo.Equals(selectRoomDto.RoomNo))
                .CopyToModel<Room,Temp_Room>();

            if (source.IsNullOrEmpty())
            {
                oSelectRoomDto.Error_NotFound();
                return oSelectRoomDto;
            }

            //客户
            var customer = this._custoRepository.Single(a => a.CustoNo.Equals(source.CustoNo));
            source.CustoNm = customer.IsNullOrEmpty() ? "" : customer.CustoName;

            //房间状态
            var roomState = this._roomStateRepository.Single(a => a.RoomStateId == source.RoomStateId);
            source.RoomStateNm = roomState.IsNullOrEmpty() ? "" : roomState.RoomStateName;

            //房间类型
            var roomType = this._roomTypeRepository.Single(a => a.Roomtype == source.RoomType);
            source.RoomTypeNm = roomType.IsNullOrEmpty() ? "" : roomType.RoomName;

            oSelectRoomDto.source = source;
            oSelectRoomDto.OK();

            return oSelectRoomDto;

        }

        /// <summary>
        /// 根据房间编号退房（退房）
        /// </summary>
        /// <param name="checkoutRoomDto"></param>
        /// <returns></returns>
        public OUpdCheckoutRoomDto UpdCheckoutRoom(UpdCheckoutRoomDto checkoutRoomDto)
        {
            OUpdCheckoutRoomDto oUpdateRoomByRoomNoDto = new OUpdCheckoutRoomDto();

            //查询房间信息
            var source = this._roomRepository.Single(a => a.RoomNo.Equals(checkoutRoomDto.RoomNo));

            if (source.IsNullOrEmpty())
            {
                oUpdateRoomByRoomNoDto.Error_NotFound();
                return oUpdateRoomByRoomNoDto;
            }

            source.RoomStateId = 3;
            source.CustoNo = null;
            source.CheckOutTime = DateTime.Now;
            source.datachg_usr = checkoutRoomDto.NowLoginUsr;
            source.datachg_date = DateTime.Now;
            this._roomRepository.Update(source);
            oUpdateRoomByRoomNoDto.OK();

            return oUpdateRoomByRoomNoDto;
        }

        /// <summary>
        /// 根据房间编号退房（入住）
        /// </summary>
        /// <param name="checkInRoomDto"></param>
        /// <returns></returns>
        public OUpdCheckInRoomDto UpdCheckInRoom(UpdCheckInRoomDto checkInRoomDto)
        {
            OUpdCheckInRoomDto oCheckInRoomDto = new OUpdCheckInRoomDto();

            //查询房间信息
            var source = this._roomRepository.Single(a => a.RoomNo.Equals(checkInRoomDto.RoomNo));

            if (source.IsNullOrEmpty())
            {
                oCheckInRoomDto.Error_NotFound();
                return oCheckInRoomDto;
            }

            source.RoomStateId = 1;
            source.CustoNo = checkInRoomDto.CustoNo;
            source.CheckOutTime = null;
            source.CheckTime = DateTime.Now;
            source.datachg_usr = checkInRoomDto.NowLoginUsr;
            source.datachg_date = DateTime.Now;
            this._roomRepository.Update(source);
            oCheckInRoomDto.OK();

            return oCheckInRoomDto;
        }

        /// <summary>
        /// 根据房间编号退房（预约）
        /// </summary>
        /// <param name="reserRoomDto"></param>
        /// <returns></returns>
        public OUpdReserRoomDto UpdReserRoom(UpdReserRoomDto reserRoomDto)
        {
            OUpdReserRoomDto oReserRoomDto = new OUpdReserRoomDto();

            //查询房间信息
            var source = this._roomRepository.Single(a => a.RoomNo.Equals(reserRoomDto.RoomNo));

            if (source.IsNullOrEmpty())
            {
                oReserRoomDto.Error_NotFound();
                return oReserRoomDto;
            }

            source.RoomStateId = 4;
            source.CustoNo = null;
            source.CheckOutTime = null;
            source.CheckTime = null;
            source.datachg_usr = reserRoomDto.NowLoginUsr;
            source.datachg_date = DateTime.Now;
            this._roomRepository.Update(source);
            oReserRoomDto.OK();

            return oReserRoomDto;
        }

        /// <summary>
        /// 根据房间编号查询截止到今天住了多少天
        /// </summary>
        /// <param name="dayByRoomNoDto"></param>
        /// <returns></returns>
        public ODayByRoomNoDto DayByRoomNo(DayByRoomNoDto dayByRoomNoDto)
        {
            ODayByRoomNoDto oDayByRoomNoDto = new ODayByRoomNoDto();

            //查询房间信息
            var source = this._roomRepository.Single(a => a.RoomNo.Equals(dayByRoomNoDto.RoomNo));

            if (source.IsNullOrEmpty())
            {
                oDayByRoomNoDto.Error_NotFound();
                return oDayByRoomNoDto;
            }

            oDayByRoomNoDto.days = Math.Abs(((TimeSpan)(source.CheckTime - DateTime.Now)).Days);
            oDayByRoomNoDto.OK();

            return oDayByRoomNoDto;
        }

        /// <summary>
        /// 添加房间
        /// </summary>
        /// <param name="insertRoomDto"></param>
        /// <returns></returns>
        public OInsertRoomDto InsertRoom(InsertRoomDto insertRoomDto)
        {
            OInsertRoomDto oInsertRoomDto = new OInsertRoomDto();

            var source = new Room();

            source = source.UpdateToModel(insertRoomDto);
            source.delete_mk = 0;
            source.datains_usr = insertRoomDto.NowLoginUsr;
            source.datains_date = DateTime.Now;
            this._roomRepository.Insert(source);
            oInsertRoomDto.OK();

            return oInsertRoomDto;
        }

    }
}
