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
    /// 公告信息接口实现类
    /// </summary>
    public class NoticeService : INoticeService
    {
        /// <summary>
        /// 公告
        /// </summary>
        private readonly PgRepository<Notice> noticeRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="noticeRepository"></param>
        public NoticeService(PgRepository<Notice> noticeRepository)
        {
            this.noticeRepository = noticeRepository;
        }

        #region 获取所有公告信息
        /// <summary>
        /// 获取所有公告信息
        /// </summary>
        /// <returns></returns>
        public List<Notice> SelectNoticeAll()
        {
            List<Notice> ntc = new List<Notice>();
            ntc = noticeRepository.GetList(a => a.delete_mk != 1);
            ntc.ForEach(source =>
            {
                switch (source.NoticeType)
                {
                    case "PersonnelChanges":
                        source.NoticeTypeName = "人事变动";
                        break;
                    case "GeneralNotice":
                        source.NoticeTypeName = "普通公告";
                        break;
                }
            });
            return ntc;
        }
        #endregion

        /// <summary>
        /// 根据公告编号查找公告信息
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        public Notice SelectNoticeByNoticeNo(string noticeId)
        {
            Notice notice = new Notice();
            notice = noticeRepository.GetSingle(a => a.NoticeNo == noticeId);
            switch (notice.NoticeType)
            {
                case "PersonnelChanges":
                    notice.NoticeTypeName = "人事变动";
                    break;
                case "GeneralNotice":
                    notice.NoticeTypeName = "普通公告";
                    break;
            }
            return notice;
        }

        #region 上传公告信息
        /// <summary>
        /// 上传公告信息
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        public bool InsertNotice(Notice notice)
        {
            return noticeRepository.Insert(notice);
        }

        #endregion

    }
}
