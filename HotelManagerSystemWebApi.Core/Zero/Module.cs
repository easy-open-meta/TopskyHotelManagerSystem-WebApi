using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 功能模块表
    /// </summary>
    [Table("module")]
    public class Module : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Module()
        {
        }

        /// <summary>
        /// 模块ID
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.Int32 module_id { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public System.String module_name { get; set; }

        /// <summary>
        /// 模块描述
        /// </summary>
        public System.String module_desc { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public System.Int32 delete_mk { get; set; }

        /// <summary>
        /// 资料新增人
        /// </summary>
        public System.String datains_usr { get; set; }

        /// <summary>
        /// 资料新增时间
        /// </summary>
        public System.DateTime? datains_time { get; set; }

        /// <summary>
        /// 资料更新人
        /// </summary>
        public System.String datachg_usr { get; set; }

        /// <summary>
        /// 资料更新时间
        /// </summary>
        public System.DateTime? datachg_time { get; set; }
    }
}
