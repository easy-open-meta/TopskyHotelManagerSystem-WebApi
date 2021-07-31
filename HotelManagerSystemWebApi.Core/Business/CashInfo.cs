using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 酒店资产表
    /// </summary>
    [Table("cashinfo")]
    public class CashInfo : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public CashInfo()
        {
        }

        /// <summary>
        /// 资产编号
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.String CashNo { get; set; }

        /// <summary>
        /// 资产名称
        /// </summary>
        public System.String CashName { get; set; }

        /// <summary>
        /// 资产总值
        /// </summary>
        public System.Decimal CashPrice { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        public System.String CashClub { get; set; }

        /// <summary>
        /// 入库时间
        /// </summary>
        public System.DateTime CashTime { get; set; }

        /// <summary>
        /// 资产来源
        /// </summary>
        public System.String CashSource { get; set; }

        /// <summary>
        /// 资产经办人
        /// </summary>
        public System.String CashPerson { get; set; }

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
