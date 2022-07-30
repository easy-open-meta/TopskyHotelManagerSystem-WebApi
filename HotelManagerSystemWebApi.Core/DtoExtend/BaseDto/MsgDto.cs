using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 输出DTO
    /// </summary>
    public abstract class MsgDto:IBaseDto
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public StatusCode Status { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
