using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 输入DTO
    /// </summary>
    public class IBaseDto
    {
        /// <summary>
        /// 当前登录人员
        /// </summary>
        public string NowLoginUsr { get; set; }
    }
}
