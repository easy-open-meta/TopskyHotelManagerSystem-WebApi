using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 工具类控制器
    /// </summary>
    public class AppController : ControllerBase
    {
        /// <summary>
        /// 工具
        /// </summary>
        private readonly IUtilService utilService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="utilService"></param>
        public AppController(IUtilService utilService)
        {
            this.utilService = utilService;
        }

        /// <summary>
        /// 查询身份证号码
        /// </summary>
        /// <param name="identityCard"></param>
        /// <returns></returns>
        [HttpGet]
        public string SelectCardCode([FromQuery] string identityCard)
        {
            return utilService.SelectCardCode(identityCard);
        }

        /// <summary>
        /// 检测版本号
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public Applicationversion CheckBaseVersion()
        {
            return utilService.CheckBaseVersion();
        }

        /// <summary>
        /// 添加操作日志
        /// </summary>
        /// <param name="opr"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddLog([FromBody] OperationLog opr)
        {
            return utilService.AddLog(opr);
        }

        /// <summary>
        /// 查询所有操作日志
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public OSelectAllDto<OperationLog> SelectOperationlogAll([FromQuery] int? pageIndex, int? pageSize)
        {
            return utilService.SelectOperationlogAll(pageIndex, pageSize);
        }
    }
}
