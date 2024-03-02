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
 *模块说明：消费信息类
 */
using System;

namespace EOM.TSHotelManager.Common.Core
{
    /// <summary>
    /// 消费信息
    /// </summary>
    [SqlSugar.SugarTable("custospend")]
    public class Spend : BaseDTO
    {
        /// <summary>
        /// 房间编号
        /// </summary>
        public string RoomNo { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustoNo { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string SpendName { get; set; }
        /// <summary>
        /// 消费数量
        /// </summary>
        public int SpendAmount { get; set; }
        /// <summary>
        /// 商品单价
        /// </summary>
        public decimal SpendPrice { get; set; }
        /// <summary>
        /// 商品单价描述
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string SpendPriceStr { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal SpendMoney { get; set; }
        /// <summary>
        /// 消费金额描述
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string SpendMoneyStr { get; set; }
        /// <summary>
        /// 消费时间
        /// </summary>
        public DateTime SpendTime { get; set; }
        /// <summary>
        /// 结算状态
        /// </summary>
        public string MoneyState { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public int delete_mk { get; set; }
        /// <summary>
        /// 结算状态描述
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string SpendStateNm { get; set; }
    }
}
