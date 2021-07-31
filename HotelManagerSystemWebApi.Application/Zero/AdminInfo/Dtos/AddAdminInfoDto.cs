using HotelManagerSystemWebApi.Core;
using System.ComponentModel.DataAnnotations;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 添加管理员信息
    /// 输入DTO
    /// </summary>
    public class AddAdminInfoDto:IBaseDto
    {
        /// <summary>
        /// 管理员账号
        /// </summary>
        [Required]
        public System.String AdminAccount { get; set; }

        /// <summary>
        /// 管理员密码
        /// </summary>
        [Required]
        public System.String AdminPassword { get; set; }

        /// <summary>
        /// 管理员类型
        /// </summary>
        [Required]
        public System.String AdminType { get; set; }

        /// <summary>
        /// 管理员名称
        /// </summary>
        [Required]
        public System.String AdminName { get; set; }

        /// <summary>
        /// 是否为超级管理员
        /// </summary>
        public System.Int32 IsAdmin { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public System.Int32 DeleteMk { get; set; }

        /// <summary>
        /// 资料新增人
        /// </summary>
        public System.String datains_usr { get; set; }

        /// <summary>
        /// 资料新增时间
        /// </summary>
        public System.DateTime? datains_time { get; set; }

    }
}