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
using EOM.Encrypt;
using EOM.TSHotelManager.Common.Core;
using EOM.TSHotelManager.EntityFramework;
using System;
using System.Collections.Generic;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 预约信息接口实现类
    /// </summary>
    public class ReserService:IReserService
    {
        /// <summary>
        /// 预约信息
        /// </summary>
        private readonly PgRepository<Reser> reserRepository;

        /// <summary>
        /// 加密
        /// </summary>
        private readonly EOM.Encrypt.Encrypt encrypt;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserRepository"></param>
        /// <param name="encrypt"></param>
        public ReserService(PgRepository<Reser> reserRepository, EOM.Encrypt.Encrypt encrypt)
        {
            this.reserRepository = reserRepository;
            this.encrypt = encrypt;
        }

        /// <summary>
        /// 获取所有预约信息
        /// </summary>
        /// <returns></returns>
        public List<Reser> SelectReserAll()
        {
            List<Reser> rss = new List<Reser>();
            rss = reserRepository.GetList(a => a.delete_mk == 0);
            rss.ForEach(source =>
            {
                //解密联系方式
                var sourceTelStr = source.CustoTel.Contains("·") ? encrypt.Decryption(source.CustoTel) : source.CustoTel;
                source.CustoTel = sourceTelStr;
            });
            return rss;
        }

        /// <summary>
        /// 根据房间编号获取预约信息
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public Reser SelectReserInfoByRoomNo(string no)
        {
            Reser res = null;
            res = reserRepository.GetSingle(a => a.ReserRoom == no && a.delete_mk != 1);
            //解密联系方式
            var sourceTelStr = res.CustoTel.Contains("·") ? encrypt.Decryption(res.CustoTel) : res.CustoTel;
            res.CustoTel = sourceTelStr;
            return res;
        }

        /// <summary>
        /// 删除预约信息
        /// </summary>
        /// <param name="reser"></param>
        /// <returns></returns>
        public bool DeleteReserInfo(Reser reser)
        {
            return reserRepository.Update(a => new Reser()
            {
                delete_mk = 1,
                datachg_usr = string.Empty
            },a => a.ReserId == reser.ReserId);

        }

        /// <summary>
        /// 添加预约信息
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool InserReserInfo(Reser r)
        {
            var cryStr = encrypt.Encryption(r.CustoTel, EncryptionLevel.Enhanced);
            r.CustoTel = cryStr;
            return reserRepository.Insert(r);
        }


    }
}
