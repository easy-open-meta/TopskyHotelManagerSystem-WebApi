using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 客户消费信息
    /// </summary>
    [Table("custospend")]
    public class CustoSpend : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public CustoSpend()
        {
        }

        /// <summary>
        /// 记录编号
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.Int32 SpendId { get; set; }

        /// <summary>
        /// 房间编号
        /// </summary>
        public System.String RoomNo { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public System.String CustoNo { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public System.String SpendName { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public System.Int32 SpendAmount { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public System.Decimal SpendPrice { get; set; }

        /// <summary>
        /// 消费总额
        /// </summary>
        public System.Decimal SpendMoney { get; set; }

        /// <summary>
        /// 消费时间
        /// </summary>
        public System.DateTime SpendTime { get; set; }

        /// <summary>
        /// 结算状态
        /// </summary>
        public System.String MoneyState { get; set; }

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
