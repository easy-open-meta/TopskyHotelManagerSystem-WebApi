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
 *模块说明：管理员实体类
 */
namespace EOM.TSHotelManager.Common.Core
{
    /// <summary>
    /// 管理员实体类
    /// </summary>
    [SqlSugar.SugarTable("admininfo")]
    public class Admin : BaseDTO
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Admin()
        {
        }

        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        private string _AdminAccount;
        /// <summary>
        /// 管理员账号
        /// </summary>
        [SqlSugar.SugarColumn(IsPrimaryKey = true)]
        public string AdminAccount { get { return this._AdminAccount; } set { this._AdminAccount = value; } }

        private string _AdminPassword;
        /// <summary>
        /// 管理员密码
        /// </summary>
        public string AdminPassword { get { return this._AdminPassword; } set { this._AdminPassword = value; } }

        private string _AdminType;
        /// <summary>
        /// 管理员类型
        /// </summary>
        public string AdminType { get { return this._AdminType; } set { this._AdminType = value; } }

        private string _AdminName;
        /// <summary>
        /// 管理员名称
        /// </summary>
        public string AdminName { get { return this._AdminName; } set { this._AdminName = value; } }

        private System.Int32 _IsAdmin;
        /// <summary>
        /// 是否为超级管理员
        /// </summary>
        public System.Int32 IsAdmin { get { return this._IsAdmin; } set { this._IsAdmin = value; } }

        private System.Int32 _DeleteMk;
        /// <summary>
        /// 删除标记
        /// </summary>
        public System.Int32 DeleteMk { get { return this._DeleteMk; } set { this._DeleteMk = value; } }

        /// <summary>
        /// 管理员类型描述
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string IsAdminNm { get; set; }

        /// <summary>
        /// 管理员类型
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string TypeName { get; set; }

        /// <summary>
        /// 删除标记描述
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string DeleteNm { get; set; }

    }
}
