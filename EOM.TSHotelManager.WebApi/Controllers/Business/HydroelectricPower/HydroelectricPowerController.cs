using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 水电信息控制器
    /// </summary>
    public class HydroelectricPowerController : ControllerBase
    {
        /// <summary>
        /// 水电信息
        /// </summary>
        private readonly IHydroelectricPowerService hydroelectricPowerService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hydroelectricPowerService"></param>
        public HydroelectricPowerController(IHydroelectricPowerService hydroelectricPowerService)
        {
            this.hydroelectricPowerService = hydroelectricPowerService;
        }

        /// <summary>
        /// 根据房间编号查询水电费信息
        /// </summary>
        /// <param name="roomNo"></param>
        /// <returns></returns>
        [HttpGet]
        public HydroelectricPower SelectWtiInfoByRoomNo([FromQuery] string roomNo)
        {
            return this.hydroelectricPowerService.SelectWtiInfoByRoomNo(roomNo);
        }

        /// <summary>
        /// 根据房间编号、使用时间查询水电费信息
        /// </summary>
        /// <param name="roomno"></param>
        /// <param name="usedate"></param>
        /// <param name="enddate"></param>
        /// <returns></returns>
        [HttpGet]
        public HydroelectricPower SelectWtiInfoByRoomNoAndTime([FromQuery] string roomno, string usedate, string enddate)
        {
            return this.hydroelectricPowerService.SelectWtiInfoByRoomNoAndTime(roomno, usedate, enddate);
        }

        /// <summary>
        /// 获取所有水电费信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<HydroelectricPower> SelectWtiInfoAll()
        {
            return this.hydroelectricPowerService.SelectWtiInfoAll();
        }

        /// <summary>
        /// 添加水电费信息
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        [HttpPost]
        public bool InsertWtiInfo([FromBody] HydroelectricPower w)
        {
            return this.hydroelectricPowerService.InsertWtiInfo(w);
        }

        /// <summary>
        /// 修改水电费信息(根据房间编号)
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateWtiInfo([FromBody] HydroelectricPower w)
        {
            return this.hydroelectricPowerService.UpdateWtiInfo(w);
        }

        /// <summary>
        /// 根据房间信息、使用时间修改水电费
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateWtiInfoByRoomNoAndDateTime([FromBody] HydroelectricPower w)
        {
            return this.hydroelectricPowerService.UpdateWtiInfoByRoomNoAndDateTime(w);
        }

        /// <summary>
        /// 根据房间编号、使用时间删除水电费信息
        /// </summary>
        /// <param name="roomno"></param>
        /// <param name="usedate"></param>
        /// <param name="enddate"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DeleteWtiInfoByRoomNoAndDateTime([FromBody] string roomno, string usedate, string enddate)
        {
            return this.hydroelectricPowerService.DeleteWtiInfoByRoomNoAndDateTime(roomno, usedate, enddate);
        }

        /// <summary>
        /// 获取所有水电费信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<HydroelectricPower> ListWtiInfoByRoomNo([FromQuery] string roomno)
        {
            return this.hydroelectricPowerService.ListWtiInfoByRoomNo(roomno);
        }

    }
}
