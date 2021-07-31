using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 员工履历表
    /// </summary>
    [Table("workerhistory")]
    public class WorkerHistory : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public WorkerHistory()
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
        public System.String WorkerId { get; set; }

        /// <summary>
        /// 参加工作时间
        /// </summary>
        public System.DateTime StartDate { get; set; }

        /// <summary>
        /// 结束工作时间
        /// </summary>
        public System.DateTime EndDate { get; set; }

        /// <summary>
        /// 所任职位
        /// </summary>
        public System.String Position { get; set; }

        /// <summary>
        /// 所属公司
        /// </summary>
        public System.String Company { get; set; }

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
