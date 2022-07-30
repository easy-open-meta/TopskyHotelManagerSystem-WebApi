﻿/*
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

using System.Collections.Generic;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 资产信息接口
    /// </summary>
    public interface ICashService
    {
        /// <summary>
        /// 添加资产信息
        /// </summary>
        /// <param name="addCashInfoDto"></param>
        /// <returns></returns>
        OAddCashInfoDto AddCashInfo(AddCashInfoDto addCashInfoDto);

        /// <summary>
        /// 查询资产信息
        /// </summary>
        /// <returns></returns>
        OCashInfoListDto SelectCashInfoAll(CashInfoListDto cashInfoListDto);
    }
}