using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 公告控制器
    /// </summary>
    public class NoticeController : ControllerBase
    {
        /// <summary>
        /// 公告
        /// </summary>
        private readonly INoticeService noticeService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="noticeService"></param>
        public NoticeController(INoticeService noticeService)
        {
            this.noticeService = noticeService;
        }

        #region 获取所有公告信息
        /// <summary>
        /// 获取所有公告信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Notice> SelectNoticeAll()
        {
            return noticeService.SelectNoticeAll();
        }
        #endregion

        /// <summary>
        /// 查询公告
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        [HttpGet]
        public Notice SelectNoticeByNoticeNo([FromQuery]string noticeId)
        {
            return noticeService.SelectNoticeByNoticeNo(noticeId);
        }

        #region 上传公告信息
        /// <summary>
        /// 上传公告信息
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        [HttpPost]
        public bool InsertNotice([FromBody]Notice notice)
        {
            return noticeService.InsertNotice(notice);
        }

        #endregion

    }
}
