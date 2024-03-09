using EOM.TSHotelManager.Common.Core;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 员工照片模块接口
    /// </summary>
    public interface IWorkerPicService
    {
        /// <summary>
        /// 查询员工照片
        /// </summary>
        /// <param name="workerPic"></param>
        /// <returns></returns>
        WorkerPic WorkerPic(WorkerPic workerPic);
        /// <summary>
        /// 添加员工照片
        /// </summary>
        /// <param name="workerPic"></param>
        /// <returns></returns>
        bool InsertWorkerPic(WorkerPic workerPic);
        /// <summary>
        /// 删除员工照片
        /// </summary>
        /// <param name="workerPic"></param>
        /// <returns></returns>
        bool DeleteWorkerPic(WorkerPic workerPic);
        /// <summary>
        /// 更新员工照片
        /// </summary>
        /// <param name="workerPic"></param>
        /// <returns></returns>
        bool UpdateWorkerPic(WorkerPic workerPic);
    }
}
