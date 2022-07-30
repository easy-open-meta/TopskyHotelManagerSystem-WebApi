using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 管理员信息实体类
    /// </summary>
    public class Temp_AdminInfo
    {

        /// <summary>
        /// 管理员账号
        /// </summary>
        public System.String AdminAccount { get; set; }

        /// <summary>
        /// 管理员密码
        /// </summary>
        public System.String AdminPassword { get; set; }

        /// <summary>
        /// 管理员类型
        /// </summary>
        public System.String AdminType { get; set; }

        /// <summary>
        /// 管理员名称
        /// </summary>
        public System.String AdminName { get; set; }

        /// <summary>
        /// 是否为超级管理员
        /// </summary>
        public System.Int32? IsAdmin { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public System.Int32? DeleteMk { get; set; }

        /// <summary>
        /// 资料新增人
        /// </summary>
        public System.String datains_usr { get; set; }

        /// <summary>
        /// 资料新增时间
        /// </summary>
        public System.DateTime? datains_time { get; set; }

        /// <summary>
        /// 资料更新人
        /// </summary>
        public System.String datachg_usr { get; set; }

        /// <summary>
        /// 资料更新时间
        /// </summary>
        public System.DateTime? datachg_time { get; set; }
    }
}
