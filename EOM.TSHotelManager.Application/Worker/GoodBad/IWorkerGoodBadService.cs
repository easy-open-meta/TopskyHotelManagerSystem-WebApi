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

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 员工奖惩信息接口
    /// </summary>
    public interface IWorkerGoodBadService
    {
        /// <summary>
        /// 添加员工奖惩记录
        /// </summary>
        /// <param name="goodBad"></param>
        /// <returns></returns>
        bool AddGoodBad(WorkerGoodBad goodBad);

        /// <summary>
        /// 根据工号查找所有的奖惩记录信息
        /// </summary>
        /// <param name="wn"></param>
        /// <returns></returns>
        List<WorkerGoodBad> SelectAllGoodBadByWorkNo(string wn);
    }
}