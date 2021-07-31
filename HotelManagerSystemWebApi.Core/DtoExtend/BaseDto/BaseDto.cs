using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// DTO基础类
    /// </summary>
    public class BaseDto
    {
        /// <summary>
        /// 当前登录人员
        /// </summary>
        public string NowLoginUsr { get; set; }
    }
}
