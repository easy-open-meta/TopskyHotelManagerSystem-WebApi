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

using HotelManagerSystemWebApi.Application;
using HotelManagerSystemWebApi.Core;
using System.Collections.Generic;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 房间信息接口
    /// </summary>
    public interface IRoomService
    {
        /// <summary>
        /// 获取所有房间信息
        /// </summary>
        /// <param name="roomListDto"></param>
        /// <returns></returns>
        OSelectRoomListDto SelectRoomList(SelectRoomListDto roomListDto);

        /// <summary>
        /// 单条房间信息
        /// </summary>
        /// <param name="roomDto"></param>
        /// <returns></returns>
        OSelectRoomDto SelectRoom(SelectRoomDto roomDto);

        /// <summary>
        /// 根据房间编号退房（退房）
        /// </summary>
        /// <param name="updCheckoutRoomDto"></param>
        /// <returns></returns>
        OUpdCheckoutRoomDto UpdCheckoutRoom(UpdCheckoutRoomDto updCheckoutRoomDto);

        /// <summary>
        /// 根据房间编号退房（入住）
        /// </summary>
        /// <param name="updCheckInRoomDto"></param>
        /// <returns></returns>
        OUpdCheckInRoomDto UpdCheckInRoom(UpdCheckInRoomDto updCheckInRoomDto);

        /// <summary>
        /// 根据房间编号退房（预约）
        /// </summary>
        /// <param name="reserRoomDto"></param>
        /// <returns></returns>
        OUpdReserRoomDto UpdReserRoom(UpdReserRoomDto reserRoomDto);

        /// <summary>
        /// 根据房间编号查询截止到今天住了多少天
        /// </summary>
        /// <param name="dayByRoomNoDto"></param>
        /// <returns></returns>
        ODayByRoomNoDto DayByRoomNo(DayByRoomNoDto dayByRoomNoDto);

        /// <summary>
        /// 添加房间
        /// </summary>
        /// <param name="insertRoomDto"></param>
        /// <returns></returns>
        OInsertRoomDto InsertRoom(InsertRoomDto insertRoomDto);

    }
}