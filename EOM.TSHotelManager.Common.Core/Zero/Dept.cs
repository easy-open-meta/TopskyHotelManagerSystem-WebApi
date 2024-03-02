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
 *模块说明：部门实体类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOM.TSHotelManager.Common.Core
{
    /// <summary>
    /// 部门表
    /// </summary>
    [SqlSugar.SugarTable("dept")]
    public class Dept : BaseDTO
    {
        /// <summary>
        /// 部门编号
        /// </summary>  
        [SqlSugar.SugarColumn(ColumnName = "dept_no")]
        public string dept_no { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "dept_name")]
        public string dept_name { get; set; }
        /// <summary>
        /// 部门描述
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "dept_desc")]
        public string dept_desc { get; set; }
        /// <summary>
        /// 创建时间(部门)
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "dept_date")]
        public DateTime dept_date { get; set; }
        /// <summary>
        /// 部门主管
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "dept_leader")]
        public string dept_leader { get; set; }
        /// <summary>
        /// 部门主管
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string leader_name { get; set; }
        /// <summary>
        /// 上级部门
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "dept_parent")]
        public string dept_parent { get; set; }
        /// <summary>
        /// 上级部门
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string parent_name { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "delete_mk")]
        public int delete_mk { get; set; }

    }
}
