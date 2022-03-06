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
    }
}
