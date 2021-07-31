using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 跑马灯内容表
    /// </summary>
    [Table("fonts")]
    public class Fonts : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Fonts()
        {
        }

        /// <summary>
        /// 内容ID
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.Int32 FontsId { get; set; }

        /// <summary>
        /// 内容信息
        /// </summary>
        public System.String FontsMess { get; set; }

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
