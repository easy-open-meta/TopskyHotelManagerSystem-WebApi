using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 水电信息表
    /// </summary>
    [Table("wtinfo")]
    public class Wtinfo : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Wtinfo()
        {
        }

        /// <summary>
        /// 记录编号
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.Int32 WtiNo { get; set; }

        /// <summary>
        /// 房间编号
        /// </summary>
        public System.String RoomNo { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public System.DateTime UseDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public System.DateTime? EndDate { get; set; }

        /// <summary>
        /// 用水情况
        /// </summary>
        public System.Decimal WaterUse { get; set; }

        /// <summary>
        /// 用电情况
        /// </summary>
        public System.Decimal PowerUse { get; set; }

        /// <summary>
        /// 记录人
        /// </summary>
        public System.String Record { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public System.String CustoNo { get; set; }

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
