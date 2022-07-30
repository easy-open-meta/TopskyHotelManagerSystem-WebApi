﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 员工打卡考勤
    /// </summary>
    public class Temp_WorkerCheck
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public string WorkerNo { get; set; }
        /// <summary>
        /// 打卡时间
        /// </summary>
        public DateTime CheckTime { get; set; }
        /// <summary>
        /// 打卡方式
        /// </summary>
        public string CheckWay { get; set; }
        /// <summary>
        /// 打卡状态
        /// </summary>
        public int CheckState { get; set; }

        /// <summary>
        /// 打卡状态
        /// </summary>
        public string CheckStateNm { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public int delete_mk { get; set; }
        /// <summary>
        /// 资料创建人
        /// </summary>
        public string datains_usr { get; set; }
        /// <summary>
        /// 资料创建时间
        /// </summary>
        public DateTime datains_date { get; set; }
        /// <summary>
        /// 资料更新人
        /// </summary>
        public string datachg_usr { get; set; }
        /// <summary>
        /// 资料更新时间
        /// </summary>
        public DateTime datachg_date { get; set; }

    }
}
