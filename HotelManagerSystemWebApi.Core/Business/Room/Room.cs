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
 *模块说明：房间类
 */
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 房间实体类
    /// </summary>
    [Table("room")]
    public class Room
    {
        /// <summary>
        /// 房间编号
        /// </summary>
        public string RoomNo { get; set; }
        /// <summary>
        /// 房间类型
        /// </summary>
        public int RoomType { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustoNo { get; set; }
        /// <summary>
        /// 最后一次入住时间
        /// </summary>
        public DateTime? CheckTime { get; set; }
        /// <summary>
        /// 最后一次退房时间
        /// </summary>
        public DateTime? CheckOutTime { get; set; }
        /// <summary>
        /// 房间状态ID
        /// </summary>
        public int RoomStateId { get; set; }
        ///// <summary>
        ///// 房间状态
        ///// </summary>
        //[SqlSugar.SugarColumn(IsIgnore = true)]
        //public string RoomState { get; set; }
        /// <summary>
        /// 房间单价
        /// </summary>
        public decimal RoomMoney { get; set; }
        /// <summary>
        /// 房间押金
        /// </summary>
        [Column("deposit")]
        public decimal RoomDeposit { get; set; }
        /// <summary>
        /// 房间位置
        /// </summary>
        public string RoomPosition { get; set; }
        ///// <summary>
        ///// 客户类型名称
        ///// </summary>
        //[SqlSugar.SugarColumn(IsIgnore = true)]
        //public string typeName { get; set; }
        ///// <summary>
        ///// 房间名称
        ///// </summary>
        //[SqlSugar.SugarColumn(IsIgnore = true)]
        //public string RoomName { get; set; }
        ///// <summary>
        ///// 最后一次入住时间
        ///// </summary>
        //[SqlSugar.SugarColumn(IsIgnore = true)]
        //public string CheckTimeFormat { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public int delete_mk { get; set; }
        /// <summary>
        /// 资料创建人
        /// </summary>
        public string datains_usr { get; set; }
        /// <summary>
        /// 资料创建时间
        /// </summary>
        public DateTime datains_date { get; set; }
        /// <summary>
        /// 资料更新人
        /// </summary>
        public string datachg_usr { get; set; }
        /// <summary>
        /// 资料更新时间
        /// </summary>
        public DateTime datachg_date { get; set; }

    }
}
