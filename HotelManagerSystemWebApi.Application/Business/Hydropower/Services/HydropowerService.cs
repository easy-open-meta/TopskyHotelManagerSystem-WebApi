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
using jvncorelib.EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 水电信息接口实现类
    /// </summary>
    public class HydropowerService:IHydropowerService, ITransient
    {
        /// <summary>
        /// 水电
        /// </summary>
        private readonly IRepository<Hydropower> hydropowerRepository;

        /// <summary>
        /// 客户信息
        /// </summary>
        private readonly IRepository<Custo> customerRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hydropowerRepository"></param>
        /// <param name="customerRepository"></param>
        public HydropowerService(IRepository<Hydropower> hydropowerRepository, IRepository<Custo> customerRepository)
        {
            this.hydropowerRepository = hydropowerRepository;
            this.customerRepository = customerRepository;
        }

        /// <summary>
        /// 获取所有水电费信息
        /// </summary>
        /// <returns></returns>
        public OSelectHydropowerInfoAllDto SelectHydropowerInfoAll(SelectHydropowerInfoAllDto selectHydropowerInfoAllDto)
        {
            OSelectHydropowerInfoAllDto oSelectHydropowerInfoAllDto = new OSelectHydropowerInfoAllDto();

            var where = LinqExpression.Create<Hydropower>(a => a.delete_mk != 1);

            //流水号
            if (!selectHydropowerInfoAllDto.WtiNo.IsNullOrEmpty())
            {
                where = where.And(a => a.WtiNo == selectHydropowerInfoAllDto.WtiNo);
            }
            //房间号码
            if (!selectHydropowerInfoAllDto.RoomNo.IsNullOrEmpty())
            {
                where = where.And(a => a.RoomNo == selectHydropowerInfoAllDto.RoomNo);
            }
            //开始时间、结束时间
            if (!selectHydropowerInfoAllDto.UseDate.IsNullOrEmpty() && !selectHydropowerInfoAllDto.EndDate.IsNullOrEmpty())
            {
                where = where.And(a => a.UseDate >= selectHydropowerInfoAllDto.UseDate && a.EndDate <= selectHydropowerInfoAllDto.EndDate);
            }
            //客户编号
            if (!selectHydropowerInfoAllDto.CustoNo.IsNullOrEmpty())
            {
                where = where.And(a => a.CustoNo.Equals(selectHydropowerInfoAllDto.CustoNo));
            }

            var count = 0;

            var listSource = hydropowerRepository.AsQueryable(where).ToList()
                .GetPageList(selectHydropowerInfoAllDto.PageIndex, selectHydropowerInfoAllDto.PageSize, ref count)
                .CopyToModel<Hydropower, Temp_Hydropower>();

            var listCustomerId = listSource.Select(a => a.CustoNo).Distinct().ToList();
            var listCustomer = this.customerRepository.AsQueryable(a => listCustomerId.Contains(a.CustoNo));

            listSource.ForEach(source =>
            {
                var customer = listCustomer.FirstOrDefault(a => a.CustoNo.Equals(source.CustoNo));
                source.CustoNm = customer.IsNullOrEmpty() ? "" : customer.CustoName;
            });

            oSelectHydropowerInfoAllDto.listSource = listSource;
            oSelectHydropowerInfoAllDto.total = count;
            oSelectHydropowerInfoAllDto.OK();

            return oSelectHydropowerInfoAllDto;
        }

        /// <summary>
        /// 添加水电费信息
        /// </summary>
        /// <param name="insertHydropowerInfoDto"></param>
        /// <returns></returns>
        public OInsertHydropowerInfoDto InsertHydropowerInfo(InsertHydropowerInfoDto insertHydropowerInfoDto)
        {
            OInsertHydropowerInfoDto oInsertHydropowerInfoDto = new OInsertHydropowerInfoDto();

            var source = new Hydropower();

            source = source.UpdateToModel(insertHydropowerInfoDto);
            source.datains_usr = insertHydropowerInfoDto.NowLoginUsr;
            source.datains_date = DateTime.Now;
            this.hydropowerRepository.Insert(source);
            oInsertHydropowerInfoDto.OK();

            return  oInsertHydropowerInfoDto;
        }

        /// <summary>
        /// 修改水电费信息
        /// </summary>
        /// <param name="updateHydropowerInfoDto"></param>
        /// <returns></returns>
        public OUpdateHydropowerInfoDto UpdateHydropowerInfo(UpdateHydropowerInfoDto updateHydropowerInfoDto)
        {
            OUpdateHydropowerInfoDto oUpdateHydropowerInfoDto = new OUpdateHydropowerInfoDto();

            var source = hydropowerRepository.SingleOrDefault(a => a.WtiNo == updateHydropowerInfoDto.WtiNo);

            if(source.IsNullOrEmpty())
            {
                oUpdateHydropowerInfoDto.Error_NotFound();
                return oUpdateHydropowerInfoDto;
            }

            source = source.UpdateToModel(updateHydropowerInfoDto);
            source.datains_usr = updateHydropowerInfoDto.NowLoginUsr;
            source.datains_date = DateTime.Now;
            this.hydropowerRepository.Update(source);
            oUpdateHydropowerInfoDto.OK();

            return oUpdateHydropowerInfoDto;
        }
    }
}
