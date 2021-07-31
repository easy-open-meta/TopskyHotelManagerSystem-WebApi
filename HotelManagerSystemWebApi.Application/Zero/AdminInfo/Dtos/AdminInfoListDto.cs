using HotelManagerSystemWebApi.Core;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 查询管理员信息列表
    /// 输入DTO
    /// </summary>
    public class AdminInfoListDto:IListDto
    {
        /// <summary>
        /// 管理员名称
        /// </summary>
        public string AdminName { get; set; }

        /// <summary>
        /// 是否为超级管理员
        /// </summary>
        public int? IsAdmin { get; set; }
    }
}