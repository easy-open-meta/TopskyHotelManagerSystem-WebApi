/*
 * MIT License
 *Copyright (c) 2021 咖啡与网络(java-and-net)

 *Permission is hereby granted, free of charge, to any person obtaining a copy
 *of this software and associated documentation files (the "Software"), to deal
 *in the Software without restriction, including without limitation the rights
 *to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *copies of the Software, and to permit persons to whom the Software is
 *furnished to do so, subject to the following conditions:

 *The above copyright notice and this permission notice shall be included in all
 *copies or substantial portions of the Software.

 *THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *SOFTWARE.
 *
 *模块说明：员工信息类
 */
using Furion.DatabaseAccessor;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 员工信息
    /// </summary>
    [Table("worker")]
    public class Worker : IEntity
    {
        /// <summary>
        /// 员工账号/工号
        /// </summary>
        [Column("WorkerId")]
        public string WorkerId { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        [Column("WorkerName")]
        public string WorkerName { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        [Column("WorkerBirthday")]
        public DateTime WorkerBirthday { get; set; }
        /// <summary>
        /// 员工性别
        /// </summary>
        [Column("WorkerSex")]
        public int WorkerSex { get; set; }
        ///// <summary>
        ///// 员工性别(名称描述)
        ///// </summary>
        //[SqlSugar.SugarColumn(IsIgnore = true)]
        //public string WorkerSexName { get; set; }
        /// <summary>
        /// 民族类型
        /// </summary>
        [Column("WorkerNation")]
        public string WorkerNation { get; set; }
        ///// <summary>
        ///// 民族名称
        ///// </summary>
        //[SqlSugar.SugarColumn(IsIgnore = true)]
        //public string NationName { get; set; }
        /// <summary>
        /// 员工电话
        /// </summary>
        [Column("WorkerTel")]
        public string WorkerTel { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        [Column("WorkerClub")]
        public string WorkerClub { get; set; }
        ///// <summary>
        ///// 部门名称
        ///// </summary>
        //[SqlSugar.SugarColumn(IsIgnore = true)]
        //public string ClubName { get; set; }
        /// <summary>
        /// 居住地址
        /// </summary>
        [Column("WorkerAddress")]
        public string WorkerAddress { get; set; }
        /// <summary>
        /// 员工职位
        /// </summary>
        [Column("WorkerPosition")]
        public string WorkerPosition { get; set; }
        ///// <summary>
        ///// 职位名称
        ///// </summary>
        //[SqlSugar.SugarColumn(IsIgnore = true)]
        //public string PositionName { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        [Column("CardID")]
        public string CardId { get; set; }
        /// <summary>
        /// 员工密码
        /// </summary>
        [Column("WorkerPwd")]
        public string WorkerPwd { get; set; }
        /// <summary>
        /// 员工入职时间
        /// </summary>
        public DateTime WorkerTime { get; set; }
        /// <summary>
        /// 员工面貌
        /// </summary>
        public string WorkerFace { get; set; }
        ///// <summary>
        ///// 群众面貌描述
        ///// </summary>
        //[SqlSugar.SugarColumn(IsIgnore = true)]
        //public string FaceName { get; set; }
        /// <summary>
        /// 教育程度
        /// </summary>
        public string WorkerEducation { get; set; }
        ///// <summary>
        ///// 教育程度名称
        ///// </summary>
        //[SqlSugar.SugarColumn(IsIgnore = true)]
        //public string EducationName { get; set; }
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
