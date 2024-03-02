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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 会员等级规则功能模块接口实现类
    /// </summary>
    public class VipRuleAppService:IVipRuleAppService
    {
        /// <summary>
        /// 会员等级规则
        /// </summary>
        private readonly PgRepository<VipRule> vipRuleRepository;

        /// <summary>
        /// 客户类型
        /// </summary>
        private readonly PgRepository<CustoType> custoTypeRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vipRuleRepository"></param>
        /// <param name="custoTypeRepository"></param>
        public VipRuleAppService(PgRepository<VipRule> vipRuleRepository, PgRepository<CustoType> custoTypeRepository)
        {
            this.vipRuleRepository = vipRuleRepository;
            this.custoTypeRepository = custoTypeRepository;
        }

        /// <summary>
        /// 查询会员等级规则列表
        /// </summary>
        /// <returns></returns>
        public List<VipRule> SelectVipRuleList()
        {
            List<VipRule> vipRules = new List<VipRule>();

            var listSource = vipRuleRepository.GetList(a => a.delete_mk != 1);

            var listUserType = custoTypeRepository.GetList(a => a.delete_mk != 1);

            listSource.ForEach(source =>
            {
                var userType = listUserType.FirstOrDefault(a => a.UserType == source.type_id);
                source.type_name = userType == null ? "" : userType.TypeName;
            });

            vipRules = listSource;

            return vipRules;
        }

        /// <summary>
        /// 查询会员等级规则
        /// </summary>
        /// <param name="vipRule"></param>
        /// <returns></returns>
        public VipRule SelectVipRule(VipRule vipRule)
        {
            VipRule vipRule1 = new VipRule();

            var source = vipRuleRepository.GetSingle(a => a.rule_id.Equals(vipRule.rule_id));

            var userType = custoTypeRepository.GetSingle(a => a.UserType == source.type_id);
            source.type_name = userType == null ? "" : userType.TypeName;

            vipRule1 = source;

            return vipRule1;
        }

        /// <summary>
        /// 添加会员等级规则
        /// </summary>
        /// <param name="vipRule"></param>
        /// <returns></returns>
        public bool AddVipRule(VipRule vipRule)
        {
            return vipRuleRepository.Insert(new VipRule() 
            {
                rule_id = vipRule.rule_id,
                rule_name = vipRule.rule_name,
                rule_value = vipRule.rule_value,
                type_id = vipRule.type_id,
                delete_mk = 0,
                datains_usr = vipRule.datains_usr,
            });
        }

        /// <summary>
        /// 删除会员等级规则
        /// </summary>
        /// <param name="vipRule"></param>
        /// <returns></returns>
        public bool DelVipRule(VipRule vipRule)
        {
            return vipRuleRepository.Update(a => new VipRule
            {
                delete_mk = 1,
                datachg_usr = vipRule.datachg_usr,
            },a => a.rule_id == vipRule.rule_id);
        }

        /// <summary>
        /// 更新会员等级规则
        /// </summary>
        /// <param name="vipRule"></param>
        /// <returns></returns>
        public bool UpdVipRule(VipRule vipRule)
        {
            return vipRuleRepository.Update(a => new VipRule
            {
                rule_name = vipRule.rule_name,
                rule_value = vipRule.rule_value,
                delete_mk = vipRule.delete_mk,
                datachg_usr = vipRule.datachg_usr
            }, a => a.rule_id == vipRule.rule_id);
        }
    }
}
