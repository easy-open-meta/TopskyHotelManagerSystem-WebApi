using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 水电信息控制器
    /// </summary>
    public class WtiController : ControllerBase
    {
        /// <summary>
        /// 水电信息
        /// </summary>
        private readonly IWtiService wtiService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wtiService"></param>
        public WtiController(IWtiService wtiService)
        {
            this.wtiService = wtiService;
        }

        /// <summary>
        /// 根据房间编号查询水电费信息
        /// </summary>
        /// <param name="roomNo"></param>
        /// <returns></returns>
        [HttpGet]
        public Wti SelectWtiInfoByRoomNo([FromQuery]string roomNo)
        {
            return this.wtiService.SelectWtiInfoByRoomNo(roomNo);
        }

        /// <summary>
        /// 根据房间编号、使用时间查询水电费信息
        /// </summary>
        /// <param name="roomno"></param>
        /// <param name="usedate"></param>
        /// <param name="enddate"></param>
        /// <returns></returns>
        [HttpGet]
        public Wti SelectWtiInfoByRoomNoAndTime([FromQuery]string roomno, string usedate, string enddate)
        {
            return this.wtiService.SelectWtiInfoByRoomNoAndTime(roomno, usedate, enddate);
        }

        /// <summary>
        /// 获取所有水电费信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Wti> SelectWtiInfoAll()
        {
            return this.wtiService.SelectWtiInfoAll();
        }

        /// <summary>
        /// 添加水电费信息
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        [HttpPost]
        public bool InsertWtiInfo([FromBody]Wti w)
        {
            return this.wtiService.InsertWtiInfo(w);
        }

        /// <summary>
        /// 修改水电费信息(根据房间编号)
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateWtiInfo([FromBody]Wti w)
        {
            return this.wtiService.UpdateWtiInfo(w);
        }

        /// <summary>
        /// 根据房间信息、使用时间修改水电费
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateWtiInfoByRoomNoAndDateTime([FromBody]Wti w)
        {
            return this.wtiService.UpdateWtiInfoByRoomNoAndDateTime(w);
        }

        /// <summary>
        /// 删除水电费信息:根据房间编号
        /// </summary>
        /// <param name="roomno"></param>
        /// <returns></returns>
        //bool DeleteWtiInfo(string roomno);

        /// <summary>
        /// 根据房间编号、使用时间删除水电费信息
        /// </summary>
        /// <param name="roomno"></param>
        /// <param name="usedate"></param>
        /// <param name="enddate"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DeleteWtiInfoByRoomNoAndDateTime([FromBody]string roomno, string usedate, string enddate)
        {
            return this.wtiService.DeleteWtiInfoByRoomNoAndDateTime(roomno, usedate, enddate);
        }

        /// <summary>
        /// 获取所有水电费信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Wti> ListWtiInfoByRoomNo([FromQuery]string roomno)
        {
            return this.wtiService.ListWtiInfoByRoomNo(roomno);
        }

    }
}
