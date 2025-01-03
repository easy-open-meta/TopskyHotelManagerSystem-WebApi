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

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 监管统计接口实现类
    /// </summary>
    public class CheckInfoService : ICheckInfoService
    {
        /// <summary>
        /// 监管统计
        /// </summary>
        private readonly GenericRepository<CheckInfo> checkInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="checkInfoRepository"></param>
        public CheckInfoService(GenericRepository<CheckInfo> checkInfoRepository)
        {
            this.checkInfoRepository = checkInfoRepository;
        }

        /// <summary>
        /// 查询所有监管统计信息
        /// </summary>
        /// <returns></returns>
        public List<CheckInfo> SelectCheckInfoAll()
        {
            List<CheckInfo> cif = new List<CheckInfo>();
            cif = checkInfoRepository.GetList(a => a.delete_mk != 1);
            return cif;
        }
    }
}
