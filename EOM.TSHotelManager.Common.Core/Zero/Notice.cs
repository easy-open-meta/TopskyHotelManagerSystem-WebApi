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
 *模块说明：任命公告类
 */
using System;

namespace EOM.TSHotelManager.Common.Core
{
    /// <summary>
    /// 任命公告
    /// </summary>
    [SqlSugar.SugarTable("uploadinfo")]
    public class Notice : BaseDTO
    {
        /// <summary>
        /// 公告编号
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "NoticeNo")]
        public string NoticeNo { get; set; }
        /// <summary>
        /// 公告主题
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "Noticetheme")]
        public string Noticetheme { get; set; }
        /// <summary>
        /// 公告类型
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "NoticeType")]
        public string NoticeType { get; set; }
        /// <summary>
        /// 公告类型(描述)
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string NoticeTypeName { get; set; }
        /// <summary>
        /// 公告时间
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "NoticeTime")]
        public DateTime NoticeTime { get; set; }
        /// <summary>
        /// 公告正文
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "NoticeContent")]
        public string NoticeContent { get; set; }
        /// <summary>
        /// 发文部门
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "NoticeClub")]
        public string NoticeClub { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "delete_mk")]
        public int delete_mk { get; set; }

    }
}
