using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOM.TSHotelManager.Common.Core
{
    public class BaseDTO
    {
        /// <summary>
        /// 资料创建人
        /// </summary>
        [SqlSugar.SugarColumn(IsOnlyIgnoreUpdate = true)]
        public string datains_usr { get; set; }
        /// <summary>
        /// 资料创建时间
        /// </summary>
        [SqlSugar.SugarColumn(/*InsertServerTime = true,*/ IsOnlyIgnoreUpdate = true)]
        public DateTime? datains_date { get; set; }
        /// <summary>
        /// 资料更新人
        /// </summary>
        [SqlSugar.SugarColumn(IsOnlyIgnoreInsert = true)]
        public string datachg_usr { get; set; }
        /// <summary>
        /// 资料更新时间
        /// </summary>
        [SqlSugar.SugarColumn(/*UpdateServerTime = true,*/IsOnlyIgnoreInsert = true)]
        public DateTime? datachg_date { get; set; }

    }
}
