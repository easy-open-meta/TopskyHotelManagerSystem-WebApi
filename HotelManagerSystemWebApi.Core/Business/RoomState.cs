using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 房间状态表
    /// </summary>
    [Table("roomstate")]
    public class RoomState : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public RoomState()
        {
        }

        /// <summary>
        /// 房间状态ID
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.Int32 RoomStateId { get; set; }

        /// <summary>
        /// 状态名称
        /// </summary>
        [Column("RoomState")]
        public System.String RoomStateNm { get; set; }

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
