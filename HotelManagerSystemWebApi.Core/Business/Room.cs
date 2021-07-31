using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 房间信息表
    /// </summary>
    [Table("room")]
    public class Room : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Room()
        {
        }

        /// <summary>
        /// 房间编号
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.String RoomNo { get; set; }

        /// <summary>
        /// 房间类型
        /// </summary>
        public System.Int32 RoomType { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public System.String CustoNo { get; set; }

        /// <summary>
        /// 入住时间
        /// </summary>
        public System.DateTime? CheckTime { get; set; }

        /// <summary>
        /// 退房时间
        /// </summary>
        public System.DateTime? CheckOutTime { get; set; }

        /// <summary>
        /// 房间状态
        /// </summary>
        public System.Int32 RoomStateId { get; set; }

        /// <summary>
        /// 房间单价
        /// </summary>
        public System.Decimal? RoomMoney { get; set; }

        /// <summary>
        /// 房间位置
        /// </summary>
        public System.String RoomPosition { get; set; }

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
