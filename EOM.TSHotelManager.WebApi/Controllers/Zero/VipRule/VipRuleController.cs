using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 会员规则控制器
    /// </summary>
    public class VipRuleController : ControllerBase
    {
        /// <summary>
        /// 会员规则
        /// </summary>
        private readonly IVipRuleAppService vipRuleAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vipRuleAppService"></param>
        public VipRuleController(IVipRuleAppService vipRuleAppService)
        {
            this.vipRuleAppService = vipRuleAppService;
        }

        /// <summary>
        /// 查询会员等级规则列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<VipRule> SelectVipRuleList()
        {
            return vipRuleAppService.SelectVipRuleList();
        }

        /// <summary>
        /// 查询会员等级规则
        /// </summary>
        /// <param name="vipRule"></param>
        /// <returns></returns>
        [HttpGet]
        public VipRule SelectVipRule([FromQuery] VipRule vipRule)
        {
            return vipRuleAppService.SelectVipRule(vipRule);
        }

        /// <summary>
        /// 添加会员等级规则
        /// </summary>
        /// <param name="vipRule"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddVipRule([FromBody] VipRule vipRule)
        {
            return vipRuleAppService.AddVipRule(vipRule);
        }

        /// <summary>
        /// 删除会员等级规则
        /// </summary>
        /// <param name="vipRule"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DelVipRule([FromBody] VipRule vipRule)
        {
            return vipRuleAppService.DelVipRule(vipRule);
        }

        /// <summary>
        /// 更新会员等级规则
        /// </summary>
        /// <param name="vipRule"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdVipRule([FromBody] VipRule vipRule)
        {
            return vipRuleAppService.UpdVipRule(vipRule);
        }
    }
}
