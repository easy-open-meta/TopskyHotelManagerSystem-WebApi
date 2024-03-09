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
 *模块说明：员工奖惩类
 */
using System;

namespace EOM.TSHotelManager.Common.Core
{
    /// <summary>
    /// 员工奖罚
    /// </summary>
    [SqlSugar.SugarTable("workergoodbad")]
    public class WorkerGoodBad : BaseDTO
    {
        /// <summary>
        /// 编号
        /// </summary>
        [SqlSugar.SugarColumn(IsOnlyIgnoreInsert = true, IsOnlyIgnoreUpdate = true)]
        public int Id { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public string WorkNo { get; set; }
        /// <summary>
        /// 奖惩信息
        /// </summary>
        public string GBInfo { get; set; }
        /// <summary>
        /// 奖惩类型
        /// </summary>
        public int GBType { get; set; }
        /// <summary>
        /// 奖惩操作人
        /// </summary>
        public string GBOperation { get; set; }
        /// <summary>
        /// 奖惩操作人
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string OperationName { get; set; }
        /// <summary>
        /// 奖惩时间
        /// </summary>
        public DateTime GBTime { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string TypeName { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public int delete_mk { get; set; }
    }
}
