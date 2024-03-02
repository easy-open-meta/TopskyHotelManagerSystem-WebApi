using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 员工信息控制器
    /// </summary>
    public class WorkerController : ControllerBase
    {
        /// <summary>
        /// 员工信息
        /// </summary>
        private readonly IWorkerService workerService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workerService"></param>
        public WorkerController(IWorkerService workerService)
        {
            this.workerService = workerService;
        }

        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateWorker([FromBody]Worker worker)
        {
            return workerService.UpdateWorker(worker);
        }

        /// <summary>
        /// 员工账号禁/启用
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        [HttpPost]
        public bool ManagerWorkerAccount([FromBody]Worker worker)
        {
            return workerService.ManagerWorkerAccount(worker);
        }

        /// <summary>
        /// 更新员工职位和部门
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        [HttpPost]

        public bool UpdateWorkerPositionAndClub([FromBody]Worker worker)
        {
            return workerService.UpdateWorkerPositionAndClub(worker);
        }

        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddWorker([FromBody]Worker worker)
        {
            return workerService.AddWorker(worker);
        }

        /// <summary>
        /// 获取所有工作人员信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Worker> SelectWorkerAll()
        {
            return workerService.SelectWorkerAll();
        }

        /// <summary>
        /// 检查指定部门下是否存在工作人员
        /// </summary>
        /// <param name="deptNo"></param>
        /// <returns></returns>
        [HttpGet]
        public bool CheckWorkerBydepartment(string deptNo)
        {
            return workerService.CheckWorkerBydepartment(deptNo);
        }

        /// <summary>
        /// 根据登录名称查询员工信息
        /// </summary>
        /// <param name="workerId"></param>
        /// <returns></returns>
        [HttpGet]
        public Worker SelectWorkerInfoByWorkerId([FromQuery]string workerId)
        {
            return workerService.SelectWorkerInfoByWorkerId(workerId);
        }

        /// <summary>
        /// 根据登录名称、密码查询员工信息
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        [HttpPost]
        public Worker SelectWorkerInfoByWorkerIdAndWorkerPwd([FromBody]Worker worker)
        {
            return workerService.SelectWorkerInfoByWorkerIdAndWorkerPwd(worker);
        }

        /// <summary>
        /// 根据员工编号和密码修改密码
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdWorkerPwdByWorkNo([FromBody]Worker worker)
        {
            return workerService.UpdWorkerPwdByWorkNo(worker);
        }
    }
}
