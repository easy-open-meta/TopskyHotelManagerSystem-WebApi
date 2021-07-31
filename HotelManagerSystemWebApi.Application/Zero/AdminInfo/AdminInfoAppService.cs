using Furion.DynamicApiController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 管理员信息控制器
    /// </summary>
    public class AdminInfoAppService: IDynamicApiController
    {
        /// <summary>
        /// 管理员信息
        /// </summary>
        private readonly IAdminInfoService adminInfoService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="adminInfoService"></param>
        public AdminInfoAppService(IAdminInfoService adminInfoService)
        {
            this.adminInfoService = adminInfoService;
        }

        /// <summary>
        /// 查询管理员信息列表
        /// </summary>
        /// <param name="adminInfoListDto"></param>
        /// <returns></returns>
        public OAdminInfoListDto AdminInfoList(AdminInfoListDto adminInfoListDto)
        {
            return adminInfoService.AdminInfoList(adminInfoListDto);
        }

        /// <summary>
        /// 查询管理员信息
        /// </summary>
        /// <param name="adminInfoDto"></param>
        /// <returns></returns>
        public OAdminInfoDto AdminInfo(AdminInfoDto adminInfoDto)
        {
            return adminInfoService.AdminInfo(adminInfoDto);
        }

        /// <summary>
        /// 添加管理员信息
        /// </summary>
        /// <param name="addAdminInfoDto"></param>
        /// <returns></returns>
        public OAddAdminInfoDto AddAdminInfo(AddAdminInfoDto addAdminInfoDto)
        {
            return adminInfoService.AddAdminInfo(addAdminInfoDto);
        }

        /// <summary>
        /// 删除管理员信息
        /// </summary>
        /// <param name="delAdminInfoDto"></param>
        /// <returns></returns>
        public ODelAdminInfoDto DelAdminInfo(DelAdminInfoDto delAdminInfoDto)
        {
            return adminInfoService.DelAdminInfo(delAdminInfoDto);
        }

        /// <summary>
        /// 更新管理员信息
        /// </summary>
        /// <param name="updAdminInfoDto"></param>
        /// <returns></returns>
        public OUpdAdminInfoDto UpdAdminInfo(UpdAdminInfoDto updAdminInfoDto)
        {
            return adminInfoService.UpdAdminInfo(updAdminInfoDto);
        }

    }
}
