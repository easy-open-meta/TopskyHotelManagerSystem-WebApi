using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 公告日志表
    /// </summary>
    [Table("uploadinfo")]
    public class UploadInfo : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public UploadInfo()
        {
        }

        /// <summary>
        /// 公告编号
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.String NoticeNo { get; set; }

        /// <summary>
        /// 公告主题
        /// </summary>
        public System.String Noticetheme { get; set; }

        /// <summary>
        /// 公告类型
        /// </summary>
        public System.String NoticeType { get; set; }

        /// <summary>
        /// 发布日期
        /// </summary>
        public System.DateTime NoticeTime { get; set; }

        /// <summary>
        /// 公告正文
        /// </summary>
        public System.String NoticeContent { get; set; }

        /// <summary>
        /// 发文部门
        /// </summary>
        public System.String NoticeClub { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public System.Int32 delete_mk { get; set; }

        /// <summary>
        /// 资料创建人
        /// </summary>
        public System.String datains_usr { get; set; }

        /// <summary>
        /// 资料创建时间
        /// </summary>
        public System.DateTime? datains_date { get; set; }

        /// <summary>
        /// 资料更新人
        /// </summary>
        public System.String datachg_usr { get; set; }

        /// <summary>
        /// 资料更新时间
        /// </summary>
        public System.DateTime? datachg_date { get; set; }
    }
}
