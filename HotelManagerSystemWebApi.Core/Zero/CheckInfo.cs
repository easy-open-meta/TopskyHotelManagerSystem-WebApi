using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 监管统计表
    /// </summary>
    [Table("checkinfo")]
    public class CheckInfo : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public CheckInfo()
        {
        }

        /// <summary>
        /// 监管统计编号
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.String CheckNo { get; set; }

        /// <summary>
        /// 受监管部门
        /// </summary>
        public System.String CheckClub { get; set; }

        /// <summary>
        /// 受监管部门总体概述
        /// </summary>
        public System.String CheckProgres { get; set; }

        /// <summary>
        /// 受监管部门交易情况
        /// </summary>
        public System.String CheckCash { get; set; }

        /// <summary>
        /// 受监管部门得分情况
        /// </summary>
        public System.Int32 CheckScore { get; set; }

        /// <summary>
        /// 本次监管负责人
        /// </summary>
        public System.String CheckPerson { get; set; }

        /// <summary>
        /// 监管建议
        /// </summary>
        public System.String CheckAdvice { get; set; }

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
