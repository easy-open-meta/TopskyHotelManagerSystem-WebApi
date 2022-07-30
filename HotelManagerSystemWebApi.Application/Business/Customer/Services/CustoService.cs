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
using jvncorelib.CodeLib;
using jvncorelib.EncryptorLib;
using jvncorelib.EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 客户信息接口实现类
    /// </summary>
    public class CustoService:ICustoService, ITransient
    {
        /// <summary>
        /// 客户信息
        /// </summary>
        private readonly IRepository<Custo> customerRepository;

        /// <summary>
        /// 客户消费信息
        /// </summary>
        private readonly IRepository<Spend> spendRepository;

        /// <summary>
        /// 客户类型
        /// </summary>
        private readonly IRepository<CustoType> customerTypeRepository;

        /// <summary>
        /// 性别类型
        /// </summary>
        private readonly IRepository<SexType> sexTypeRepository;

        /// <summary>
        /// 证件类型
        /// </summary>
        private readonly IRepository<PassPortType> passportTypeRepository;

        EncryptLib encryptLib = new EncryptLib();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerRepository"></param>
        /// <param name="customerTypeRepository"></param>
        /// <param name="sexTypeRepository"></param>
        /// <param name="passportTypeRepository"></param>
        /// <param name="encryptLib"></param>
        public CustoService(IRepository<Custo> customerRepository, IRepository<CustoType> customerTypeRepository, IRepository<SexType> sexTypeRepository, IRepository<PassPortType> passportTypeRepository, EncryptLib encryptLib)
        {
            this.customerRepository = customerRepository;
            this.customerTypeRepository = customerTypeRepository;
            this.sexTypeRepository = sexTypeRepository;
            this.passportTypeRepository = passportTypeRepository;
            this.encryptLib = encryptLib;
        }

        #region 添加客户信息
        /// <summary>
        /// 添加客户信息
        /// </summary>
        /// <param name="insertCustomerInfoDto"></param>
        /// <returns></returns>
        public OInsertCustomerInfoDto InsertCustomerInfo(InsertCustomerInfoDto insertCustomerInfoDto)
        {
            OInsertCustomerInfoDto oInsertCustomerInfoDto = new OInsertCustomerInfoDto();

            var uncode = new UniqueCode();

            var source = new Custo();

            source = source.UpdateToModel(insertCustomerInfoDto);
            source.CustoNo = uncode.GetNewId("TS");
            source.CustoID = encryptLib.Encryption(source.CustoID);
            source.CustoTel = encryptLib.Encryption(source.CustoTel);
            this.customerRepository.Insert(source);
            oInsertCustomerInfoDto.OK();

            return oInsertCustomerInfoDto;
        }
        #endregion

        /// <summary>
        /// 更新客户信息
        /// </summary>
        /// <param name="updCustomerInfoDto"></param>
        /// <returns></returns>
        public OUpdCustomerInfoDto UpdCustomerInfoNo(UpdCustomerInfoDto updCustomerInfoDto)
        {
            OUpdCustomerInfoDto oUpdCustomerInfoDto = new OUpdCustomerInfoDto();

            var source = this.customerRepository.SingleOrDefault(a => a.CustoNo.Equals(updCustomerInfoDto.CustoNo));

            if (source.IsNullOrEmpty())
            {
                oUpdCustomerInfoDto.Error_NotFound();
                return oUpdCustomerInfoDto;
            }

            source = source.UpdateToModel(updCustomerInfoDto);
            source.CustoID = encryptLib.Encryption(source.CustoID);
            source.CustoTel = encryptLib.Encryption(source.CustoTel);
            this.customerRepository.Update(source);

            oUpdCustomerInfoDto.OK();

            return oUpdCustomerInfoDto;

        }

        /// <summary>
        /// 更新客户类型(即会员等级)
        /// </summary>
        /// <param name="custoNo"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        //public OUpdCustomerTypeByCustoNoDto UpdCustomerTypeByCustoNo(string custoNo, int userType)
        //{
        //    OUpdCustomerTypeByCustoNoDto oUpdCustomerTypeByCustoNoDto = new OUpdCustomerTypeByCustoNoDto();

        //    customerRepository.Update(new Custo { CustoNo = custoNo, CustoType = userType });
        //    oUpdCustomerTypeByCustoNoDto.OK();

        //    return oUpdCustomerTypeByCustoNoDto;

        //}

        /// <summary>
        /// 查询酒店盈利情况
        /// </summary>
        /// <returns></returns>
        public OSelectAllMoneyDto SelectAllMoney()
        {
            OSelectAllMoneyDto oSelectAllMoneyDto = new OSelectAllMoneyDto();

            List<CustoSpend> custoSpends = new List<CustoSpend>();
            var listSource = spendRepository.AsQueryable(a => a.MoneyState.Equals(SpendConsts.Settled))
                .OrderBy(a => a.SpendTime).ToList().CopyToModel<Spend,Temp_CustoSpend>();
            var listDates = new List<CustoSpend>();
            listSource.ForEach(source =>
            {
                var year = source.SpendTime.ToString("yyyy");
                if (!custoSpends.Select(a => a.Years).ToList().Contains(year))
                {
                    var startDate = new DateTime(source.SpendTime.Year, 1, 1, 0, 0, 0);
                    var endDate = new DateTime(source.SpendTime.Year, 12, 31, 23, 59, 59);
                    custoSpends.Add(new CustoSpend
                    {
                        Years = year,
                        Money = listSource.Where(a => a.SpendTime >= startDate && a.SpendTime <= endDate).Sum(a => a.SpendMoney)
                    });
                }
            });

            custoSpends = custoSpends.OrderBy(a => a.Years).ToList();
            oSelectAllMoneyDto.listSource = custoSpends;
            oSelectAllMoneyDto.OK();

            return oSelectAllMoneyDto;
        }

        /// <summary>
        /// 查询所有客户信息
        /// </summary>
        /// <returns></returns>
        public OSelectCustoAllDto SelectCustoAll(SelectCustoAllDto selectCustoAllDto)
        {
            OSelectCustoAllDto oSelectCustoAllDto = new OSelectCustoAllDto();

            //查询出所有性别类型
            var sexTypes = sexTypeRepository.AsQueryable().ToList().CopyToModel<SexType,Temp_SexType>();
            //查询出所有证件类型
            var passPortTypes = passportTypeRepository.AsQueryable().ToList().CopyToModel<PassPortType, Temp_PassportType>();
            //查询出所有客户类型
            var custoTypes = customerTypeRepository.AsQueryable().ToList().CopyToModel<CustoType, Temp_CustomerType>();

            var where = LinqExpression.Create<Custo>(a => a.delete_mk != 1);

            if (!selectCustoAllDto.CustoNo.IsNullOrEmpty())
            {
                where = where.And(a => a.CustoNo.Contains(selectCustoAllDto.CustoNo));
            }

            if (!selectCustoAllDto.CustoName.IsNullOrEmpty())
            {
                where = where.And(a => a.CustoName.Contains(selectCustoAllDto.CustoName));
            }

            var count = 0;

            //查询出所有客户信息
            var custos = customerRepository.AsQueryable(where).OrderBy(a => a.CustoNo).ToList()
                .GetPageList(selectCustoAllDto.PageIndex, selectCustoAllDto.PageSize, ref count)
                .CopyToModel<Custo,Temp_Customer>();

            custos.ForEach(source =>
            {
                //解密身份证号码
                var sourceStr = source.CustoID.Contains("·") ? encryptLib.Decryption(source.CustoID) : source.CustoID;
                source.CustoID = sourceStr;
                //解密联系方式
                var sourceTelStr = source.CustoTel.Contains("·") ? encryptLib.Decryption(source.CustoTel) : source.CustoTel;
                source.CustoTel = sourceTelStr;
                //性别类型
                var sexType = sexTypes.FirstOrDefault(a => a.sexId == source.CustoSex);
                source.SexName = string.IsNullOrEmpty(sexType.sexName) ? "" : sexType.sexName;
                //证件类型
                var passPortType = passPortTypes.FirstOrDefault(a => a.PassportId == source.PassportType);
                source.PassportName = string.IsNullOrEmpty(passPortType.PassportName) ? "" : passPortType.PassportName;
                //客户类型
                var custoType = custoTypes.FirstOrDefault(a => a.UserType == source.CustoType);
                source.typeName = string.IsNullOrEmpty(custoType.TypeName) ? "" : custoType.TypeName;
            });

            oSelectCustoAllDto.listSource = custos;
            oSelectCustoAllDto.total = count;
            oSelectCustoAllDto.OK();
            return oSelectCustoAllDto;
        }

    }
}
