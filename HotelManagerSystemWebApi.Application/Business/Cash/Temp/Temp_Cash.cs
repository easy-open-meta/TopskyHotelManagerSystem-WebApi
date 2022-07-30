using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 资产管理
    /// </summary>
    public class Temp_Cash
    {
        /// <summary>
        /// 资产编号
        /// </summary>
        public string CashNo { get; set; }
        /// <summary>
        /// 资产名称
        /// </summary>
        public string CashName { get; set; }
        /// <summary>
        /// 资产总值
        /// </summary>
        public decimal CashPrice { get; set; }
        /// <summary>
        /// 资产总值描述
        /// </summary>
        public string CashPriceStr { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        public string CashClub { get; set; }
        /// <summary>
        /// 所属部门描述
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime CashTime { get; set; }
        /// <summary>
        /// 资产来源
        /// </summary>
        public string CashSource { get; set; }
        /// <summary>
        /// 资产经办人
        /// </summary>
        public string CashPerson { get; set; }
        /// <summary>
        /// 资产经办人
        /// </summary>
        public string PersonName { get; set; }
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
        public DateTime? datains_date { get; set; }
        /// <summary>
        /// 资料更新人
        /// </summary>
        public string datachg_usr { get; set; }
        /// <summary>
        /// 资料更新时间
        /// </summary>
        public DateTime? datachg_date { get; set; }

    }
}
