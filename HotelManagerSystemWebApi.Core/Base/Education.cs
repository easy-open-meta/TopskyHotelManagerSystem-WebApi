using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 教育程度表
    /// </summary>
    [Table("education")]
    public class Education : IEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Education()
        {
        }

        /// <summary>
        /// 学历编号
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.String education_no { get; set; }

        /// <summary>
        /// 学历名称
        /// </summary>
        public System.String education_name { get; set; }

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
