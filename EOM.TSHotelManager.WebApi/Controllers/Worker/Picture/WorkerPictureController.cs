using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 照片控制器
    /// </summary>
    public class WorkerPictureController : ControllerBase
    {
        /// <summary>
        /// 照片
        /// </summary>
        private readonly IWorkerPicService workerPicService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workerPicService"></param>
        public WorkerPictureController(IWorkerPicService workerPicService)
        {
            this.workerPicService = workerPicService;
        }

        /// <summary>
        /// 查询员工照片
        /// </summary>
        /// <param name="workerPic"></param>
        /// <returns></returns>
        [HttpGet]
        public WorkerPic WorkerPic([FromQuery]WorkerPic workerPic)
        {
            return workerPicService.WorkerPic(workerPic);
        }

        /// <summary>
        /// 添加员工照片
        /// </summary>
        /// <param name="workerPic"></param>
        /// <returns></returns>
        [HttpPost]
        public bool InsertWorkerPic([FromBody]WorkerPic workerPic)
        {
            return workerPicService.InsertWorkerPic(workerPic);
        }

        /// <summary>
        /// 删除员工照片
        /// </summary>
        /// <param name="workerPic"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DeleteWorkerPic([FromBody]WorkerPic workerPic)
        {
            return workerPicService.DeleteWorkerPic(workerPic);
        }

        /// <summary>
        /// 更新员工照片
        /// </summary>
        /// <param name="workerPic"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateWorkerPic([FromBody]WorkerPic workerPic)
        {
            return workerPicService.UpdateWorkerPic(workerPic); 
        }

    }

}
