using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Core
{

    /// <summary>
    /// 模块权限表
    /// </summary>
    [Table("module_zero")]
    public class ModuleZero
    {
        /// <summary>
        /// 模块ID
        /// </summary>
        public int module_id { get; set; }
        /// <summary>
        /// 管理员账号
        /// </summary>
        [Column("admin_account")]
        public string admin_account { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        [Column("module_name")]
        public string module_name { get; set; }
        /// <summary>
        /// 是否开启
        /// </summary>
        [Column("module_enable")]
        public int module_enable { get; set; }
    }
}
