using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 员工奖惩信息
    /// </summary>
    [Table("workergoodbad")]
    public class WorkerGoodBad : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public WorkerGoodBad()
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
        public System.String WorkNo { get; set; }

        /// <summary>
        /// 奖惩内容
        /// </summary>
        public System.String GBInfo { get; set; }

        /// <summary>
        /// 奖惩类型
        /// </summary>
        public System.Int32? GBType { get; set; }

        /// <summary>
        /// 奖惩记录人
        /// </summary>
        public System.String GBOperation { get; set; }

        /// <summary>
        /// 奖惩时间
        /// </summary>
        public System.DateTime? GBTime { get; set; }

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
