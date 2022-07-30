using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 员工照片
    /// </summary>
    [Table("workerpic")]
    public class WorkerPic:EntityBase
    {
        /// <summary>
        /// 工号
        /// </summary>
        [Column("WorkerId")]
        public string WorkerId { get; set; }

        /// <summary>
        /// 照片路径
        /// </summary>
        [Column("Pic")]
        public string Pic { get; set; }
    }
}
