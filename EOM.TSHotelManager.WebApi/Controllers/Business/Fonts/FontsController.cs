using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 酒店宣传联动内容控制器
    /// </summary>
    public class FontsController : ControllerBase
    {
        /// <summary>
        /// 酒店宣传联动内容
        /// </summary>
        private readonly IFontsService fontsService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fontsService"></param>
        public FontsController(IFontsService fontsService)
        {
            this.fontsService = fontsService;
        }

        /// <summary>
        /// 查询所有宣传联动内容(跑马灯)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Fonts> SelectFontAll()
        {
            return fontsService.SelectFontAll();
        }
    }
}
