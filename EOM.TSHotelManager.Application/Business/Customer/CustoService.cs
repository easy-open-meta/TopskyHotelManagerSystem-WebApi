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
using jvncorelib.EntityLib;
using SqlSugar;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 客户信息接口实现类
    /// </summary>
    public class CustoService : ICustoService
    {
        /// <summary>
        /// 客户信息
        /// </summary>
        private readonly GenericRepository<Custo> custoRepository;

        /// <summary>
        /// 消费情况
        /// </summary>
        private readonly GenericRepository<Spend> spendRepository;

        /// <summary>
        /// 性别类型
        /// </summary>
        private readonly GenericRepository<SexType> sexTypeRepository;

        /// <summary>
        /// 证件类型
        /// </summary>
        private readonly GenericRepository<PassPortType> passPortTypeRepository;

        /// <summary>
        /// 客户类型
        /// </summary>
        private readonly GenericRepository<CustoType> custoTypeRepository;

        /// <summary>
        /// 加密
        /// </summary>
        private readonly jvncorelib.EncryptorLib.EncryptLib encrypt;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custoRepository"></param>
        /// <param name="spendRepository"></param>
        /// <param name="sexTypeRepository"></param>
        /// <param name="passPortTypeRepository"></param>
        /// <param name="custoTypeRepository"></param>
        /// <param name="encrypt"></param>
        public CustoService(GenericRepository<Custo> custoRepository, GenericRepository<Spend> spendRepository, GenericRepository<SexType> sexTypeRepository, GenericRepository<PassPortType> passPortTypeRepository, GenericRepository<CustoType> custoTypeRepository, jvncorelib.EncryptorLib.EncryptLib encrypt)
        {
            this.custoRepository = custoRepository;
            this.spendRepository = spendRepository;
            this.sexTypeRepository = sexTypeRepository;
            this.passPortTypeRepository = passPortTypeRepository;
            this.custoTypeRepository = custoTypeRepository;
            this.encrypt = encrypt;
        }

        #region 添加客户信息
        /// <summary>
        /// 添加客户信息
        /// </summary>
        /// <param name="custo"></param>
        /// <returns></returns>
        public bool InsertCustomerInfo(Custo custo)
        {
            string NewID = encrypt.Encryption(custo.CustoID, jvncorelib.EncryptorLib.EncryptionLevel.Enhanced);
            string NewTel = encrypt.Encryption(custo.CustoTel, jvncorelib.EncryptorLib.EncryptionLevel.Enhanced);
            custo.CustoID = NewID;
            custo.CustoTel = NewTel;
            return custoRepository.Insert(custo);
        }
        #endregion

        /// <summary>
        /// 更新客户信息
        /// </summary>
        /// <param name="custo"></param>
        /// <returns></returns>
        public bool UpdCustomerInfoByCustoNo(Custo custo)
        {
            string NewID = encrypt.Encryption(custo.CustoID);
            string NewTel = encrypt.Encryption(custo.CustoTel);
            custo.CustoID = NewID;
            custo.CustoTel = NewTel;
            return custoRepository.Update(a => new Custo()
            {
                CustoName = custo.CustoName,
                CustoSex = custo.CustoSex,
                CustoType = custo.CustoType,
                CustoBirth = custo.CustoBirth,
                CustoAdress = custo.CustoAdress,
                CustoID = custo.CustoID,
                CustoTel = custo.CustoTel,
                PassportType = custo.PassportType,
                datachg_usr = custo.datachg_usr
            }, a => a.CustoNo == custo.CustoNo);
        }

        /// <summary>
        /// 更新客户类型(即会员等级)
        /// </summary>
        /// <param name="custoNo"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        public bool UpdCustomerTypeByCustoNo(string custoNo, int userType)
        {
            return custoRepository.Update(a => new Custo()
            {
                CustoType = userType
            }, a => a.CustoNo.Equals(custoNo));
        }

        /// <summary>
        /// 查询酒店盈利情况
        /// </summary>
        /// <returns></returns>
        public List<CustoSpend> SelectAllMoney()
        {
            List<CustoSpend> custoSpends = new List<CustoSpend>();
            var listSource = spendRepository.GetList(a => a.MoneyState.Equals(SpendConsts.Settled)).OrderBy(a => a.SpendTime).ToList();
            var listDates = new List<CustoSpend>();
            listSource.ForEach(source =>
            {
                var year = Convert.ToDateTime(source.SpendTime).ToString("yyyy");
                if (!custoSpends.Select(a => a.Years).ToList().Contains(year))
                {
                    var startDate = new DateTime(Convert.ToDateTime(source.SpendTime).Year, 1, 1, 0, 0, 0);
                    var endDate = new DateTime(Convert.ToDateTime(source.SpendTime).Year, 12, 31, 23, 59, 59);
                    custoSpends.Add(new CustoSpend
                    {
                        Years = year,
                        Money = listSource.Where(a => a.SpendTime >= startDate && a.SpendTime <= endDate).Sum(a => a.SpendMoney)
                    });
                }
            });

            custoSpends = custoSpends.OrderBy(a => a.Years).ToList();
            return custoSpends;
        }

        /// <summary>
        /// 查询所有客户信息
        /// </summary>
        /// <returns></returns>
        public OSelectAllDto<Custo> SelectCustoAll(int? pageIndex, int? pageSize, bool onlyVip = false)
        {
            OSelectAllDto<Custo> oSelectCustoAllDto = new OSelectAllDto<Custo>();

            //查询出所有性别类型
            List<SexType> sexTypes = new List<SexType>();
            sexTypes = sexTypeRepository.GetList();
            //查询出所有证件类型
            List<PassPortType> passPortTypes = new List<PassPortType>();
            passPortTypes = passPortTypeRepository.GetList();
            //查询出所有客户类型
            List<CustoType> custoTypes = new List<CustoType>();
            custoTypes = custoTypeRepository.GetList();
            //查询出所有客户信息
            List<Custo> custos = new List<Custo>();

            var count = 0;

            if (pageIndex != 0 && pageSize != 0)
            {
                custos = custoRepository.AsQueryable().ToPageList((int)pageIndex, (int)pageSize, ref count);
                if (onlyVip)
                {
                    custos = custoRepository.AsQueryable().Where(a => a.CustoType != 0).ToPageList((int)pageIndex, (int)pageSize, ref count);
                }
            }
            else
            {
                custos = custoRepository.AsQueryable().ToList();
            }

            custos.ForEach(source =>
            {
                //解密身份证号码
                var sourceStr = source.CustoID.Contains('·') ? encrypt.Decryption(source.CustoID) : source.CustoID;
                source.CustoID = sourceStr;
                //解密联系方式
                var sourceTelStr = source.CustoTel.Contains('·') ? encrypt.Decryption(source.CustoTel) : source.CustoTel;
                source.CustoTel = sourceTelStr;
                //性别类型
                var sexType = sexTypes.FirstOrDefault(a => a.sexId == source.CustoSex);
                source.SexName = sexType.sexName.IsNullOrEmpty() ? "" : sexType.sexName;
                //证件类型
                var passPortType = passPortTypes.FirstOrDefault(a => a.PassportId == source.PassportType);
                source.PassportName = passPortType.PassportName.IsNullOrEmpty() ? "" : passPortType.PassportName;
                //客户类型
                var custoType = custoTypes.FirstOrDefault(a => a.UserType == source.CustoType);
                source.typeName = custoType.TypeName.IsNullOrEmpty() ? "" : custoType.TypeName;
            });

            oSelectCustoAllDto.listSource = custos;
            oSelectCustoAllDto.total = count;

            return oSelectCustoAllDto;
        }

        /// <summary>
        /// 查询指定客户信息
        /// </summary>
        /// <returns></returns>
        public List<Custo> SelectCustoByInfo(Custo custo)
        {
            //查询出所有性别类型
            List<SexType> sexTypes = new List<SexType>();
            sexTypes = sexTypeRepository.GetList();
            //查询出所有证件类型
            List<PassPortType> passPortTypes = new List<PassPortType>();
            passPortTypes = passPortTypeRepository.GetList();
            //查询出所有客户类型
            List<CustoType> custoTypes = new List<CustoType>();
            custoTypes = custoTypeRepository.GetList();
            //查询出所有客户信息
            List<Custo> custos = new List<Custo>();
            if (!custo.CustoNo.IsNullOrEmpty())
            {
                custos = custoRepository.GetList(a => a.CustoNo.Contains(custo.CustoNo)).OrderBy(a => a.CustoNo).ToList();
            }
            if (!custo.CustoName.IsNullOrEmpty())
            {
                custos = custoRepository.GetList(a => a.CustoName.Contains(custo.CustoName)).OrderBy(a => a.CustoNo).ToList();
            }
            custos.ForEach(source =>
            {
                //解密身份证号码
                var sourceStr = source.CustoID.Contains("·") ? encrypt.Decryption(source.CustoID) : source.CustoID;
                source.CustoID = sourceStr;
                //解密联系方式
                var sourceTelStr = source.CustoTel.Contains("·") ? encrypt.Decryption(source.CustoTel) : source.CustoTel;
                source.CustoTel = sourceTelStr;
                //性别类型
                var sexType = sexTypes.FirstOrDefault(a => a.sexId == source.CustoSex);
                source.SexName = sexType.sexName.IsNullOrEmpty() ? "" : sexType.sexName;
                //证件类型
                var passPortType = passPortTypes.FirstOrDefault(a => a.PassportId == source.PassportType);
                source.PassportName = passPortType.PassportName.IsNullOrEmpty() ? "" : passPortType.PassportName;
                //客户类型
                var custoType = custoTypes.FirstOrDefault(a => a.UserType == source.CustoType);
                source.typeName = custoType.TypeName.IsNullOrEmpty() ? "" : custoType.TypeName;
            });
            return custos;
        }

        /// <summary>
        /// 根据客户编号查询客户信息
        /// </summary>
        /// <param name="CustoNo"></param>
        /// <returns></returns>
        public Custo SelectCardInfoByCustoNo(string CustoNo)
        {
            Custo c = custoRepository.GetSingle(a => a.CustoNo.Equals(CustoNo));
            if (c.IsNullOrEmpty())
            {
                return null;
            }
            //性别类型
            var sexType = sexTypeRepository.GetSingle(a => a.sexId == c.CustoSex);
            c.SexName = sexType.sexName.IsNullOrEmpty() ? "" : sexType.sexName;
            //证件类型
            var passPortType = passPortTypeRepository.GetSingle(a => a.PassportId == c.PassportType);
            c.PassportName = passPortType.PassportName.IsNullOrEmpty() ? "" : passPortType.PassportName;
            //客户类型
            var custoType = custoTypeRepository.GetSingle(a => a.UserType == c.CustoType);
            c.typeName = custoType.TypeName.IsNullOrEmpty() ? "" : custoType.TypeName;
            //解密身份证号码
            var sourceStr = c.CustoID.Contains("·") ? encrypt.Decryption(c.CustoID) : c.CustoID;
            c.CustoID = sourceStr;
            //解密联系方式
            var sourceTelStr = c.CustoTel.Contains("·") ? encrypt.Decryption(c.CustoTel) : c.CustoTel;
            c.CustoTel = sourceTelStr;
            return c;
        }

    }
}
