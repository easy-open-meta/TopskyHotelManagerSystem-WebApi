using EOM.TSHotelManager.Application;
using EOM.TSHotelManager.Common.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EOM.TSHotelManager.WebApi.Controllers
{
    /// <summary>
    /// 基础信息控制器
    /// </summary>
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// 基础信息
        /// </summary>
        private readonly IBaseService baseService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseService"></param>
        public BaseController(IBaseService baseService)
        {
            this.baseService = baseService;
        }

        #region 性别模块

        /// <summary>
        /// 查询所有性别类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<SexType> SelectSexTypeAll([FromQuery] SexType sexType = null)
        {
            return baseService.SelectSexTypeAll(sexType);
        }

        /// <summary>
        /// 查询性别类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public SexType SelectSexType([FromQuery] SexType sexType)
        {
            return baseService.SelectSexType(sexType);
        }

        /// <summary>
        /// 添加性别类型
        /// </summary>
        /// <param name="sexType"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddSexType([FromBody] SexType sexType)
        {
            return baseService.AddSexType(sexType);
        }

        /// <summary>
        /// 删除性别类型
        /// </summary>
        /// <param name="sexType"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DelSexType([FromBody] SexType sexType)
        {
            return baseService.DelSexType(sexType);
        }

        /// <summary>
        /// 更新性别类型
        /// </summary>
        /// <param name="sexType"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdSexType([FromBody] SexType sexType)
        {
            return baseService.UpdSexType(sexType);
        }

        #endregion

        #region 职位模块

        /// <summary>
        /// 查询所有职位类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Position> SelectPositionAll([FromQuery] Position position = null)
        {
            return baseService.SelectPositionAll(position);
        }

        /// <summary>
        /// 查询职位类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Position SelectPosition([FromQuery] Position position)
        {
            return baseService.SelectPosition(position);
        }

        /// <summary>
        /// 添加职位类型
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddPosition([FromBody] Position position)
        {
            return baseService.AddPosition(position);
        }

        /// <summary>
        /// 删除职位类型
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DelPosition([FromBody] Position position)
        {
            return baseService.DelPosition(position);
        }

        /// <summary>
        /// 更新职位类型
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdPosition([FromBody] Position position)
        {
            return baseService.UpdPosition(position);
        }

        #endregion

        #region 民族模块

        /// <summary>
        /// 查询所有民族类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Nation> SelectNationAll([FromQuery] Nation nation = null)
        {
            return baseService.SelectNationAll(nation);
        }

        /// <summary>
        /// 查询民族类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Nation SelectNation([FromQuery] Nation nation)
        {
            return baseService.SelectNation(nation);
        }

        /// <summary>
        /// 添加民族类型
        /// </summary>
        /// <param name="nation"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddNation([FromBody] Nation nation)
        {
            return baseService.AddNation(nation);
        }

        /// <summary>
        /// 删除民族类型
        /// </summary>
        /// <param name="nation"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DelNation([FromBody] Nation nation)
        {
            return baseService.DelNation(nation);
        }

        /// <summary>
        /// 更新民族类型
        /// </summary>
        /// <param name="nation"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdNation([FromBody] Nation nation)
        {
            return baseService.UpdNation(nation);
        }

        #endregion

        #region 学历模块

        /// <summary>
        /// 查询所有学历类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Education> SelectEducationAll([FromQuery] Education education = null)
        {
            return baseService.SelectEducationAll(education);
        }

        /// <summary>
        /// 查询学历类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Education SelectEducation([FromQuery] Education education)
        {
            return baseService.SelectEducation(education);
        }

        /// <summary>
        /// 添加学历类型
        /// </summary>
        /// <param name="education"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddEducation([FromBody] Education education)
        {
            return baseService.AddEducation(education);
        }

        /// <summary>
        /// 删除学历类型
        /// </summary>
        /// <param name="education"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DelEducation([FromBody] Education education)
        {
            return baseService.DelEducation(education);
        }

        /// <summary>
        /// 更新学历类型
        /// </summary>
        /// <param name="education"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdEducation([FromBody] Education education)
        {
            return baseService.UpdEducation(education);
        }

        #endregion

        #region 部门模块

        /// <summary>
        /// 查询所有部门类型(可用)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Dept> SelectDeptAllCanUse()
        {
            return baseService.SelectDeptAllCanUse();
        }

        /// <summary>
        /// 查询所有部门类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Dept> SelectDeptAll()
        {
            return baseService.SelectDeptAll();
        }

        /// <summary>
        /// 查询部门类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Dept SelectDept([FromQuery] Dept dept)
        {
            return baseService.SelectDept(dept);
        }

        /// <summary>
        /// 添加部门类型
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddDept([FromBody] Dept dept)
        {
            return baseService.AddDept(dept);
        }

        /// <summary>
        /// 删除部门类型
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DelDept([FromBody] Dept dept)
        {
            return baseService.DelDept(dept);
        }

        /// <summary>
        /// 更新部门类型
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdDept([FromBody] Dept dept)
        {
            return baseService.UpdDept(dept);
        }

        #endregion

        #region 客户类型模块

        /// <summary>
        /// 查询所有客户类型(可用)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CustoType> SelectCustoTypeAllCanUse()
        {
            return baseService.SelectCustoTypeAllCanUse();
        }

        /// <summary>
        /// 查询所有客户类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CustoType> SelectCustoTypeAll()
        {
            return baseService.SelectCustoTypeAll();
        }

        /// <summary>
        /// 根据客户类型ID查询类型名称
        /// </summary>
        /// <param name="custoType"></param>
        /// <returns></returns>
        [HttpGet]
        public CustoType SelectCustoTypeByTypeId([FromQuery] CustoType custoType)
        {
            return baseService.SelectCustoTypeByTypeId(custoType);
        }

        /// <summary>
        /// 添加客户类型
        /// </summary>
        /// <param name="custoType"></param>
        /// <returns></returns>
        [HttpPost]
        public bool InsertCustoType([FromBody] CustoType custoType)
        {
            return baseService.InsertCustoType(custoType);
        }

        /// <summary>
        /// 删除客户类型
        /// </summary>
        /// <param name="custoType"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DeleteCustoType([FromBody] CustoType custoType)
        {
            return baseService.DeleteCustoType(custoType);
        }

        /// <summary>
        /// 更新客户类型
        /// </summary>
        /// <param name="custoType"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateCustoType([FromBody] CustoType custoType)
        {
            return baseService.UpdateCustoType(custoType);
        }

        #endregion

        #region 证件类型模块

        /// <summary>
        /// 查询所有证件类型(可用)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<PassPortType> SelectPassPortTypeAllCanUse()
        {
            return baseService.SelectPassPortTypeAllCanUse();
        }

        /// <summary>
        /// 查询所有证件类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<PassPortType> SelectPassPortTypeAll()
        {
            return baseService.SelectPassPortTypeAll();
        }

        /// <summary>
        /// 根据证件类型ID查询类型名称
        /// </summary>
        /// <param name="passPortType"></param>
        /// <returns></returns>
        [HttpGet]
        public PassPortType SelectPassPortTypeByTypeId([FromQuery] PassPortType passPortType)
        {
            return baseService.SelectPassPortTypeByTypeId(passPortType);
        }

        /// <summary>
        /// 添加证件类型
        /// </summary>
        /// <param name="passPortType"></param>
        /// <returns></returns>
        [HttpPost]
        public bool InsertPassPortType([FromBody] PassPortType passPortType)
        {
            return baseService.InsertPassPortType(passPortType);
        }

        /// <summary>
        /// 删除证件类型
        /// </summary>
        /// <param name="portType"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DeletePassPortType([FromBody] PassPortType portType)
        {
            return baseService.DeletePassPortType(portType);
        }

        /// <summary>
        /// 更新证件类型
        /// </summary>
        /// <param name="portType"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdatePassPortType([FromBody] PassPortType portType)
        {
            return baseService.UpdatePassPortType(portType);
        }

        #endregion

        #region 奖惩类型模块

        /// <summary>
        /// 查询所有奖惩类型(可用)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<GBType> SelectGBTypeAllCanUse()
        {
            return baseService.SelectGBTypeAllCanUse();
        }

        /// <summary>
        /// 查询所有奖惩类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<GBType> SelectGBTypeAll()
        {
            return baseService.SelectGBTypeAll();
        }

        /// <summary>
        /// 根据奖惩类型ID查询类型名称
        /// </summary>
        /// <param name="gBType"></param>
        /// <returns></returns>
        [HttpGet]
        public GBType SelectGBTypeByTypeId([FromQuery] GBType gBType)
        {
            return baseService.SelectGBTypeByTypeId(gBType);
        }

        /// <summary>
        /// 添加奖惩类型
        /// </summary>
        /// <param name="gBType"></param>
        /// <returns></returns>
        [HttpPost]
        public bool InsertGBType([FromBody] GBType gBType)
        {
            return baseService.InsertGBType(gBType);
        }

        /// <summary>
        /// 删除奖惩类型
        /// </summary>
        /// <param name="gBType"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DeleteGBType([FromBody] GBType gBType)
        {
            return baseService.DeleteGBType(gBType);
        }

        /// <summary>
        /// 更新奖惩类型
        /// </summary>
        /// <param name="gBType"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateGBType([FromBody] GBType gBType)
        {
            return baseService.UpdateGBType(gBType);
        }

        #endregion

        #region URL模块
        /// <summary>
        /// 基础URL
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Base GetBase()
        {
            return baseService.GetBase();
        }
        #endregion
    }
}
