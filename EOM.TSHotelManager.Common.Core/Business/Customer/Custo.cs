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
 *模块说明：客户信息类
 */
using EOM.TSHotelManager.Common.Util;
using System;

namespace EOM.TSHotelManager.Common.Core
{
    /// <summary>
    /// 客户信息
    /// </summary>
    [SqlSugar.SugarTable("customer")]
    public class Custo : BaseDTO
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        //[SqlSugar.SugarColumn(ColumnName = "id", IsPrimaryKey = true,IsIdentity = true)]
        //public int Id { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        [UIDisplay("客户编号")]
        [SqlSugar.SugarColumn(ColumnName = "custo_no", IsPrimaryKey = true)]
        public string CustoNo { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        [UIDisplay("客户名称")]
        [SqlSugar.SugarColumn(ColumnName = "custo_name", IsNullable = false)]
        public string CustoName { get; set; }
        /// <summary>
        /// 客户性别
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "custo_sex", IsNullable = true)]
        public int CustoSex { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "passport_type", IsNullable = false)]
        public int PassportType { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [UIDisplay("性别")]
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string SexName { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        [UIDisplay("联系方式")]
        [SqlSugar.SugarColumn(ColumnName = "custo_tel", IsNullable = false)]
        public string CustoTel { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        [UIDisplay("出生日期")]
        [SqlSugar.SugarColumn(ColumnName = "custo_birth", IsNullable = true)]
        public DateTime CustoBirth { get; set; }
        /// <summary>
        /// 客户类型
        /// </summary>
        [UIDisplay("客户类型")]
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string typeName { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        [UIDisplay("证件类型")]
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string PassportName { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        [UIDisplay("证件号码")]
        [SqlSugar.SugarColumn(ColumnName = "passport_id", IsNullable = false)]
        public string CustoID { get; set; }
        /// <summary>
        /// 居住地址
        /// </summary>
        [UIDisplay("客户地址")]
        [SqlSugar.SugarColumn(ColumnName = "custo_address", IsNullable = true)]
        public string CustoAdress { get; set; }
        /// <summary>
        /// 客户类型
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "custo_type", IsNullable = false)]
        public int CustoType { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public int delete_mk { get; set; }

    }
}
