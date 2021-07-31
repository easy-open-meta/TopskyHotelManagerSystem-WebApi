using HotelManagerSystemWebApi.Core;
using System.ComponentModel.DataAnnotations;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 查询管理员信息
    /// 输入DTO
    /// </summary>
    public class AdminInfoDto:IBaseDto
    {
        /// <summary>
        /// 管理员账号
        /// </summary>
        [Required]
        public string AdminAccount { get; set; }
    }
}