using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 商品消费控制器
    /// </summary>
    public class SellthingController : ControllerBase
    {
        /// <summary>
        /// 商品消费
        /// </summary>
        private readonly ISellService sellService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sellService"></param>
        public SellthingController(ISellService sellService)
        {
            this.sellService = sellService;
        }

        /// <summary>
        /// 查询所有商品
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<SellThing> SelectSellThingAll([FromQuery]SellThing sellThing = null)
        {
            return sellService.SelectSellThingAll(sellThing);
        }

        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="sellNo"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateSellThing([FromBody]string stock, string sellNo)
        {
            return sellService.UpdateSellThing(stock, sellNo);
        }

        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="sellThing"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateSellthingInfo([FromBody] SellThing sellThing)
        {
            return sellService.UpdateSellthingInfo(sellThing);
        }

        /// <summary>
        /// 撤回客户消费信息
        /// </summary>
        /// <param name="roomNo"></param>
        /// <param name="custoNo"></param>
        /// <param name="sellName"></param>
        /// <returns></returns>
        [HttpGet]
        public bool DeleteSellThing([FromQuery] string roomNo, string custoNo, string sellName)
        {
            return sellService.DeleteSellThing(roomNo, custoNo, sellName);
        }

        /// <summary>
        /// 根据商品编号删除商品信息
        /// </summary>
        /// <param name="sellNo"></param>
        /// <returns></returns>
        [HttpGet]
        public bool DeleteSellThingBySellNo([FromQuery]string sellNo)
        {
            return sellService.DeleteSellThingBySellNo(sellNo);
        }

        /// <summary>
        /// 根据商品名称和价格查询商品编号
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        [HttpGet]
        public SellThing SelectSellThingByNameAndPrice([FromQuery]string name, string price)
        {
            return sellService.SelectSellThingByNameAndPrice(name, price);
        }


        /// <summary>
        /// 根据商品编号查询商品信息
        /// </summary>
        /// <param name="SellNo"></param>
        /// <returns></returns>
        [HttpGet]
        public SellThing SelectSellInfoBySellNo([FromQuery]string SellNo)
        {
            return sellService.SelectSellInfoBySellNo(SellNo);
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        [HttpPost]
        public bool InsertSellThing([FromBody]SellThing st)
        {
            return sellService.InsertSellThing(st);
        }
    }
}
