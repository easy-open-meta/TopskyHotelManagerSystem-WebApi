using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOM.TSHotelManager.Common.Core
{
    /// <summary>
    /// 导航控件实体类
    /// </summary>
    [SqlSugar.SugarTable("nav_bar")]
    public class NavBar : BaseDTO
    {
        /// <summary>
        /// 导航控件ID
        /// </summary>
        [SqlSugar.SugarColumn(IsIdentity =true)]
        public int nav_id { get; set; }
        /// <summary>
        /// 导航控件名称
        /// </summary>
        public string nav_name { get; set; }
        /// <summary>
        /// 导航控件排序
        /// </summary>
        public int nav_or { get; set; }
        /// <summary>
        /// 导航控件图片
        /// </summary>
        public string nav_pic { get; set; }
        /// <summary>
        /// 导航控件事件
        /// </summary>
        public string nav_event { get; set; }
        /// <summary>
        /// 导航控件事件
        /// </summary>
        public int margin_left { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public int delete_mk { get; set; }
    }
}
