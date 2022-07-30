/*
 * MIT License
 *Copyright (c) 2021 咖啡与网络(java-and-net)

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
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.LinqBuilder;
using HotelManagerSystemWebApi.Core;
using jvncorelib.CodeLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 资产信息接口实现类
    /// </summary>
    public class CashService:ICashService, ITransient
    {
        /// <summary>
        /// 资产信息
        /// </summary>
        private readonly IRepository<Cash> cashRepository;

        /// <summary>
        /// 部门
        /// </summary>
        private readonly IRepository<Dept> deptRepository;

        /// <summary>
        /// 员工
        /// </summary>
        private readonly IRepository<Worker> workerRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cashRepository"></param>
        /// <param name="deptRepository"></param>
        /// <param name="workerRepository"></param>
        public CashService(IRepository<Cash> cashRepository, IRepository<Dept> deptRepository, IRepository<Worker> workerRepository)
        {
            this.cashRepository = cashRepository;
            this.deptRepository = deptRepository;
            this.workerRepository = workerRepository;
        }

        /// <summary>
        /// 添加资产信息
        /// </summary>
        /// <param name="addCashInfoDto"></param>
        /// <returns></returns>
        public OAddCashInfoDto AddCashInfo(AddCashInfoDto addCashInfoDto)
        {
            OAddCashInfoDto oAddCashInfoDto = new OAddCashInfoDto();

            var uncode = new UniqueCode();

            var source = new Cash();

            source = source.UpdateToModel(addCashInfoDto);
            source.CashNo = uncode.GetNewId("CN");
            source.datains_usr = addCashInfoDto.NowLoginUsr;
            source.datains_date = DateTime.Now;
            this.cashRepository.Insert(source);

            oAddCashInfoDto.OK();

            return oAddCashInfoDto;
        }

        /// <summary>
        /// 查询资产信息
        /// </summary>
        /// <returns></returns>
        public OCashInfoListDto SelectCashInfoAll(CashInfoListDto cashInfoListDto)
        {
            OCashInfoListDto oCashInfoListDto = new OCashInfoListDto();

            //查询所有部门信息
            var depts = deptRepository.AsQueryable(a => a.delete_mk != 1).ToList().CopyToModel<Dept, Temp_Dept>();
            //查询所有员工信息
            var workers = workerRepository.AsQueryable(a => a.delete_mk != 1).ToList().CopyToModel<Worker, Temp_WorkerInfo>();

            var where = LinqExpression.Create<Cash>(a => a.delete_mk != 1);

            //资产编号
            if (!cashInfoListDto.CashNo.IsNullOrEmpty())
            {
                where = where.And(a => a.CashNo.Contains(cashInfoListDto.CashNo));
            }
            //资产名称
            if (!cashInfoListDto.CashName.IsNullOrEmpty())
            {
                where = where.And(a => a.CashName.Contains(cashInfoListDto.CashName));
            }

            //查询资产信息
            var listSource = cashRepository.AsQueryable(where).ToList().CopyToModel<Cash, Temp_Cash>();

            listSource.ForEach(source =>
            {
                var dept = depts.FirstOrDefault(a => a.dept_no.Equals(source.CashClub));
                source.DeptName = dept == null ? "" : dept.dept_name;
                var worker = workers.FirstOrDefault(a => a.WorkerId.Equals(source.CashPerson));
                source.PersonName = worker == null ? "" : worker.WorkerName;

                source.CashPriceStr = source.CashPrice == 0 ? "" : Decimal.Parse(source.CashPrice.ToString()).ToString("#,##0.00").ToString();

            });

            oCashInfoListDto.listSource = listSource;
            oCashInfoListDto.total = listSource.Count;

            return oCashInfoListDto;
        }
    }
}
