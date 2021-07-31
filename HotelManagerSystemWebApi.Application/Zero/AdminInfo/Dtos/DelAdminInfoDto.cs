using HotelManagerSystemWebApi.Core;
using System.ComponentModel.DataAnnotations;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 删除管理员信息
    /// 输入DTO
    /// </summary>
    public class DelAdminInfoDto:IBaseDto
    {
        /// <summary>
        /// 管理员账号
        /// </summary>
        [Required]
        public System.String AdminAccount { get; set; }
    }
}