using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 流水号生成规则表
    /// </summary>
    [Table("counterrule")]
    public class CounterRule : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public CounterRule()
        {
        }

        /// <summary>
        /// 规则编号
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.Int32 rule_id { get; set; }

        /// <summary>
        /// 规格名称
        /// </summary>
        public System.String rule_name { get; set; }

        /// <summary>
        /// 规则描述
        /// </summary>
        public System.String rule_desc { get; set; }

        /// <summary>
        /// 当前ID
        /// </summary>
        public System.Int32? now_id { get; set; }

        /// <summary>
        /// 规则简写
        /// </summary>
        public System.String prefix_name { get; set; }

        /// <summary>
        /// 规则格式
        /// </summary>
        public System.String custo_format { get; set; }

        /// <summary>
        /// 编号前缀
        /// </summary>
        public System.String number_format { get; set; }

        /// <summary>
        /// 规则分割符
        /// </summary>
        public System.String separating_char { get; set; }

        /// <summary>
        /// 资料新增人
        /// </summary>
        public System.String datains_usrid { get; set; }

        /// <summary>
        /// 资料新增时间
        /// </summary>
        public System.DateTime? datains_time { get; set; }

        /// <summary>
        /// 资料更新人
        /// </summary>
        public System.String datachg_usrid { get; set; }

        /// <summary>
        /// 资料更新时间
        /// </summary>
        public System.DateTime? datachg_time { get; set; }
    }
}
