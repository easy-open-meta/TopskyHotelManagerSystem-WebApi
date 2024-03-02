using CK.Common;
using EOM.Encrypt;
using EOM.TSHotelManager.Common.Core;
using EOM.TSHotelManager.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private readonly PgRepository<WorkerPic> workerPicRepository;

        /// <summary>
        /// 加密
        /// </summary>
        private readonly EOM.Encrypt.Encrypt encrypt;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workerPicRepository"></param>
        /// <param name="encrypt"></param>
        public WorkerPicService(PgRepository<WorkerPic> workerPicRepository, EOM.Encrypt.Encrypt encrypt)
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

            //workerPicSource.Pic = workerPicSource == null || string.IsNullOrEmpty(workerPicSource.Pic)  "" : workerPicSource.Pic;
            
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
