using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOM.TSHotelManager.Common.Core
{
    /// <summary>
    /// 应用版本
    /// </summary>
    [SqlSugar.SugarTable("applicationversion")]
    public class Applicationversion
    {
        /// <summary>
        /// 流水号
        /// </summary>
        [SugarColumn(ColumnName = "base_versionId")]//数据库是自增才配自增
        public int base_versionId { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [SugarColumn(ColumnName = "base_version")]//数据库是自增才配自增
        public string base_version { get; set; }
    }
}
