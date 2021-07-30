using HotelManagerSystemWebApi.Core;
using System.Collections.Generic;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 查询管理员信息列表
    /// </summary>
    public class OAdminInfoListDto
    {
        /// <summary>
        /// 数据源
        /// </summary>
        public List<AdminInfo> listSource { get; set; }
    }
}