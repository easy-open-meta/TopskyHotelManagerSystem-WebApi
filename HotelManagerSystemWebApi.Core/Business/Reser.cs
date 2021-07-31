using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 房间预约表
    /// </summary>
    [Table("reser")]
    public class Reser : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Reser()
        {
        }

        /// <summary>
        /// 预约ID
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.String ReserId { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        public System.String CustoName { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public System.String CustoTel { get; set; }

        /// <summary>
        /// 预约方式
        /// </summary>
        public System.String ReserWay { get; set; }

        /// <summary>
        /// 预约房间号码
        /// </summary>
        public System.String ReserRoom { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        public System.DateTime? ReserDate { get; set; }

        /// <summary>
        /// 截止时间
        /// </summary>
        public System.DateTime? ReserEndDay { get; set; }

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
