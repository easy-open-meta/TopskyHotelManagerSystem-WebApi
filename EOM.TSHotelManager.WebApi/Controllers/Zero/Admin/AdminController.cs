using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 管理员控制器
    /// </summary>
    public class AdminController : ControllerBase
    {
        /// <summary>
        /// 管理员模块
        /// </summary>
        private readonly IAdminService adminService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminService"></param>
        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        /// <summary>
        /// 根据超管密码查询员工类型和权限
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public Admin SelectManagerByPass([FromBody] Admin admin)
        {
            return adminService.SelectManagerByPass(admin);
        }

        /// <summary>
        /// 根据超管账号查询对应的密码
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpGet]
        public Admin SelectAdminPwdByAccount([FromQuery] string account)
        {
            return adminService.SelectAdminPwdByAccount(account);
        }

        /// <summary>
        /// 获取所有管理员列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Admin> GetAllAdminList()
        {
            return adminService.GetAllAdminList();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateNewPwdByOldPwd([FromBody] Admin admin)
        {
            return adminService.UpdateNewPwdByOldPwd(admin);
        }

        /// <summary>
        /// 获取管理员列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Admin> GetAllAdmin()
        {
            return adminService.GetAllAdmin();
        }

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddAdmin([FromBody] Admin admin)
        {
            return adminService.AddAdmin(admin);
        }

        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [HttpGet]
        public Admin GetAdminInfoByAdminAccount([FromQuery] Admin admin)
        {
            return adminService.GetAdminInfoByAdminAccount(admin);
        }

        /// <summary>
        /// 获取所有管理员类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<AdminType> GetAllAdminTypes()
        {
            return adminService.GetAllAdminTypes();
        }

        /// <summary>
        /// 批量更新管理员账户
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdAccount([FromBody] Admin admins)
        {
            return adminService.UpdAccount(admins);
        }

    }
}
