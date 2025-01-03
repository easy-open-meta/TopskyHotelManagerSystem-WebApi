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
using jvncorelib.EntityLib;
using SqlSugar;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 商品信息接口实现类
    /// </summary>
    public class SellService : ISellService
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        private readonly GenericRepository<SellThing> sellThingRepository;

        /// <summary>
        /// 消费情况
        /// </summary>
        private readonly GenericRepository<Spend> spendRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sellThingRepository"></param>
        /// <param name="spendRepository"></param>
        public SellService(GenericRepository<SellThing> sellThingRepository, GenericRepository<Spend> spendRepository)
        {
            this.sellThingRepository = sellThingRepository;
            this.spendRepository = spendRepository;
        }

        /// <summary>
        /// 查询所有商品
        /// </summary>
        /// <returns></returns>
        public List<SellThing> SelectSellThingAll(SellThing sellThing = null)
        {
            List<SellThing> sellThings = new List<SellThing>();
            var exp = Expressionable.Create<SellThing>().And(a => a.delete_mk == 0);
            if (sellThing.IsNullOrEmpty())
            {
                sellThings = sellThingRepository.GetList(exp.ToExpression());
                sellThings.ForEach(_sellThing =>
                {
                    _sellThing.SellPriceStr = Decimal.Parse(_sellThing.SellPrice.ToString()).ToString("#,##0.00").ToString();
                });
            }
            else
            {
                //商品编号
                if (!sellThing.SellNo.IsNullOrEmpty())
                {
                    exp = exp.And(a => a.SellNo.Contains(sellThing.SellNo));
                }
                //商品名称
                if (!sellThing.SellName.IsNullOrEmpty())
                {
                    exp = exp.Or(a => a.SellName.Contains(sellThing.SellName));
                }
                sellThings = sellThingRepository.GetList(exp.ToExpression());
                sellThings.ForEach(_sellThing =>
                {
                    _sellThing.SellPriceStr = Decimal.Parse(_sellThing.SellPrice.ToString()).ToString("#,##0.00").ToString();
                });
            }
            return sellThings;
        }

        /// <summary>
        /// 更新商品数量
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="sellNo"></param>
        /// <returns></returns>
        public bool UpdateSellThing(string stock, string sellNo)
        {
            return sellThingRepository.Update(a => new SellThing()
            {
                Stock = Convert.ToInt32(stock),
            }, a => a.SellNo == sellNo);
        }

        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="sellThing"></param>
        /// <returns></returns>
        public bool UpdateSellthingInfo(SellThing sellThing)
        {
            return sellThingRepository.Update(a => new SellThing()
            {
                SellName = sellThing.SellName,
                SellPrice = sellThing.SellPrice,
                Stock = sellThing.Stock,
                format = sellThing.format,
            }, a => a.SellNo == sellThing.SellNo);
        }

        /// <summary>
        /// 撤回客户消费信息
        /// </summary>
        /// <param name="roomNo"></param>
        /// <param name="custoNo"></param>
        /// <param name="sellName"></param>
        /// <returns></returns>
        public bool DeleteSellThing(string roomNo, string custoNo, string sellName)
        {
            return spendRepository.Update(a => new Spend()
            {
                delete_mk = 1,
            }, a => a.MoneyState.Equals(SpendConsts.UnSettle) && a.RoomNo == roomNo && a.CustoNo == custoNo
            && a.SpendName == sellName);

        }

        /// <summary>
        /// 根据商品编号删除商品信息
        /// </summary>
        /// <param name="sellNo"></param>
        /// <returns></returns>
        public bool DeleteSellThingBySellNo(string sellNo)
        {
            return sellThingRepository.Update(a => new SellThing()
            {
                delete_mk = 1
            }, a => a.SellNo == sellNo);
        }

        /// <summary>
        /// 根据商品名称和价格查询商品编号
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public SellThing SelectSellThingByNameAndPrice(string name, string price)
        {
            SellThing sellThing = null;
            sellThing = sellThingRepository.GetSingle(a => a.SellName == name && a.SellPrice == Convert.ToDecimal(price));
            return sellThing;
        }


        /// <summary>
        /// 根据商品编号查询商品信息
        /// </summary>
        /// <param name="SellNo"></param>
        /// <returns></returns>
        public SellThing SelectSellInfoBySellNo(string SellNo)
        {
            SellThing st = null;
            st = sellThingRepository.GetSingle(a => a.SellNo == SellNo && a.delete_mk != 1);
            return st;
        }

        #region 添加商品
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public bool InsertSellThing(SellThing st)
        {
            return sellThingRepository.Insert(st);
        }
        #endregion
    }
}
