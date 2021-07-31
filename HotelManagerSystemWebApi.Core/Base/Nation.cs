using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 民族信息表
    /// </summary>
    [Table("nation")]
    public class Nation : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Nation()
        {
        }

        /// <summary>
        /// 民族编号
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.String nation_no { get; set; }

        /// <summary>
        /// 民族名称
        /// </summary>
        public System.String nation_name { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public System.Int32 delete_mk { get; set; }

        /// <summary>
        /// 资料创建人
        /// </summary>
        public System.String datains_usr { get; set; }

        /// <summary>
        /// 资料创建时间
        /// </summary>
        public System.DateTime? datains_date { get; set; }

        /// <summary>
        /// 资料更新人
        /// </summary>
        public System.String datachg_usr { get; set; }

        /// <summary>
        /// 资料更新时间
        /// </summary>
        public System.DateTime? datachg_date { get; set; }
    }
}
