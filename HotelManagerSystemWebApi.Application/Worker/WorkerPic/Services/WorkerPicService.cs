


namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 员工照片接口实现类
    /// </summary>
    public  class WorkerPicService:IWorkerPicService,ITransient
    {
        /// <summary>
        /// 查询员工照片
        /// </summary>
        /// <param name="workerPic"></param>
        /// <returns></returns>
        public WorkerPic WorkerPic(WorkerPic workerPic)
        {
            var workerPicSource = new WorkerPic();

            workerPicSource = base.GetSingle(a => a.WorkerId.Equals(workerPic.WorkerId));

            if (workerPicSource != null)
            {
                workerPicSource.Pic = workerPicSource == null || string.IsNullOrEmpty(workerPicSource.Pic) ? "" : HttpHelper.baseUrl + workerPicSource.Pic;
            }

            return workerPicSource;
        }
        /// <summary>
        /// 添加员工照片
        /// </summary>
        /// <param name="workerPic"></param>
        /// <returns></returns>
        public bool InsertWorkerPic(WorkerPic workerPic)
        {
            return base.Insert(new WorkerPic
            {
                WorkerId = workerPic.WorkerId,
                Pic = workerPic.Pic
            });
        }

        /// <summary>
        /// 删除员工照片
        /// </summary>
        /// <param name="workerPic"></param>
        /// <returns></returns>
        public bool DeleteWorkerPic(WorkerPic workerPic)
        {
            return base.Delete(a => a.WorkerId.Equals(workerPic.WorkerId));
        }

        /// <summary>
        /// 更新员工照片
        /// </summary>
        /// <param name="workerPic"></param>
        /// <returns></returns>
        public bool UpdateWorkerPic(WorkerPic workerPic)
        {
            return base.Update(a=> new WorkerPic
            {
                Pic = workerPic.Pic
            },a => a.WorkerId.Equals(workerPic.WorkerId));
        }
    }
}
