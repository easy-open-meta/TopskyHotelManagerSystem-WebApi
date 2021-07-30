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

    }
}
