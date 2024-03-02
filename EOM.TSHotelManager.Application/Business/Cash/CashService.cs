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
using System;
using System.Collections.Generic;
using System.Linq;
using EOM.TSHotelManager.Common.Core;
using EOM.TSHotelManager.EntityFramework;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 资产信息接口实现类
    /// </summary>
    public class CashService:ICashService
    {
        /// <summary>
        /// 资产信息
        /// </summary>
        private readonly PgRepository<Cash> cashRepository;

        /// <summary>
        /// 部门
        /// </summary>
        private readonly PgRepository<Dept> deptRepository;

        /// <summary>
        /// 员工
        /// </summary>
        private readonly PgRepository<Worker> workerRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cashRepository"></param>
        /// <param name="deptRepository"></param>
        /// <param name="workerRepository"></param>
        public CashService(PgRepository<Cash> cashRepository, PgRepository<Dept> deptRepository, PgRepository<Worker> workerRepository)
        {
            this.cashRepository = cashRepository;
            this.deptRepository = deptRepository;
            this.workerRepository = workerRepository;
        }

        /// <summary>
        /// 添加资产信息
        /// </summary>
        /// <param name="cash"></param>
        /// <returns></returns>
        public bool AddCashInfo(Cash cash)
        {
            return cashRepository.Insert(cash);
        }

        /// <summary>
        /// 查询资产信息
        /// </summary>
        /// <returns></returns>
        public List<Cash> SelectCashInfoAll()
        {
            //查询所有部门信息
            List<Dept> depts = new List<Dept>();
            depts = deptRepository.GetList(a => a.delete_mk != 1);
            //查询所有员工信息
            List<Worker> workers = new List<Worker>();
            workers = workerRepository.GetList(a => a.delete_mk != 1);
            List<Cash> cs = new List<Cash>();
            cs = cashRepository.GetList(a => a.delete_mk != 1);
            cs.ForEach(source =>
            {
                var dept = depts.FirstOrDefault(a => a.dept_no.Equals(source.CashClub));
                source.DeptName = dept == null?  "" : dept.dept_name;
                var worker = workers.FirstOrDefault(a => a.WorkerId.Equals(source.CashPerson));
                source.PersonName = worker == null ? "" : worker.WorkerName;

                source.CashPriceStr = source.CashPrice == 0 ? "" : Decimal.Parse(source.CashPrice.ToString()).ToString("#,##0.00").ToString();

            });
            return cs;
        }
    }
}
