/*
 * MIT License
 *Copyright (c) 2021 易开元(Easy-Open-Meta)

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
 */
using CK.Common;
using EOM.TSHotelManager.Common.Core;
using EOM.TSHotelManager.EntityFramework;
using SqlSugar;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 基础信息接口实现类
    /// </summary>
    public class BaseService : IBaseService
    {
        /// <summary>
        /// 员工信息
        /// </summary>
        private readonly PgRepository<Worker> workerRepository;

        /// <summary>
        /// 性别类型
        /// </summary>
        private readonly PgRepository<SexType> sexTypeRepository;

        /// <summary>
        /// 学历类型
        /// </summary>
        private readonly PgRepository<Education> educationRepository;

        /// <summary>
        /// 民族类型
        /// </summary>
        private readonly PgRepository<Nation> nationRepository;

        /// <summary>
        /// 部门
        /// </summary>
        private readonly PgRepository<Dept> deptRepository;

        /// <summary>
        /// 职务
        /// </summary>
        private readonly PgRepository<Position> positionRepository;

        /// <summary>
        /// 证件类型
        /// </summary>
        private readonly PgRepository<PassPortType> passPortTypeRepository;

        /// <summary>
        /// 客户类型
        /// </summary>
        private readonly PgRepository<CustoType> custoTypeRepository;

        /// <summary>
        /// 奖惩类型
        /// </summary>
        private readonly PgRepository<GBType> goodbadTypeRepository;

        /// <summary>
        /// 基础URL
        /// </summary>
        private readonly PgRepository<Base> baseRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workerRepository"></param>
        /// <param name="sexTypeRepository"></param>
        /// <param name="educationRepository"></param>
        /// <param name="nationRepository"></param>
        /// <param name="deptRepository"></param>
        /// <param name="positionRepository"></param>
        /// <param name="passPortTypeRepository"></param>
        /// <param name="custoTypeRepository"></param>
        /// <param name="goodbadTypeRepository"></param>
        /// <param name="baseRepository"></param>
        public BaseService(PgRepository<Worker> workerRepository, PgRepository<SexType> sexTypeRepository, PgRepository<Education> educationRepository, PgRepository<Nation> nationRepository, PgRepository<Dept> deptRepository, PgRepository<Position> positionRepository, PgRepository<PassPortType> passPortTypeRepository, PgRepository<CustoType> custoTypeRepository, PgRepository<GBType> goodbadTypeRepository, PgRepository<Base> baseRepository)
        {
            this.workerRepository = workerRepository;
            this.sexTypeRepository = sexTypeRepository;
            this.educationRepository = educationRepository;
            this.nationRepository = nationRepository;
            this.deptRepository = deptRepository;
            this.positionRepository = positionRepository;
            this.passPortTypeRepository = passPortTypeRepository;
            this.custoTypeRepository = custoTypeRepository;
            this.goodbadTypeRepository = goodbadTypeRepository;
            this.baseRepository = baseRepository;
        }

        #region 性别模块

        /// <summary>
        /// 查询所有性别类型
        /// </summary>
        /// <returns></returns>
        public List<SexType> SelectSexTypeAll(SexType sexType = null)
        {
            var where = Expressionable.Create<SexType>();

            if (sexType != null && !sexType.delete_mk.IsNullOrEmpty())
            {
                where = where.And(a => a.delete_mk == sexType.delete_mk);
            }
            if (sexType != null && !sexType.sexName.IsNullOrEmpty())
            {
                where = where.And(a => a.sexName.Contains(sexType.sexName));
            }
            return sexTypeRepository.GetList(where.ToExpression());
        }

        /// <summary>
        /// 查询性别类型
        /// </summary>
        /// <returns></returns>
        public SexType SelectSexType(SexType sexType)
        {
            SexType sexTypes = new SexType();
            sexTypes = sexTypeRepository.GetSingle(a => a.sexId == sexType.sexId);
            return sexTypes;
        }

        /// <summary>
        /// 添加性别类型
        /// </summary>
        /// <param name="sexType"></param>
        /// <returns></returns>
        public bool AddSexType(SexType sexType)
        {
            return sexTypeRepository.Insert(sexType);
        }

        /// <summary>
        /// 删除性别类型
        /// </summary>
        /// <param name="sexType"></param>
        /// <returns></returns>
        public bool DelSexType(SexType sexType)
        {
            return sexTypeRepository.Update(a => new SexType()
            {
                delete_mk = sexType.delete_mk,
                datachg_usr = sexType.datachg_usr
            }, a => a.sexId == sexType.sexId);
        }

        /// <summary>
        /// 更新性别类型
        /// </summary>
        /// <param name="sexType"></param>
        /// <returns></returns>
        public bool UpdSexType(SexType sexType)
        {
            return sexTypeRepository.Update(a => new SexType()
            {
                sexName = sexType.sexName,
                datachg_usr = sexType.datachg_usr,
            }, a => a.sexId == sexType.sexId);
        }

        #endregion

        #region 职位模块

        /// <summary>
        /// 查询所有职位类型
        /// </summary>
        /// <returns></returns>
        public List<Position> SelectPositionAll(Position position = null)
        {
            var where = Expressionable.Create<Position>();

            if (position != null && !position.delete_mk.IsNullOrEmpty())
            {
                where = where.And(a => a.delete_mk == position.delete_mk);
            }
            if (position != null && !position.position_name.IsNullOrEmpty())
            {
                where = where.And(a => a.position_name.Contains(position.position_name));
            }
            return positionRepository.GetList(where.ToExpression());
        }

        /// <summary>
        /// 查询职位类型
        /// </summary>
        /// <returns></returns>
        public Position SelectPosition(Position position)
        {
            Position position1 = new Position();
            position1 = positionRepository.GetSingle(a => a.position_no == position.position_no);
            return position1;
        }

        /// <summary>
        /// 添加职位类型
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool AddPosition(Position position)
        {
            return positionRepository.Insert(position);
        }

        /// <summary>
        /// 删除职位类型
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool DelPosition(Position position)
        {
            return positionRepository.Update(a => new Position()
            {
                delete_mk = position.delete_mk,
                datachg_usr = position.datachg_usr
            }, a => a.position_no == position.position_no);
        }

        /// <summary>
        /// 更新职位类型
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool UpdPosition(Position position)
        {
            return positionRepository.Update(a => new Position()
            {
                position_name = position.position_name,
                datachg_usr = position.datachg_usr
            }, a => a.position_no == position.position_no);
        }

        #endregion

        #region 民族模块

        /// <summary>
        /// 查询所有民族类型
        /// </summary>
        /// <returns></returns>
        public List<Nation> SelectNationAll(Nation nation = null)
        {
            var where = Expressionable.Create<Nation>();

            if (nation != null && !nation.delete_mk.IsNullOrEmpty())
            {
                where = where.And(a => a.delete_mk == nation.delete_mk);
            }
            if (nation != null && !nation.nation_name.IsNullOrEmpty())
            {
                where = where.And(a => a.nation_name.Contains(nation.nation_name));
            }
            return nationRepository.GetList(where.ToExpression());
        }

        /// <summary>
        /// 查询民族类型
        /// </summary>
        /// <returns></returns>
        public Nation SelectNation(Nation nation)
        {
            Nation nation1 = new Nation();
            nation1 = nationRepository.GetSingle(a => a.nation_no.Equals(nation.nation_no));
            return nation1;
        }

        /// <summary>
        /// 添加民族类型
        /// </summary>
        /// <param name="nation"></param>
        /// <returns></returns>
        public bool AddNation(Nation nation)
        {
            return nationRepository.Insert(nation);
        }

        /// <summary>
        /// 删除民族类型
        /// </summary>
        /// <param name="nation"></param>
        /// <returns></returns>
        public bool DelNation(Nation nation)
        {
            return nationRepository.Update(a => new Nation()
            {
                delete_mk = nation.delete_mk,
                datachg_usr = nation.datachg_usr,
            }, a => a.nation_no.Equals(nation.nation_no));

        }

        /// <summary>
        /// 更新民族类型
        /// </summary>
        /// <param name="nation"></param>
        /// <returns></returns>
        public bool UpdNation(Nation nation)
        {
            return nationRepository.Update(a => new Nation()
            {
                nation_name = nation.nation_name,
                datachg_usr = nation.datachg_usr
            }, a => a.nation_no.Equals(nation.nation_no));
        }

        #endregion

        #region 学历模块

        /// <summary>
        /// 查询所有学历类型
        /// </summary>
        /// <returns></returns>
        public List<Education> SelectEducationAll(Education education = null)
        {
            var where = Expressionable.Create<Education>();

            if (education != null && !education.delete_mk.IsNullOrEmpty())
            {
                where = where.And(a => a.delete_mk == education.delete_mk);
            }
            if (education != null && !education.education_name.IsNullOrEmpty())
            {
                where = where.And(a => a.education_name.Contains(education.education_name));
            }
            return educationRepository.GetList(where.ToExpression());
        }

        /// <summary>
        /// 查询学历类型
        /// </summary>
        /// <returns></returns>
        public Education SelectEducation(Education education)
        {
            Education education1 = new Education();
            education1 = educationRepository.GetSingle(a => a.education_no == education.education_no);
            return education1;
        }

        /// <summary>
        /// 添加学历类型
        /// </summary>
        /// <param name="education"></param>
        /// <returns></returns>
        public bool AddEducation(Education education)
        {
            return educationRepository.Insert(education);
        }

        /// <summary>
        /// 删除学历类型
        /// </summary>
        /// <param name="education"></param>
        /// <returns></returns>
        public bool DelEducation(Education education)
        {
            return educationRepository.Update(a => new Education()
            {
                delete_mk = education.delete_mk,
                datachg_usr = education.datachg_usr
            }, a => a.education_no == education.education_no);
        }

        /// <summary>
        /// 更新学历类型
        /// </summary>
        /// <param name="education"></param>
        /// <returns></returns>
        public bool UpdEducation(Education education)
        {
            return educationRepository.Update(a => new Education()
            {
                education_name = education.education_name,
                datachg_usr = education.datachg_usr
            }, a => a.education_no == education.education_no);
        }

        #endregion

        #region 部门模块

        /// <summary>
        /// 查询所有部门类型(可用)
        /// </summary>
        /// <returns></returns>
        public List<Dept> SelectDeptAllCanUse()
        {
            List<Worker> workers = new List<Worker>();
            workers = workerRepository.GetList(a => a.delete_mk != 1);
            List<Dept> depts = new List<Dept>();
            depts = deptRepository.GetList(a => a.delete_mk != 1);
            depts.ForEach(source =>
            {
                if (!source.dept_parent.IsNullOrEmpty())
                {
                    var dept = depts.FirstOrDefault(a => a.dept_no == source.dept_parent);
                    source.parent_name = dept == null || string.IsNullOrEmpty(dept.dept_name) ? "无" : dept.dept_name;
                }
                if (!source.dept_leader.IsNullOrEmpty())
                {
                    var leader = workers.FirstOrDefault(a => a.WorkerId == source.dept_leader);
                    source.leader_name = leader == null || string.IsNullOrEmpty(leader.WorkerName) ? "无" : leader.WorkerName;
                }

            });
            return depts;
        }

        /// <summary>
        /// 查询所有部门类型
        /// </summary>
        /// <returns></returns>
        public List<Dept> SelectDeptAll()
        {
            List<Worker> workers = new List<Worker>();
            workers = workerRepository.GetList(a => a.delete_mk != 1);
            List<Dept> depts = new List<Dept>();
            depts = deptRepository.GetList(a => a.delete_mk != 1);
            depts.ForEach(source =>
            {
                var dept = depts.FirstOrDefault(a => a.dept_no == source.dept_parent);
                source.parent_name = dept == null ? "" : dept.dept_name;
                var leader = workers.FirstOrDefault(a => source.dept_leader != null && a.WorkerId == source.dept_leader);
                source.leader_name = leader == null ? "" : leader.WorkerName;
            });
            return depts;
        }

        /// <summary>
        /// 查询部门类型
        /// </summary>
        /// <returns></returns>
        public Dept SelectDept(Dept dept)
        {
            Dept dept1 = new Dept();
            dept1 = deptRepository.GetSingle(a => a.dept_no.Equals(dept.dept_no));
            return dept1;
        }

        /// <summary>
        /// 添加部门类型
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        public bool AddDept(Dept dept)
        {
            return deptRepository.Insert(dept);
        }

        /// <summary>
        /// 删除部门类型
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        public bool DelDept(Dept dept)
        {
            if (dept.IsNullOrEmpty())
            {
                return false;
            }
            return deptRepository.Update(a => new Dept()
            {
                delete_mk = 1,
                datachg_usr = dept.datachg_usr
            }, a => a.dept_no == dept.dept_no);
        }

        /// <summary>
        /// 更新部门类型
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        public bool UpdDept(Dept dept)
        {
            return deptRepository.Update(a => new Dept()
            {
                dept_name = dept.dept_name,
                dept_desc = dept.dept_desc,
                dept_leader = dept.dept_leader,
                dept_parent = dept.dept_parent,
                datachg_usr = dept.datachg_usr
            }, a => a.dept_no == dept.dept_no);
        }

        #endregion

        #region 客户类型模块

        /// <summary>
        /// 查询所有客户类型(可用)
        /// </summary>
        /// <returns></returns>
        public List<CustoType> SelectCustoTypeAllCanUse()
        {
            List<CustoType> custoTypes = new List<CustoType>();
            custoTypes = custoTypeRepository.GetList(a => a.delete_mk != 1);
            return custoTypes;
        }

        /// <summary>
        /// 查询所有客户类型
        /// </summary>
        /// <returns></returns>
        public List<CustoType> SelectCustoTypeAll()
        {
            List<CustoType> custoTypes = new List<CustoType>();
            custoTypes = custoTypeRepository.GetList();
            return custoTypes;
        }

        /// <summary>
        /// 根据客户类型ID查询类型名称
        /// </summary>
        /// <param name="custoType"></param>
        /// <returns></returns>
        public CustoType SelectCustoTypeByTypeId(CustoType custoType)
        {
            CustoType custoTypes = new CustoType();
            custoType = custoTypeRepository.GetSingle(a => a.UserType == custoType.UserType && a.delete_mk != 1);
            return custoTypes;
        }

        /// <summary>
        /// 添加客户类型
        /// </summary>
        /// <param name="custoType"></param>
        /// <returns></returns>
        public bool InsertCustoType(CustoType custoType)
        {
            return custoTypeRepository.Insert(custoType);
        }

        /// <summary>
        /// 删除客户类型
        /// </summary>
        /// <param name="custoType"></param>
        /// <returns></returns>
        public bool DeleteCustoType(CustoType custoType)
        {
            return custoTypeRepository.Update(a => new CustoType()
            {
                delete_mk = 1,
                datachg_usr = custoType.datachg_usr
            }, a => a.UserType == custoType.UserType);
        }

        /// <summary>
        /// 更新客户类型
        /// </summary>
        /// <param name="custoType"></param>
        /// <returns></returns>
        public bool UpdateCustoType(CustoType custoType)
        {
            return custoTypeRepository.Update(a => new CustoType()
            {
                TypeName = custoType.TypeName,
                datachg_usr = custoType.datachg_usr
            }, a => a.UserType == custoType.UserType);
        }

        #endregion

        #region 证件类型模块

        /// <summary>
        /// 查询所有证件类型(可用)
        /// </summary>
        /// <returns></returns>
        public List<PassPortType> SelectPassPortTypeAllCanUse()
        {
            List<PassPortType> passPortTypes = new List<PassPortType>();
            passPortTypes = passPortTypeRepository.GetList(a => a.delete_mk != 1);
            return passPortTypes;
        }

        /// <summary>
        /// 查询所有证件类型
        /// </summary>
        /// <returns></returns>
        public List<PassPortType> SelectPassPortTypeAll()
        {
            List<PassPortType> passPortTypes = new List<PassPortType>();
            passPortTypes = passPortTypeRepository.GetList();
            return passPortTypes;
        }

        /// <summary>
        /// 根据证件类型ID查询类型名称
        /// </summary>
        /// <param name="passPortType"></param>
        /// <returns></returns>
        public PassPortType SelectPassPortTypeByTypeId(PassPortType passPortType)
        {
            PassPortType passPortType1 = new PassPortType();
            passPortType1 = passPortTypeRepository.GetSingle(a => a.PassportId == passPortType.PassportId && a.delete_mk != 1);
            return passPortType1;
        }

        /// <summary>
        /// 添加证件类型
        /// </summary>
        /// <param name="passPortType"></param>
        /// <returns></returns>
        public bool InsertPassPortType(PassPortType passPortType)
        {
            return passPortTypeRepository.Insert(passPortType);
        }

        /// <summary>
        /// 删除证件类型
        /// </summary>
        /// <param name="portType"></param>
        /// <returns></returns>
        public bool DeletePassPortType(PassPortType portType)
        {
            return passPortTypeRepository.Update(a => new PassPortType()
            {
                delete_mk = 1,
                datachg_usr = portType.datachg_usr,
            }, a => a.PassportId == portType.PassportId);
        }

        /// <summary>
        /// 更新证件类型
        /// </summary>
        /// <param name="portType"></param>
        /// <returns></returns>
        public bool UpdatePassPortType(PassPortType portType)
        {
            return passPortTypeRepository.Update(a => new PassPortType()
            {
                PassportName = portType.PassportName,
                datachg_usr = portType.datachg_usr
            }, a => a.PassportId == portType.PassportId);
        }

        #endregion

        #region 奖惩类型模块

        /// <summary>
        /// 查询所有奖惩类型(可用)
        /// </summary>
        /// <returns></returns>
        public List<GBType> SelectGBTypeAllCanUse()
        {
            List<GBType> gBTypes = new List<GBType>();
            gBTypes = goodbadTypeRepository.GetList(a => a.delete_mk != 1);
            return gBTypes;
        }

        /// <summary>
        /// 查询所有奖惩类型
        /// </summary>
        /// <returns></returns>
        public List<GBType> SelectGBTypeAll()
        {
            List<GBType> gBTypes = new List<GBType>();
            gBTypes = goodbadTypeRepository.GetList();
            return gBTypes;
        }

        /// <summary>
        /// 根据奖惩类型ID查询类型名称
        /// </summary>
        /// <param name="gBType"></param>
        /// <returns></returns>
        public GBType SelectGBTypeByTypeId(GBType gBType)
        {
            GBType gBType1 = new GBType();
            gBType1 = goodbadTypeRepository.GetSingle(a => a.GBTypeId == gBType.GBTypeId && a.delete_mk != 1);
            return gBType1;
        }

        /// <summary>
        /// 添加奖惩类型
        /// </summary>
        /// <param name="gBType"></param>
        /// <returns></returns>
        public bool InsertGBType(GBType gBType)
        {
            return goodbadTypeRepository.Insert(gBType);
        }

        /// <summary>
        /// 删除奖惩类型
        /// </summary>
        /// <param name="gBType"></param>
        /// <returns></returns>
        public bool DeleteGBType(GBType gBType)
        {
            return goodbadTypeRepository.Update(a => new GBType()
            {
                delete_mk = 1,
                datachg_usr = gBType.datachg_usr,
            }, a => a.GBTypeId == gBType.GBTypeId);
        }

        /// <summary>
        /// 更新奖惩类型
        /// </summary>
        /// <param name="gBType"></param>
        /// <returns></returns>
        public bool UpdateGBType(GBType gBType)
        {
            return goodbadTypeRepository.Update(a => new GBType()
            {
                GBName = gBType.GBName,
                datachg_usr = gBType.datachg_usr
            }, a => a.GBTypeId == gBType.GBTypeId);
        }

        #endregion

        #region URL模块
        /// <summary>
        /// 基础URL
        /// </summary>
        /// <returns></returns>
        public Base GetBase()
        {
            var baseTemp = new Base();

            baseTemp = baseRepository.GetSingle(a => a.url_no == 1);

            return baseTemp;
        }
        #endregion
    }
}
