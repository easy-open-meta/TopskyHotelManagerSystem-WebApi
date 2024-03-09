using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 员工打卡控制器
    /// </summary>
    public class WorkerCheckController : ControllerBase
    {
        /// <summary>
        /// 员工打卡
        /// </summary>
        private readonly IWorkerCheckService workerCheckService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workerCheckService"></param>
        public WorkerCheckController(IWorkerCheckService workerCheckService)
        {
            this.workerCheckService = workerCheckService;
        }

        /// <summary>
        /// 根据员工编号查询其所有的打卡记录
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        [HttpGet]
        public List<WorkerCheck> SelectCheckInfoByWorkerNo([FromQuery] string wid)
        {
            return workerCheckService.SelectCheckInfoByWorkerNo(wid);
        }

        /// <summary>
        /// 查询员工签到天数
        /// </summary>
        /// <param name="wkn"></param>
        /// <returns></returns>
        [HttpGet]
        public object SelectWorkerCheckDaySumByWorkerNo([FromQuery] string wkn)
        {
            return workerCheckService.SelectWorkerCheckDaySumByWorkerNo(wkn);
        }

        /// <summary>
        /// 查询今天员工是否已签到
        /// </summary>
        /// <param name="wkn"></param>
        /// <returns></returns>
        [HttpGet]
        public object SelectToDayCheckInfoByWorkerNo([FromQuery] string wkn)
        {
            return workerCheckService.SelectToDayCheckInfoByWorkerNo(wkn);
        }

        /// <summary>
        /// 添加员工打卡数据
        /// </summary>
        /// <param name="workerCheck"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddCheckInfo([FromBody] WorkerCheck workerCheck)
        {
            return workerCheckService.AddCheckInfo(workerCheck);
        }
    }
}
