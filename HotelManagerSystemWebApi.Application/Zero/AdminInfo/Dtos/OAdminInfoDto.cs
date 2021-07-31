using HotelManagerSystemWebApi.Core;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 查询管理员信息
    /// 输出DTO
    /// </summary>
    public class OAdminInfoDto:MsgDto
    {
        /// <summary>
        /// 数据源
        /// </summary>
        public AdminInfo source { get; set; }
    }
}