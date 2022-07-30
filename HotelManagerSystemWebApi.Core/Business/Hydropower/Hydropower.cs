﻿/*
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
 *模块说明：水电信息类
 */
using Furion.DatabaseAccessor;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 水电信息
    /// </summary>
    [Table("wtinfo")]
    public class Hydropower:IEntity
    {
        /// <summary>
        /// 信息编号
        /// </summary>
        [Column("WtiNo")]
        public int WtiNo { get; set; }
        /// <summary>
        /// 房间编号
        /// </summary>
        [Column("RoomNo")]
        public string RoomNo { get; set; }
        /// <summary>
        /// 开始使用时间
        /// </summary>
        [Column("UseDate")]
        public DateTime UseDate { get; set; }
        /// <summary>
        /// 结束使用时间
        /// </summary>
        [Column("EndDate")]
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 水费
        /// </summary>
        [Column( "WaterUse")]
        public decimal WaterUse { get; set; }
        /// <summary>
        /// 电费
        /// </summary>
        [Column("PowerUse")]
        public decimal PowerUse { get; set; }
        /// <summary>
        /// 记录员
        /// </summary>
        [Column("Record")]
        public string Record { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        [Column("CustoNo")]
        public string CustoNo { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        [Column("delete_mk")]
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
