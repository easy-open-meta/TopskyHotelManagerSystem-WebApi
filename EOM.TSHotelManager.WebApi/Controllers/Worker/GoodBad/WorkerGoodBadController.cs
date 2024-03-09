using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 奖惩信息控制器
    /// </summary>
    public class WorkerGoodBadController : ControllerBase
    {
        /// <summary>
        /// 奖惩信息
        /// </summary>
        private readonly IWorkerGoodBadService workerGoodBadService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workerGoodBadService"></param>
        public WorkerGoodBadController(IWorkerGoodBadService workerGoodBadService)
        {
            this.workerGoodBadService = workerGoodBadService;
        }

        /// <summary>
        /// 添加员工奖惩记录
        /// </summary>
        /// <param name="goodBad"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddGoodBad([FromBody] WorkerGoodBad goodBad)
        {
            return workerGoodBadService.AddGoodBad(goodBad);
        }

        /// <summary>
        /// 根据工号查找所有的奖惩记录信息
        /// </summary>
        /// <param name="wn"></param>
        /// <returns></returns>
        [HttpGet]
        public List<WorkerGoodBad> SelectAllGoodBadByWorkNo([FromQuery] string wn)
        {
            return workerGoodBadService.SelectAllGoodBadByWorkNo(wn);
        }
    }
}
