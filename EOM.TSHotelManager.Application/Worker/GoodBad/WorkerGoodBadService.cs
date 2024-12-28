/*
 * MIT License
 *Copyright (c) 2021 易开元(Easy-Open-Meta)

 *Permission is hereby granted, free of charge, to any person obtaining a copy
 *of this software and associated documentation files (the "Software"), to deal
 *in the Software without restriction, including without limitation the rights
 *to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *copies of the Software, and to permit persons to whom the Software is
 *furnished to do so, subject to the following conditions:

 *The above copyright notice and this permission notice shall be included in all
 *copies or substantial portions of the Software.

 *THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *SOFTWARE.
 *
 */
using EOM.TSHotelManager.Common.Core;
using EOM.TSHotelManager.EntityFramework;
using jvncorelib.EntityLib;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 员工奖惩记录接口实现类
    /// </summary>
    public class WorkerGoodBadService : IWorkerGoodBadService
    {
        /// <summary>
        /// 员工奖惩记录
        /// </summary>
        private readonly GenericRepository<WorkerGoodBad> workerGoogBadRepository;

        /// <summary>
        /// 管理员记录
        /// </summary>
        private readonly GenericRepository<Admin> adminRepository;

        /// <summary>
        /// 奖惩类型
        /// </summary>
        private readonly GenericRepository<GBType> goodbadTypeRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workerGoogBadRepository"></param>
        /// <param name="adminRepository"></param>
        /// <param name="goodbadTypeRepository"></param>
        public WorkerGoodBadService(GenericRepository<WorkerGoodBad> workerGoogBadRepository, GenericRepository<Admin> adminRepository, GenericRepository<GBType> goodbadTypeRepository)
        {
            this.workerGoogBadRepository = workerGoogBadRepository;
            this.adminRepository = adminRepository;
            this.goodbadTypeRepository = goodbadTypeRepository;
        }

        /// <summary>
        /// 添加员工奖惩记录
        /// </summary>
        /// <param name="goodBad"></param>
        /// <returns></returns>
        public bool AddGoodBad(WorkerGoodBad goodBad)
        {
            return workerGoogBadRepository.Insert(goodBad);
        }

        /// <summary>
        /// 根据工号查找所有的奖惩记录信息
        /// </summary>
        /// <param name="wn"></param>
        /// <returns></returns>
        public List<WorkerGoodBad> SelectAllGoodBadByWorkNo(string wn)
        {
            //查询所有超级管理员
            List<Admin> admins = new List<Admin>();
            admins = adminRepository.GetList(a => a.DeleteMk != 1);
            List<GBType> gBTypes = new List<GBType>();
            gBTypes = goodbadTypeRepository.GetList(a => a.delete_mk != 1);
            List<WorkerGoodBad> gb = new List<WorkerGoodBad>();
            gb = workerGoogBadRepository.GetList(a => a.WorkNo == wn);
            gb.ForEach(source =>
            {
                //奖惩类型
                var gbType = gBTypes.FirstOrDefault(a => a.GBTypeId == source.GBType);
                source.TypeName = gbType.GBName.IsNullOrEmpty() ? "" : gbType.GBName;

                //操作人
                var admin = admins.FirstOrDefault(a => a.AdminAccount == source.GBOperation);
                source.OperationName = admin.AdminName.IsNullOrEmpty() ? "" : admin.AdminName;
            });
            return gb;
        }
    }
}
