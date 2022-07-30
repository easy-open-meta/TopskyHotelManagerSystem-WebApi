using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 输入DTO(列表)
    /// </summary>
    public class IListDto:IBaseDto
    {
        /// <summary>
        /// 页数
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int PageSize { get; set; }
    }
}
