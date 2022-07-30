using Furion.DynamicApiController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 跑马灯宣传
    /// </summary>
    public class FontsAppService:IDynamicApiController
    {
        /// <summary>
        /// 跑马灯宣传
        /// </summary>
        private readonly IFontsService _fontsService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fontsService"></param>
        public FontsAppService(IFontsService fontsService)
        {
            _fontsService = fontsService;
        }

        /// <summary>
        /// 查询所有宣传联动内容(跑马灯)
        /// </summary>
        /// <returns></returns>
        public OSelectFonListDto SelectFonList()
        {
            return _fontsService.SelectFonList();
        }
    }
}
