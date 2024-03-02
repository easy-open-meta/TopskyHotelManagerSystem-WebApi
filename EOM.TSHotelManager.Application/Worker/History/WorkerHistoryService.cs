﻿/*
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
using System;
using System.Collections.Generic;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 员工履历接口实现类
    /// </summary>
    public class WorkerHistoryService : IWorkerHistoryService
    {
        /// <summary>
        /// 员工履历
        /// </summary>
        private readonly PgRepository<WorkerHistory> workerHistoryRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workerHistoryRepository"></param>
        public WorkerHistoryService(PgRepository<WorkerHistory> workerHistoryRepository)
        {
            this.workerHistoryRepository = workerHistoryRepository;
        }

        /// <summary>
        /// 根据工号添加员工履历
        /// </summary>
        /// <param name="workerHistory"></param>
        /// <returns></returns>
        public bool AddHistoryByWorkerId(WorkerHistory workerHistory)
        {
            return workerHistoryRepository.Insert(workerHistory);
        }

        /// <summary>
        /// 根据工号查询履历信息
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public List<WorkerHistory> SelectHistoryByWorkerId(string wid)
        {
            List<WorkerHistory> why = new List<WorkerHistory>();
            why = workerHistoryRepository.GetList(a => a.delete_mk != 1 && a.WorkerId == wid);
            return why;
        }
    }
}
