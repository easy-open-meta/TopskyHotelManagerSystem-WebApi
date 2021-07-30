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
    }
}
