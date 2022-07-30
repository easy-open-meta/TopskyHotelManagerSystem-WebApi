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
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.LinqBuilder;
using HotelManagerSystemWebApi.Core;
using jvncorelib.EncryptorLib;
using jvncorelib.EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 预约信息接口实现类
    /// </summary>
    public class ReserService:IReserService, ITransient
    {
        /// <summary>
        /// 预约信息
        /// </summary>
        private readonly IRepository<Reser> reserRepository;

        /// <summary>
        /// 房间信息
        /// </summary>
        private readonly IRepository<Room> roomRepository;

        /// <summary>
        /// 房间类型
        /// </summary>
        private readonly IRepository<RoomType> roomTypeRepository;

        EncryptLib encryptLib = new EncryptLib();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserRepository"></param>
        /// <param name="roomRepository"></param>
        /// <param name="roomTypeRepository"></param>
        public ReserService(IRepository<Reser> reserRepository, IRepository<Room> roomRepository, IRepository<RoomType> roomTypeRepository)
        {
            this.reserRepository = reserRepository;
            this.roomRepository = roomRepository;
            this.roomTypeRepository = roomTypeRepository;
        }

        /// <summary>
        /// 获取所有预约信息
        /// </summary>
        /// <param name="selectReserAllDto"></param>
        /// <returns></returns>
        public OSelectReserAllDto SelectReserAll(SelectReserAllDto selectReserAllDto)
        {
            OSelectReserAllDto oSelectReserAllDto = new OSelectReserAllDto();

            var where = LinqExpression.Create<Reser>(a => a.delete_mk != 1);

            //预约流水号
            if(!selectReserAllDto.ReserId.IsNullOrEmpty())
            {
                where = where.And(a => a.ReserId.Contains(a.ReserId));
            }
            //客户名称
            if (!selectReserAllDto.CustoName.IsNullOrEmpty())
            {
                where = where.And(a => a.CustoName.Contains(a.CustoName));
            }
            //联系方式
            if (!selectReserAllDto.CustoTel.IsNullOrEmpty())
            {
                where = where.And(a => a.CustoTel.Contains(a.CustoTel));
            }
            //预约方式
            if (!selectReserAllDto.ReserWay.IsNullOrEmpty())
            {
                where = where.And(a => a.ReserWay.Equals(a.ReserWay));
            }
            //预约房号
            if (!selectReserAllDto.ReserRoom.IsNullOrEmpty())
            {
                where = where.And(a => a.ReserRoom.Contains(a.ReserRoom));
            }

            var count = 0;

            var listSource = reserRepository.AsQueryable(where).ToList()
                .GetPageList(selectReserAllDto.PageIndex, selectReserAllDto.PageSize, ref count)
                .CopyToModel<Reser, Temp_Reser>();

            var listRoomNo = listSource.Select(a => a.ReserRoom).Distinct().ToList();
            var listRoom = this.roomRepository.AsQueryable(a => listRoomNo.Contains(a.RoomNo));

            var listRoomTypeId = listRoom.Select(a => a.RoomType).Distinct().ToList();
            var listRoomType = this.roomTypeRepository.AsQueryable(a => listRoomTypeId.Contains(a.Roomtype));

            listSource.ForEach(source => 
            {
                var room = listRoom.FirstOrDefault(a => a.RoomNo.Equals(source.ReserRoom));
                var roomType = listRoomType.FirstOrDefault(a => a.Roomtype.Equals(room.RoomType));
                source.ReserRoomType = roomType.IsNullOrEmpty() ? "" : roomType.RoomName;
            });

            oSelectReserAllDto.listSource = listSource;
            oSelectReserAllDto.total = count;
            oSelectReserAllDto.OK();

            return oSelectReserAllDto;
        }

        /// <summary>
        /// 添加预约信息
        /// </summary>
        /// <param name="inserReserInfoDto"></param>
        /// <returns></returns>
        public OInserReserInfoDto InserReserInfo(InserReserInfoDto inserReserInfoDto)
        {
            OInserReserInfoDto oInserReserInfoDto = new OInserReserInfoDto();

            var source = new Reser();

            source = source.UpdateToModel(inserReserInfoDto);
            source.datains_usr = inserReserInfoDto.NowLoginUsr;
            source.datains_date = DateTime.Now;
            this.reserRepository.Insert(source);
            oInserReserInfoDto.OK();

            return oInserReserInfoDto;
        }
    }
}
