using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 操作日志表
    /// </summary>
    [Table("operationlog")]
    public class OperationLog : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public OperationLog()
        {
        }

        /// <summary>
        /// 记录ID
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.Int32 OperationId { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        public System.DateTime OperationTime { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        [Column("OperationLog")]
        public System.String OperationLogContent { get; set; }

        /// <summary>
        /// 被记录账户
        /// </summary>
        public System.String OperationAccount { get; set; }

        /// <summary>
        /// 日志等级
        /// </summary>
        public System.Int32? OperationLevel { get; set; }

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
