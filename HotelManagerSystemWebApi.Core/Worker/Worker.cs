using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 员工信息表
    /// </summary>
    [Table("worker")]
    public class Worker : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Worker()
        {
        }

        /// <summary>
        /// 工号
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.String WorkerId { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public System.String WorkerName { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public System.DateTime WorkerBirthday { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public System.Int32 WorkerSex { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public System.String WorkerTel { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public System.String WorkerClub { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public System.String WorkerNation { get; set; }

        /// <summary>
        /// 居住地址
        /// </summary>
        public System.String WorkerAddress { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public System.String WorkerPosition { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public System.String CardID { get; set; }

        /// <summary>
        /// 系统密码
        /// </summary>
        public System.String WorkerPwd { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        public System.DateTime WorkerTime { get; set; }

        /// <summary>
        /// 面貌
        /// </summary>
        public System.String WorkerFace { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        public System.String WorkerEducation { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public System.UInt32? delete_mk { get; set; }

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
