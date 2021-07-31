using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 商品信息表
    /// </summary>
    [Table("sellthing")]
    public class SellThing : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public SellThing()
        {
        }

        /// <summary>
        /// 商品编号
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.String SellNo { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public System.String SellName { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public System.Decimal SellPrice { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        public System.String format { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public System.Int32 Stock { get; set; }

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
