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

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 员工打卡接口实现类
    /// </summary>
    public class WorkerCheckService : IWorkerCheckService
    {
        /// <summary>
        /// 员工打卡
        /// </summary>
        private readonly GenericRepository<WorkerCheck> workerCheckRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workerCheckRepository"></param>
        public WorkerCheckService(GenericRepository<WorkerCheck> workerCheckRepository)
        {
            this.workerCheckRepository = workerCheckRepository;
        }

        /// <summary>
        /// 根据员工编号查询其所有的打卡记录
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public List<WorkerCheck> SelectCheckInfoByWorkerNo(string wid)
        {
            List<WorkerCheck> workerChecks = new List<WorkerCheck>();
            workerChecks = workerCheckRepository.GetList(a => a.WorkerNo == wid && a.delete_mk != 1);
            workerChecks.ForEach(source =>
            {
                source.CheckStateNm = source.CheckState == 0 ? "打卡成功" : "打卡失败";
            });
            return workerChecks;
        }


        /// <summary>
        /// 查询员工签到天数
        /// </summary>
        /// <param name="wkn"></param>
        /// <returns></returns>
        public object SelectWorkerCheckDaySumByWorkerNo(string wkn)
        {
            return workerCheckRepository.GetList(a => a.WorkerNo == wkn && a.delete_mk != 1).Count;
        }


        /// <summary>
        /// 查询今天员工是否已签到
        /// </summary>
        /// <param name="wkn"></param>
        /// <returns></returns>
        public object SelectToDayCheckInfoByWorkerNo(string wkn)
        {
            //string sql = "select Count(*) from WORKERCHECK where WorkerNo = '"+wkn+ "' and DATEDIFF(CURRENT_DATE(),workercheck.CheckTime)";
            var listCheckInfo = workerCheckRepository.GetList(a => a.WorkerNo == wkn && a.delete_mk != 1);
            var count = listCheckInfo.Where(a => a.CheckTime.ToShortDateString() == Convert.ToDateTime(DateTime.Now).ToShortDateString()).Count() > 0 ? 1 : 0;
            return count;
        }

        /// <summary>
        /// 添加员工打卡数据
        /// </summary>
        /// <param name="workerCheck"></param>
        /// <returns></returns>
        public bool AddCheckInfo(WorkerCheck workerCheck)
        {
            return workerCheckRepository.Insert(workerCheck);
        }
    }
}
