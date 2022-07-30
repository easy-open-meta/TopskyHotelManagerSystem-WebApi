using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 员工照片
    /// </summary>
    public class Temp_WorkerPic
    {
        /// <summary>
        /// 自增长流水号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public string WorkerId { get; set; }

        /// <summary>
        /// 照片路径
        /// </summary>
        public string Pic { get; set; }
    }
}
