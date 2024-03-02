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
    /// 商品消费接口实现类
    /// </summary>
    public class SpendService:ISpendService
    {
        /// <summary>
        /// 商品消费
        /// </summary>
        private readonly PgRepository<Spend> spendRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spendRepository"></param>
        public SpendService(PgRepository<Spend> spendRepository)
        {
            this.spendRepository = spendRepository;
        }

        #region 添加消费信息
        /// <summary>
        /// 添加消费信息
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool InsertSpendInfo(Spend s)
        {
            return spendRepository.Insert(s);
        }
        #endregion

        #region 根据客户编号查询消费信息
        /// <summary>
        /// 根据客户编号查询消费信息
        /// </summary>
        /// <param name="No"></param>
        /// <returns></returns>
        public List<Spend> SelectSpendByCustoNo(string No)
        {
            List<Spend> ls = new List<Spend>();
            ls = spendRepository.GetList(a => a.CustoNo == No && a.MoneyState.Equals(SpendConsts.UnSettle) && a.delete_mk != 1);
            ls.ForEach(source =>
            {
                source.SpendStateNm = string.IsNullOrEmpty(source.MoneyState) ? ""
                : source.MoneyState.Equals(SpendConsts.Settled) ? "已结算" : "未结算";

                source.SpendPriceStr = string.IsNullOrEmpty(source.SpendPrice + "") ? ""
                : Decimal.Parse(source.SpendPrice.ToString()).ToString("#,##0.00").ToString();

                source.SpendMoneyStr = string.IsNullOrEmpty(source.SpendMoney + "") ? ""
                : Decimal.Parse(source.SpendMoney.ToString()).ToString("#,##0.00").ToString();
            });
            return ls;
        }
        #endregion

        #region 根据客户编号查询历史消费信息
        /// <summary>
        /// 根据客户编号查询历史消费信息
        /// </summary>
        /// <param name="custoNo"></param>
        /// <returns></returns>
        public List<Spend> SeletHistorySpendInfoAll(string custoNo)
        {
            List<Spend> ls = new List<Spend>();
            ls = spendRepository.GetList(a => a.CustoNo == custoNo && a.MoneyState.Equals(SpendConsts.Settled) && a.delete_mk != 1);
            ls.ForEach(source =>
            {
                source.SpendStateNm = string.IsNullOrEmpty(source.MoneyState) ? ""
                : source.MoneyState.Equals(SpendConsts.Settled) ? "已结算" : "未结算";

                source.SpendPriceStr = string.IsNullOrEmpty(source.SpendPrice + "") ? ""
                : Decimal.Parse(source.SpendPrice.ToString()).ToString("#,##0.00").ToString();

                source.SpendMoneyStr = string.IsNullOrEmpty(source.SpendMoney + "") ? ""
                : Decimal.Parse(source.SpendMoney.ToString()).ToString("#,##0.00").ToString();
            });
            return ls;
        }
        #endregion

        #region 根据房间编号查询消费信息
        /// <summary>
        /// 根据房间编号查询消费信息
        /// </summary>
        /// <param name="No"></param>
        /// <returns></returns>
        public List<Spend> SelectSpendByRoomNo(string No)
        {
            List<Spend> ls = new List<Spend>();
            ls = spendRepository.GetList(a => a.RoomNo == No && a.MoneyState.Equals(SpendConsts.UnSettle) && a.delete_mk != 1);
            ls.ForEach(source =>
            {
                source.SpendStateNm = string.IsNullOrEmpty(source.MoneyState) ? ""
                : source.MoneyState.Equals(SpendConsts.Settled) ? "已结算" : "未结算";

                source.SpendPriceStr = string.IsNullOrEmpty(source.SpendPrice + "") ? ""
                : Decimal.Parse(source.SpendPrice.ToString()).ToString("#,##0.00").ToString();

                source.SpendMoneyStr = string.IsNullOrEmpty(source.SpendMoney + "") ? ""
                : Decimal.Parse(source.SpendMoney.ToString()).ToString("#,##0.00").ToString();
            });
            return ls;
        }
        #endregion

        #region 查询消费的所有信息
        /// <summary>
        /// 查询消费的所有信息
        /// </summary>
        /// <returns></returns>
        public List<Spend> SelectSpendInfoAll()
        {
            List<Spend> ls = new List<Spend>();
            ls = spendRepository.GetList(a => a.delete_mk != 1).OrderByDescending(a => a.SpendTime).ToList();
            ls.ForEach(source =>
            {
                source.SpendStateNm = string.IsNullOrEmpty(source.MoneyState) ? ""
                : source.MoneyState.Equals(SpendConsts.Settled) ? "已结算" : "未结算";

                source.SpendPriceStr = string.IsNullOrEmpty(source.SpendPrice + "") ? ""
                : Decimal.Parse(source.SpendPrice.ToString()).ToString("#,##0.00").ToString();

                source.SpendMoneyStr = string.IsNullOrEmpty(source.SpendMoney + "") ? ""
                : Decimal.Parse(source.SpendMoney.ToString()).ToString("#,##0.00").ToString();
            });
            return ls;
        }
        #endregion

        #region 根据房间号查询消费的所有信息
        /// <summary>
        /// 根据房间号查询消费的所有信息
        /// </summary>
        /// <returns></returns>
        public List<Spend> SelectSpendInfoRoomNo(string RoomNo)
        {
            List<Spend> ls = new List<Spend>();
            ls = spendRepository.GetList(a => a.RoomNo == RoomNo && a.delete_mk != 1 && a.MoneyState.Equals(SpendConsts.UnSettle));
            ls.ForEach(source =>
            {
                source.SpendStateNm = string.IsNullOrEmpty(source.MoneyState) ? ""
                : source.MoneyState.Equals(SpendConsts.Settled) ? "已结算" : "未结算";

                source.SpendPriceStr = string.IsNullOrEmpty(source.SpendPrice + "") ? ""
                : Decimal.Parse(source.SpendPrice.ToString()).ToString("#,##0.00").ToString();

                source.SpendMoneyStr = string.IsNullOrEmpty(source.SpendMoney + "") ? ""
                : Decimal.Parse(source.SpendMoney.ToString()).ToString("#,##0.00").ToString();
            });
            return ls;
        }
        #endregion

        #region 根据房间编号、入住时间到当前时间查询消费总金额
        /// <summary>
        /// 根据房间编号、入住时间到当前时间查询消费总金额
        /// </summary>
        /// <param name="roomno"></param>
        /// <param name="custono"></param>
        /// <returns></returns>
        public object SelectMoneyByRoomNoAndTime(string roomno,string custono)
        {
            return spendRepository.GetList(a => a.RoomNo == roomno && a.CustoNo == custono && a.MoneyState.Equals(SpendConsts.UnSettle)).Sum(a => a.SpendMoney);
        }
        #endregion

        #region 根据房间编号、入住时间和当前时间修改结算状态
        /// <summary>
        /// 根据房间编号、入住时间和当前时间修改结算状态
        /// </summary>
        /// <param name="roomno"></param>
        /// <param name="checktime"></param>
        /// <returns></returns>
        public bool UpdateMoneyState(string roomno, string checktime)
        {
            return spendRepository.Update(a => new Spend()
            {
                MoneyState = SpendConsts.Settled
            },a => a.RoomNo == roomno && a.SpendTime >= Convert.ToDateTime(checktime) && a.SpendTime <= DateTime.Now); 
        }
        #endregion

        #region 将转房前的未结算记录一同转移到新房间
        /// <summary>
        /// 将转房前的未结算记录一同转移到新房间
        /// </summary>
        /// <param name="spend"></param>
        /// <returns></returns>
        public bool UpdateSpendInfoByRoomNo(Spend spend)
        {
            //查询当前用户未结算的数据
            var listSpendId = spendRepository.GetList(a => a.CustoNo.Equals(spend.CustoNo) && a.MoneyState.Equals(SpendConsts.UnSettle))
                .Select(a => a.SpendName).ToList(); /*spends.Select(a => a.SpendName).Distinct().ToList();*/
            
            return spendRepository.Update(a => new Spend()
            {
                RoomNo = spend.RoomNo,
                datachg_usr = spend.datachg_usr
            }, a => listSpendId.Contains(a.SpendName) && a.CustoNo.Equals(spend.CustoNo)  && a.SpendTime >= DateTime.Now
             && a.SpendTime <= DateTime.Now);


        }
        #endregion

        /// <summary>
        /// 更新消费信息
        /// </summary>
        /// <param name="spend"></param>
        /// <returns></returns>
        public bool UpdSpenInfo(Spend spend)
        {
            return spendRepository.Update(a => new Spend()
            {
                SpendAmount = spend.SpendAmount,
                SpendMoney = spend.SpendMoney,

            }, a => a.MoneyState.Equals(SpendConsts.UnSettle) 
            && a.RoomNo.Equals(spend.RoomNo)
            && a.CustoNo.Equals(spend.CustoNo)
            && a.SpendName.Equals(spend.SpendName));
        }

    }
}
