using Furion.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 管理员信息模块接口
    /// </summary>
    public interface IAdminInfoService
    {
        /// <summary>
        /// 查询管理员信息列表
        /// </summary>
        /// <param name="adminInfoListDto"></param>
        /// <returns></returns>
        OAdminInfoListDto AdminInfoList(AdminInfoListDto adminInfoListDto);

        /// <summary>
        /// 查询管理员信息
        /// </summary>
        /// <param name="adminInfoDto"></param>
        /// <returns></returns>
        OAdminInfoDto AdminInfo(AdminInfoDto adminInfoDto);

        /// <summary>
        /// 添加管理员信息
        /// </summary>
        /// <param name="addAdminInfoDto"></param>
        /// <returns></returns>
        OAddAdminInfoDto AddAdminInfo(AddAdminInfoDto addAdminInfoDto);

        /// <summary>
        /// 删除管理员信息
        /// </summary>
        /// <param name="delAdminInfoDto"></param>
        /// <returns></returns>
        ODelAdminInfoDto DelAdminInfo(DelAdminInfoDto delAdminInfoDto);

        /// <summary>
        /// 更新管理员信息
        /// </summary>
        /// <param name="updAdminInfoDto"></param>
        /// <returns></returns>
        OUpdAdminInfoDto UpdAdminInfo(UpdAdminInfoDto updAdminInfoDto);

        //#region 根据超管密码查询员工类型和权限
        ///// <summary>
        ///// 根据超管密码查询员工类型和权限
        ///// </summary>
        ///// <param name="admin"></param>
        ///// <returns></returns>
        //Admin SelectMangerByPass(Admin admin);
        //#endregion


        //#region 根据超管账号查询对应的密码
        ///// <summary>
        ///// 根据超管账号查询对应的密码
        ///// </summary>
        ///// <param name="account"></param>
        ///// <returns></returns>
        //Admin SelectAdminPwdByAccount(string account);
        //#endregion

        ///// <summary>
        ///// 获取所有管理员列表
        ///// </summary>
        ///// <returns></returns>
        //List<Admin> GetAllAdminList();

        ///// <summary>
        ///// 修改密码
        ///// </summary>
        ///// <param name="admin"></param>
        ///// <returns></returns>
        //bool UpdateNewPwdByOldPwd(Admin admin);

        ///// <summary>
        ///// 获取管理员列表
        ///// </summary>
        ///// <returns></returns>
        //List<Admin> GetAllAdmin();

        ///// <summary>
        ///// 添加管理员
        ///// </summary>
        ///// <param name="admin"></param>
        ///// <returns></returns>
        //bool AddAdmin(Admin admin);

        ///// <summary>
        ///// 获取管理员信息
        ///// </summary>
        ///// <param name="admin"></param>
        ///// <returns></returns>
        //Admin GetAdminInfoByAdminAccount(Admin admin);

        ///// <summary>
        ///// 获取所有管理员类型
        ///// </summary>
        ///// <returns></returns>
        //List<AdminType> GetAllAdminTypes();

        ///// <summary>
        ///// 批量更新管理员账户
        ///// </summary>
        ///// <param name="admins"></param>
        ///// <returns></returns>
        //bool UpdAccount(Admin admins);
    }
}
