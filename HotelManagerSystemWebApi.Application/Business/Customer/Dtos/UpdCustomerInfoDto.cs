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
    /// 更新客户信息
    /// 输入DTO
    /// </summary>
    public class UpdCustomerInfoDto : IBaseDto
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        [Required]
        public string CustoNo { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        [Required]
        public string CustoName { get; set; }
        /// <summary>
        /// 客户性别
        /// </summary>
        [Required]
        public int CustoSex { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        [Required]
        public string CustoTel { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        [Required]
        public int PassportType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        [Required]
        public string CustoID { get; set; }
        /// <summary>
        /// 居住地址
        /// </summary>
        public string CustoAdress { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime CustoBirth { get; set; }
        /// <summary>
        /// 客户类型
        /// </summary>
        public int CustoType { get; set; }
        /// <summary>
        /// 客户类型
        /// </summary>
        public string typeName { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string PassportName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string SexName { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public int delete_mk { get; set; }
    }
}