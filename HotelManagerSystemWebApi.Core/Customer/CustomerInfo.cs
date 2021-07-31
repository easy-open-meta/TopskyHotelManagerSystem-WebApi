using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 客户信息表
    /// </summary>
    [Table("userinfo")]
    public class CustomerInfo : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public CustomerInfo()
        {
        }

        /// <summary>
        /// 用户编号
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.String CustoNo { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public System.String CustoName { get; set; }

        /// <summary>
        /// 用户性别
        /// </summary>
        public System.Int32 CustoSex { get; set; }

        /// <summary>
        /// 用户电话
        /// </summary>
        public System.String CustoTel { get; set; }

        /// <summary>
        /// 证照类型
        /// </summary>
        public System.Int32 PassportType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public System.String CustoID { get; set; }

        /// <summary>
        /// 居住地址
        /// </summary>
        public System.String CustoAdress { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public System.DateTime CustoBirth { get; set; }

        /// <summary>
        /// 客户类型
        /// </summary>
        public System.Int32 CustoType { get; set; }

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
