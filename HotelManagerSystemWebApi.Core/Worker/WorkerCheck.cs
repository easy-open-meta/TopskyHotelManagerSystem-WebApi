using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 打卡记录表
    /// </summary>
    [Table("workercheck")]
    public class WorkerCheck : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public WorkerCheck()
        {
        }

        /// <summary>
        /// 索引ID
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.Int32 Id { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public System.String WorkerNo { get; set; }

        /// <summary>
        /// 打卡时间
        /// </summary>
        public System.DateTime? CheckTime { get; set; }

        /// <summary>
        /// 打卡方式
        /// </summary>
        public System.String CheckWay { get; set; }

        /// <summary>
        /// 打卡状态
        /// </summary>
        public System.Int32? CheckState { get; set; }

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
