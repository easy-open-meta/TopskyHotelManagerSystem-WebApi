using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 消费信息控制器
    /// </summary>
    public class SpendController : ControllerBase
    {
        /// <summary>
        /// 消费信息
        /// </summary>
        private readonly ISpendService spendService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spendService"></param>
        public SpendController(ISpendService spendService)
        {
            this.spendService = spendService;
        }

        /// <summary>
        /// 添加消费信息
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [HttpPost]
        public bool InsertSpendInfo([FromBody] Spend s)
        {
            return spendService.InsertSpendInfo(s);
        }

        /// <summary>
        /// 根据客户编号查询消费信息
        /// </summary>
        /// <param name="No"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Spend> SelectSpendByCustoNo([FromQuery] string No)
        {
            return spendService.SelectSpendByCustoNo(No);
        }

        /// <summary>
        /// 根据房间编号查询消费信息
        /// </summary>
        /// <param name="No"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Spend> SelectSpendByRoomNo([FromQuery] string No)
        {
            return spendService.SelectSpendByRoomNo(No);
        }

        /// <summary>
        /// 根据客户编号查询历史消费信息
        /// </summary>
        /// <param name="custoNo"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Spend> SeletHistorySpendInfoAll([FromQuery] string custoNo)
        {
            return spendService.SeletHistorySpendInfoAll(custoNo);
        }

        /// <summary>
        /// 查询消费的所有信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Spend> SelectSpendInfoAll()
        {
            return spendService.SelectSpendInfoAll();
        }

        /// <summary>
        /// 根据房间号查询消费的所有信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Spend> SelectSpendInfoRoomNo([FromQuery] string RoomNo)
        {
            return spendService.SelectSpendInfoRoomNo(RoomNo);
        }

        /// <summary>
        /// 根据房间编号、入住时间到当前时间查询消费总金额
        /// </summary>
        /// <param name="roomno"></param>
        /// <param name="custono"></param>
        /// <returns></returns>
        [HttpGet]
        public object SelectMoneyByRoomNoAndTime([FromQuery] string roomno, string custono)
        {
            return spendService.SelectMoneyByRoomNoAndTime(roomno, custono);
        }

        /// <summary>
        /// 根据房间编号、入住时间和当前时间修改结算状态
        /// </summary>
        /// <param name="roomno"></param>
        /// <param name="checktime"></param>
        /// <returns></returns>
        [HttpGet]
        public bool UpdateMoneyState([FromQuery] string roomno, string checktime)
        {
            return spendService.UpdateMoneyState(roomno, checktime);
        }

        /// <summary>
        /// 将转房前的未结算记录一同转移到新房间
        /// </summary>
        /// <param name="spend"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateSpendInfoByRoomNo([FromQuery] Spend spend)
        {
            return spendService.UpdateSpendInfoByRoomNo(spend);
        }

        /// <summary>
        /// 更新消费信息
        /// </summary>
        /// <param name="spend"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdSpenInfo([FromBody] Spend spend)
        {
            return spendService.UpdSpenInfo(spend);
        }

    }
}
