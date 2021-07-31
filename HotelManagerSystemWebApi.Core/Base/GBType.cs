using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 奖惩类型表
    /// </summary>
    [Table("gbtype")]
    public class GBType : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public GBType()
        {
        }

        /// <summary>
        /// 奖惩类型ID
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.Int32 GBTypeId { get; set; }

        /// <summary>
        /// 奖惩类型信息
        /// </summary>
        public System.String GBName { get; set; }

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
