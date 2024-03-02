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
 */
using EOM.TSHotelManager.Common.Core;
using System.Collections.Generic;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 管理员数据访问接口
    /// </summary>
    public interface IAdminService
    {

        #region 根据超管密码查询员工类型和权限
        /// <summary>
        /// 根据超管密码查询员工类型和权限
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        Admin SelectMangerByPass(Admin admin);
        #endregion

        #region 根据超管账号查询对应的密码
        /// <summary>
        /// 根据超管账号查询对应的密码
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Admin SelectAdminPwdByAccount(string account);
        #endregion

        /// <summary>
        /// 获取所有管理员列表
        /// </summary>
        /// <returns></returns>
        List<Admin> GetAllAdminList();

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        bool UpdateNewPwdByOldPwd(Admin admin);

        /// <summary>
        /// 获取管理员列表
        /// </summary>
        /// <returns></returns>
        List<Admin> GetAllAdmin();

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        bool AddAdmin(Admin admin);

        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        Admin GetAdminInfoByAdminAccount(Admin admin);

        /// <summary>
        /// 获取所有管理员类型
        /// </summary>
        /// <returns></returns>
        List<AdminType> GetAllAdminTypes();

        /// <summary>
        /// 批量更新管理员账户
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        bool UpdAccount(Admin admins);
    }
}