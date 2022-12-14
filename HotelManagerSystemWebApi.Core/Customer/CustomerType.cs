using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 客户类型表
    /// </summary>
    [Table("usertype")]
    public class CustomerType : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public CustomerType()
        {
        }

        /// <summary>
        /// 客户类型ID
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.Int32 UserType { get; set; }

        /// <summary>
        /// 客户类型名称
        /// </summary>
        public System.String TypeName { get; set; }

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
