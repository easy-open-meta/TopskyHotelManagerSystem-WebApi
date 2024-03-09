using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 系统模块控制器
    /// </summary>
    public class ModuleController : ControllerBase
    {
        /// <summary>
        /// 系统模块
        /// </summary>
        private readonly IAdminModuleZeroService adminModuleZeroService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminModuleZeroService"></param>
        public ModuleController(IAdminModuleZeroService adminModuleZeroService)
        {
            this.adminModuleZeroService = adminModuleZeroService;
        }

        /// <summary>
        /// 获取所有模块
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Module> GetAllModule()
        {
            return adminModuleZeroService.GetAllModule();
        }

        /// <summary>
        /// 根据账号获取对应模块
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [HttpPost]
        public List<ModuleZero> GetAllModuleByAdmin([FromBody] Admin admin)
        {
            return adminModuleZeroService.GetAllModuleByAdmin(admin);
        }

        /// <summary>
        /// 批量添加模块
        /// </summary>
        /// <param name="moduleZeros"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddModuleZeroList([FromBody] List<ModuleZero> moduleZeros)
        {
            return adminModuleZeroService.AddModuleZeroList(moduleZeros);
        }

        /// <summary>
        /// 批量删除模块
        /// </summary>
        /// <param name="moduleZero"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DelModuleZeroList([FromBody] ModuleZero moduleZero)
        {
            return adminModuleZeroService.DelModuleZeroList(moduleZero);
        }

    }
}
