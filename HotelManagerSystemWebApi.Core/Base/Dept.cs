using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 部门信息表
    /// </summary>
    [Table("dept")]
    public class Dept : IEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Dept()
        {
        }

        /// <summary>
        /// 部门编号
        /// </summary>
        [Key]
        [Column("dept_no",Order = 1)]
        public System.String DeptNo { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [Column("dept_name")]
        public System.String DeptName { get; set; }

        /// <summary>
        /// 部门描述
        /// </summary>
        [Column("dept_desc")]
        public System.String DeptDesc { get; set; }

        /// <summary>
        /// 创建时间(部门)
        /// </summary>
        [Column("dept_date")]
        public System.DateTime? DeptDate { get; set; }

        /// <summary>
        /// 部门主管
        /// </summary>
        [Column("dept_leader")]
        public System.String DeptLeader { get; set; }

        /// <summary>
        /// 上级部门
        /// </summary>
        [Column("dept_parent")]
        public System.String DeptParent { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        [Column("delete_mk")]
        public System.Int32 DeleteMk { get; set; }

        /// <summary>
        /// 资料创建人
        /// </summary>
        [Column("datains_usr")]
        public System.String DatainsUsr { get; set; }

        /// <summary>
        /// 资料创建时间
        /// </summary>
        [Column("datains_date")]
        public System.DateTime? DatainsDate { get; set; }

        /// <summary>
        /// 资料更新人
        /// </summary>
        [Column("datachg_usr")]
        public System.String DatachgUsr { get; set; }

        /// <summary>
        /// 资料更新时间
        /// </summary>
        [Column("datachg_date")]
        public System.DateTime? DatachgDate { get; set; }
    }
}
