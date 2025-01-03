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
 *模块说明：房间类
 */
using EOM.TSHotelManager.Common.Util;
using System;
//using System.ComponentModel.DataAnnotations.Schema;

namespace EOM.TSHotelManager.Common.Core
{
    /// <summary>
    /// 房间实体类
    /// </summary>
    [SqlSugar.SugarTable("room")]
    public class Room : BaseDTO
    {
        /// <summary>
        /// 房间编号
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "room_no", IsPrimaryKey = true)]
        [NeedValid]
        public string RoomNo { get; set; }
        /// <summary>
        /// 房间类型
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "room_type")]
        [NeedValid]
        public int RoomType { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "custo_no")]
        public string CustoNo { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string CustoName { get; set; }
        /// <summary>
        /// 最后一次入住时间
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "check_in_time")]
        public DateTime? CheckTime { get; set; }
        /// <summary>
        /// 最后一次退房时间
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "check_out_time")]
        public DateTime? CheckOutTime { get; set; }
        /// <summary>
        /// 房间状态ID
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "room_state_id")]
        [NeedValid]
        public int RoomStateId { get; set; }
        /// <summary>
        /// 房间状态
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string RoomState { get; set; }
        /// <summary>
        /// 房间单价
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "room_rent")]
        [NeedValid]
        public decimal RoomMoney { get; set; }
        /// <summary>
        /// 房间押金
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "room_deposit")]
        [NeedValid]
        public decimal RoomDeposit { get; set; }
        /// <summary>
        /// 房间位置
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "room_position")]
        [NeedValid]
        public string RoomPosition { get; set; }
        /// <summary>
        /// 客户类型名称
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string typeName { get; set; }
        /// <summary>
        /// 房间名称
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string RoomName { get; set; }
        /// <summary>
        /// 最后一次入住时间
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string CheckTimeFormat { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public int delete_mk { get; set; }

    }
}
