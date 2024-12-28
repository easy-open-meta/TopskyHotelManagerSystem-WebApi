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
    /// 水电信息接口实现类
    /// </summary>
    public class HydroelectricPowerService : IHydroelectricPowerService
    {
        /// <summary>
        /// 水电信息
        /// </summary>
        private readonly GenericRepository<HydroelectricPower> wtiRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wtiRepository"></param>
        public HydroelectricPowerService(GenericRepository<HydroelectricPower> wtiRepository)
        {
            this.wtiRepository = wtiRepository;
        }

        #region 根据房间编号查询水电费信息
        /// <summary>
        /// 根据房间编号查询水电费信息
        /// </summary>
        /// <param name="roomNo"></param>
        /// <returns></returns>
        public HydroelectricPower SelectWtiInfoByRoomNo(string roomNo)
        {
            HydroelectricPower w = new HydroelectricPower();
            w = wtiRepository.GetSingle(a => a.RoomNo.Contains(roomNo) && a.delete_mk != 1);
            return w;
        }
        #endregion

        #region 根据房间编号、使用时间查询水电费信息
        /// <summary>
        /// 根据房间编号、使用时间查询水电费信息
        /// </summary>
        /// <param name="roomno"></param>
        /// <param name="usedate"></param>
        /// <param name="enddate"></param>
        /// <returns></returns>
        public HydroelectricPower SelectWtiInfoByRoomNoAndTime(string roomno, string usedate, string enddate)
        {
            HydroelectricPower w = null;
            w = wtiRepository.GetSingle(a => a.RoomNo == roomno && a.UseDate >= Convert.ToDateTime(usedate) && a.EndDate >= Convert.ToDateTime(enddate));
            return w;
        }
        #endregion

        #region 获取所有水电费信息
        /// <summary>
        /// 获取所有水电费信息
        /// </summary>
        /// <returns></returns>
        public List<HydroelectricPower> SelectWtiInfoAll()
        {
            List<HydroelectricPower> wti = new List<HydroelectricPower>();
            wti = wtiRepository.GetList(a => a.delete_mk != 1);
            return wti;
        }
        #endregion

        #region 根据房间编号获取该房间所有水电费信息
        /// <summary>
        /// 获取所有水电费信息
        /// </summary>
        /// <returns></returns>
        public List<HydroelectricPower> ListWtiInfoByRoomNo(string roomno)
        {
            List<HydroelectricPower> wti = new List<HydroelectricPower>();
            wti = wtiRepository.GetList(a => a.delete_mk != 1 && a.RoomNo.Equals(roomno));
            return wti;
        }
        #endregion

        #region 添加水电费信息
        /// <summary>
        /// 添加水电费信息
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        public bool InsertWtiInfo(HydroelectricPower w)
        {
            return wtiRepository.Insert(w);
        }
        #endregion

        #region 修改水电费信息(根据房间编号)
        /// <summary>
        /// 修改水电费信息(根据房间编号)
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        public bool UpdateWtiInfo(HydroelectricPower w)
        {
            return wtiRepository.Update(a => new HydroelectricPower()
            {
                UseDate = w.UseDate,
                EndDate = w.EndDate,
                WaterUse = w.WaterUse,
                PowerUse = w.PowerUse,
                Record = w.Record,
                CustoNo = w.CustoNo,
                datachg_usr = w.datachg_usr,
                RoomNo = w.RoomNo
            }, a => a.WtiNo == w.WtiNo);

        }
        #endregion

        #region 根据房间信息、使用时间修改水电费
        /// <summary>
        /// 根据房间信息、使用时间修改水电费
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        public bool UpdateWtiInfoByRoomNoAndDateTime(HydroelectricPower w)
        {
            return wtiRepository.Update(a => new HydroelectricPower()
            {
                WaterUse = w.WaterUse,
                PowerUse = w.PowerUse,
                datachg_usr = w.datachg_usr
            }, a => a.RoomNo == w.RoomNo && a.UseDate >= w.UseDate && a.EndDate >= w.EndDate);
        }
        #endregion

        #region 删除水电费信息:根据房间编号
        /// <summary>
        /// 删除水电费信息:根据房间编号
        /// </summary>
        /// <param name="roomno"></param>
        /// <returns></returns>
        //public bool DeleteWtiInfo(string roomno)
        //{
        //    return base.Update(a => new Wti()
        //    {
        //        delete_mk = 1,
        //        datachg_usr = string.Empty,
        //        datachg_date = Convert.ToDateTime(DateTime.Now)
        //    }, a => a.WtiNo == roomno);
        //}
        #endregion

        #region 根据房间编号、使用时间删除水电费信息
        /// <summary>
        /// 根据房间编号、使用时间删除水电费信息
        /// </summary>
        /// <param name="roomno"></param>
        /// <param name="usedate"></param>
        /// <param name="enddate"></param>
        /// <returns></returns>
        public bool DeleteWtiInfoByRoomNoAndDateTime(string roomno, string usedate, string enddate)
        {
            //string sql = "delete from WTINFO where RoomNo='{0}' and UseDate='{1}' and EndDate='{2}'";
            //sql = string.Format(sql, roomno, usedate, enddate);
            return wtiRepository.Update(a => new HydroelectricPower()
            {
                delete_mk = 1
            }, a => a.RoomNo == roomno && a.UseDate >= Convert.ToDateTime(usedate) && a.EndDate >= Convert.ToDateTime(enddate));
        }
        #endregion
    }
}
