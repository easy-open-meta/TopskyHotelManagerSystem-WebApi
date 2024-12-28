using EOM.TSHotelManager.Common.Core;
using EOM.TSHotelManager.EntityFramework;
using jvncorelib.EntityLib;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 员工照片接口实现类
    /// </summary>
    public class WorkerPicService : IWorkerPicService
    {
        /// <summary>
        /// 员工照片
        /// </summary>
        private readonly GenericRepository<WorkerPic> workerPicRepository;

        /// <summary>
        /// 加密
        /// </summary>
        private readonly jvncorelib.EncryptorLib.EncryptLib encrypt;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workerPicRepository"></param>
        /// <param name="encrypt"></param>
        public WorkerPicService(GenericRepository<WorkerPic> workerPicRepository, jvncorelib.EncryptorLib.EncryptLib encrypt)
        {
            this.workerPicRepository = workerPicRepository;
            this.encrypt = encrypt;
        }

        /// <summary>
        /// 查询员工照片
        /// </summary>
        /// <param name="workerPic"></param>
        /// <returns></returns>
        public WorkerPic WorkerPic(WorkerPic workerPic)
        {
            var workerPicSource = new WorkerPic();

            workerPicSource = workerPicRepository.GetSingle(a => a.WorkerId.Equals(workerPic.WorkerId));

            if (workerPicSource.IsNullOrEmpty())
            {
                return new WorkerPic { Id = 0, Pic = "", WorkerId = workerPic.WorkerId };
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
            return workerPicRepository.Insert(new WorkerPic
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
            return workerPicRepository.Delete(a => a.WorkerId.Equals(workerPic.WorkerId));
        }

        /// <summary>
        /// 更新员工照片
        /// </summary>
        /// <param name="workerPic"></param>
        /// <returns></returns>
        public bool UpdateWorkerPic(WorkerPic workerPic)
        {
            return workerPicRepository.Update(a => new WorkerPic
            {
                Pic = workerPic.Pic
            }, a => a.WorkerId.Equals(workerPic.WorkerId));
        }
    }
}
