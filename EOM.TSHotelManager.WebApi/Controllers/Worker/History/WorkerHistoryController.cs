using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 员工履历控制器
    /// </summary>
    public class WorkerHistoryController : ControllerBase
    {
        /// <summary>
        /// 员工履历
        /// </summary>
        private readonly IWorkerHistoryService workerHistoryService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workerHistoryService"></param>
        public WorkerHistoryController(IWorkerHistoryService workerHistoryService)
        {
            this.workerHistoryService = workerHistoryService;
        }

        /// <summary>
        /// 根据工号添加员工履历
        /// </summary>
        /// <param name="workerHistory"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddHistoryByWorkerId([FromBody] WorkerHistory workerHistory)
        {
            return workerHistoryService.AddHistoryByWorkerId(workerHistory);
        }

        /// <summary>
        /// 根据工号查询履历信息
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        [HttpGet]
        public List<WorkerHistory> SelectHistoryByWorkerId([FromQuery] string wid)
        {
            return workerHistoryService.SelectHistoryByWorkerId(wid);
        }
    }
}
