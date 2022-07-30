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

using HotelManagerSystemWebApi.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 修改水电费信息
    /// 输入DTO
    /// </summary>
    public class UpdateHydropowerInfoDto:IBaseDto
    {
        /// <summary>
        /// 信息编号
        /// </summary>
        [Required]
        public int WtiNo { get; set; }
        /// <summary>
        /// 房间编号
        /// </summary>
        [Required]
        public string RoomNo { get; set; }
        /// <summary>
        /// 开始使用时间
        /// </summary>
        [Required]
        public DateTime UseDate { get; set; }
        /// <summary>
        /// 结束使用时间
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 水费
        /// </summary>
        [Required]
        public decimal WaterUse { get; set; }
        /// <summary>
        /// 电费
        /// </summary>
        [Required]
        public decimal PowerUse { get; set; }
        /// <summary>
        /// 记录员
        /// </summary>
        public string Record { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        [Required]
        public string CustoNo { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public int delete_mk { get; set; }
    }
}