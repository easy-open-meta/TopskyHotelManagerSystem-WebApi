using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 会员等级规则表
    /// </summary>
    [Table("vip_rule")]
    public class VipRule : IEntity
    {
        /// <summary>
        /// 会员等级规则表
        /// </summary>
        public VipRule()
        {
        }

        /// <summary>
        /// 索引ID
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 会员规则流水号
        /// </summary>
        public System.String rule_id { get; set; }

        /// <summary>
        /// 会员规则名称
        /// </summary>
        public System.String rule_name { get; set; }

        /// <summary>
        /// 预设数值
        /// </summary>
        public System.Decimal rule_value { get; set; }

        /// <summary>
        /// 会员等级
        /// </summary>
        public System.Int32 type_id { get; set; }

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
