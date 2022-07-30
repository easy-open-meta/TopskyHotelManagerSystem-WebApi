using HotelManagerSystemWebApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 获取所有水电费信息
    /// 输出DTO
    /// </summary>
    public class OSelectHydropowerInfoAllDto : MsgDto
    {
        /// <summary>
        /// 数据源
        /// </summary>
        public List<Temp_Hydropower> listSource { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int total { get; set; }
    }
}
