using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 功能模块权限表
    /// </summary>
    [Table("module_zero")]
    public class ModuleZero : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public ModuleZero()
        {
        }

        /// <summary>
        /// 模块ID
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.Int32 module_id { get; set; }

        /// <summary>
        /// 管理员账号
        /// </summary>
        public System.String admin_account { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public System.String module_name { get; set; }

        /// <summary>
        /// 是否开启
        /// </summary>
        public System.Int32? module_enable { get; set; }
    }
}
