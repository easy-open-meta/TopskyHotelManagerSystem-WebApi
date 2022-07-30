using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.LinqBuilder;
using HotelManagerSystemWebApi.Core;
using jvncorelib.EncryptorLib;
using jvncorelib.EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 管理员信息模块接口实现
    /// </summary>
    public class AdminInfoService: IAdminInfoService, ITransient 
        //笔记：如果把Migrations层删除后使用瞬时服务，必须让EntityFramework.Core层被Web.Core层引用，否则会导致服务无法被正常识别
    {
        /// <summary>
        /// 管理员信息仓储
        /// </summary>
        private readonly IRepository<AdminInfo> adminInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminInfoRepository"></param>
        public AdminInfoService(IRepository<AdminInfo> adminInfoRepository)
        {
            this.adminInfoRepository = adminInfoRepository;
        }

        /// <summary>
        /// 查询管理员信息列表
        /// </summary>
        /// <param name="adminInfoListDto"></param>
        /// <returns></returns>
        public OAdminInfoListDto AdminInfoList(AdminInfoListDto adminInfoListDto)
        {
            OAdminInfoListDto oAdminInfoListDto = new OAdminInfoListDto();

            var where = LinqExpression.Create<AdminInfo>(a => a.DeleteMk != 1);

            //管理员名称
            if (!adminInfoListDto.AdminName.IsNullOrEmpty())
            {
                where = where.And(a => a.AdminName.Equals(adminInfoListDto.AdminName));
            }
            //是否为超级管理员
            if (!adminInfoListDto.IsAdmin.IsNullOrEmpty())
            {
                where = where.And(a => a.IsAdmin == adminInfoListDto.IsAdmin);
            }

            var listSource = adminInfoRepository.AsQueryable(where).Distinct().ToList();

            oAdminInfoListDto.listSource = listSource;

            oAdminInfoListDto.OK();

            return oAdminInfoListDto;
        }

        /// <summary>
        /// 查询管理员信息
        /// </summary>
        /// <param name="adminInfoDto"></param>
        /// <returns></returns>
        public OAdminInfoDto AdminInfo(AdminInfoDto adminInfoDto)
        {
            OAdminInfoDto oAdminInfoDto = new OAdminInfoDto();

            var where = LinqExpression.Create<AdminInfo>(a => a.DeleteMk != 1);

            //管理员账号
            if (!adminInfoDto.AdminAccount.IsNullOrEmpty())
            {
                where = where.And(a => a.AdminAccount.Equals(adminInfoDto.AdminAccount));
            }

            var source = adminInfoRepository.FirstOrDefault(where);

            if (source.IsNullOrEmpty())
            {
                oAdminInfoDto.Error_NotFound();
                return oAdminInfoDto;
            }

            oAdminInfoDto.source = source;
            oAdminInfoDto.OK();

            return oAdminInfoDto;
        }

        /// <summary>
        /// 添加管理员信息
        /// </summary>
        /// <param name="addAdminInfoDto"></param>
        /// <returns></returns>
        public OAddAdminInfoDto AddAdminInfo(AddAdminInfoDto addAdminInfoDto)
        {
            OAddAdminInfoDto oAddAdminInfoDto = new OAddAdminInfoDto();

            var where = LinqExpression.Create<AdminInfo>(a => a.DeleteMk != 1);

            //管理员账号
            if (!addAdminInfoDto.AdminAccount.IsNullOrEmpty())
            {
                where = where.And(a => a.AdminAccount.Equals(addAdminInfoDto.AdminAccount));
            }

            var source = adminInfoRepository.FirstOrDefault(where);

            if (!source.IsNullOrEmpty())
            {
                oAddAdminInfoDto.Error_Exist("该管理员已存在，无法添加");
                return oAddAdminInfoDto;
            }

            source = source.UpdateToModel(addAdminInfoDto);
            source.datains_usr = addAdminInfoDto.NowLoginUsr;
            source.datains_time = DateTime.Now;
            this.adminInfoRepository.Insert(source);

            oAddAdminInfoDto.OK();

            return oAddAdminInfoDto;
        }

        /// <summary>
        /// 删除管理员信息
        /// </summary>
        /// <param name="delAdminInfoDto"></param>
        /// <returns></returns>
        public ODelAdminInfoDto DelAdminInfo(DelAdminInfoDto delAdminInfoDto)
        {
            ODelAdminInfoDto oDelAdminInfoDto = new ODelAdminInfoDto();

            var where = LinqExpression.Create<AdminInfo>(a => a.DeleteMk != 1);

            //管理员账号
            if (!delAdminInfoDto.AdminAccount.IsNullOrEmpty())
            {
                where = where.And(a => a.AdminAccount.Equals(delAdminInfoDto.AdminAccount));
            }

            var source = adminInfoRepository.FirstOrDefault(where);

            if (source.IsNullOrEmpty())
            {
                oDelAdminInfoDto.Error_NotFound();
                return oDelAdminInfoDto;
            }

            this.adminInfoRepository.Delete(source);

            oDelAdminInfoDto.OK();

            return oDelAdminInfoDto;
        }

        /// <summary>
        /// 更新管理员信息
        /// </summary>
        /// <param name="updAdminInfoDto"></param>
        /// <returns></returns>
        public OUpdAdminInfoDto UpdAdminInfo(UpdAdminInfoDto updAdminInfoDto)
        {
            OUpdAdminInfoDto oUpdAdminInfoDto = new OUpdAdminInfoDto();

            var where = LinqExpression.Create<AdminInfo>(a => a.DeleteMk != 1);

            //管理员账号
            if (!updAdminInfoDto.AdminAccount.IsNullOrEmpty())
            {
                where = where.And(a => a.AdminAccount.Equals(updAdminInfoDto.AdminAccount));
            }

            var source = adminInfoRepository.FirstOrDefault(where);

            if (source.IsNullOrEmpty())
            {
                oUpdAdminInfoDto.Error_Exist();
                return oUpdAdminInfoDto;
            }

            source = source.UpdateToModel(updAdminInfoDto);
            source.datains_usr = updAdminInfoDto.NowLoginUsr;
            source.datains_time = DateTime.Now;
            this.adminInfoRepository.Update(source);
            oUpdAdminInfoDto.OK();
            return oUpdAdminInfoDto;
        }

        EncryptLib encryptLib = new EncryptLib();

        //#region 根据超管密码查询员工类型和权限
        ///// <summary>
        ///// 根据超管密码查询员工类型和权限
        ///// </summary>
        ///// <param name="admin"></param>
        ///// <returns></returns>
        //public Admin SelectMangerByPass(Admin admin)
        //{
        //    Admin admins = new Admin();
        //    admins = base.GetSingle(a => a.AdminAccount == admin.AdminAccount && a.AdminPassword == admin.AdminPassword);
        //    //admin.AdminPassword = admin.AdminPassword.Contains(":") ? encrypt.DeEncryptStr(admin.AdminPassword) : admin.AdminPassword;
        //    return admins;
        //}
        //#endregion

        //#region 根据超管账号查询对应的密码
        ///// <summary>
        ///// 根据超管账号查询对应的密码
        ///// </summary>
        ///// <param name="account"></param>
        ///// <returns></returns>
        //public Admin SelectAdminPwdByAccount(string account)
        //{
        //    Admin admin = new Admin();
        //    admin = base.GetSingle(a => a.AdminAccount == account);
        //    //admin.AdminPassword = admin.AdminPassword.Contains(":") ? encrypt.DeEncryptStr(admin.AdminPassword) : admin.AdminPassword;
        //    return admin;
        //}
        //#endregion

        ///// <summary>
        ///// 获取所有管理员列表
        ///// </summary>
        ///// <returns></returns>
        //public List<Admin> GetAllAdminList()
        //{
        //    var listAdmins = base.GetList();
        //    var listAdminType = base.Change<AdminType>().GetList(a => a.delete_mk != 1);
        //    listAdmins.ForEach(admins =>
        //    {
        //        var isAdminType = admins.IsAdmin == 1 ? "是" : "否";
        //        admins.IsAdminNm = isAdminType;

        //        var adminType = listAdminType.FirstOrDefault(a => a.type_id.Equals(admins.AdminType));
        //        admins.TypeName = adminType == null ? "" : adminType.type_name;

        //        var adminDelete = admins.DeleteMk == 1 ? "是" : "否";
        //        admins.DeleteNm = adminDelete;

        //    });

        //    return listAdmins;
        //}

        ///// <summary>
        ///// 修改密码
        ///// </summary>
        ///// <param name="admin"></param>
        ///// <returns></returns>
        //public bool UpdateNewPwdByOldPwd(Admin admin)
        //{
        //    //admin.AdminPassword = encrypt.EncryptStr(admin.AdminPassword);
        //    return base.Update(a => new Admin()
        //    {
        //        AdminPassword = admin.AdminPassword,
        //        datachg_usr = AdminInfo.Account,
        //        datachg_time = DateTime.Now
        //    }, a => a.AdminAccount == admin.AdminAccount);
        //}

        ///// <summary>
        ///// 获取管理员列表(已启用)
        ///// </summary>
        ///// <returns></returns>
        //public List<Admin> GetAllAdmin()
        //{
        //    var listAdmin = base.GetList(a => a.DeleteMk != 1);
        //    var listAdminType = base.Change<AdminType>().GetList(a => a.delete_mk != 1);
        //    listAdmin.ForEach(admin =>
        //    {
        //        var isAdminType = admin.IsAdmin == 1 ? "是" : "否";
        //        admin.IsAdminNm = isAdminType;

        //        var adminType = listAdminType.FirstOrDefault(a => a.type_id.Equals(admin.AdminType));
        //        admin.TypeName = adminType == null ? "" : adminType.type_name;
        //    });
        //    return listAdmin;
        //}

        ///// <summary>
        ///// 添加管理员
        ///// </summary>
        ///// <param name="admin"></param>
        ///// <returns></returns>
        //public bool AddAdmin(Admin admin)
        //{
        //    //admin.AdminPassword = encrypt.EncryptStr(admin.AdminPassword);
        //    bool result = base.Insert(admin);
        //    return result;
        //}

        ///// <summary>
        ///// 获取管理员信息
        ///// </summary>
        ///// <param name="admin"></param>
        ///// <returns></returns>
        //public Admin GetAdminInfoByAdminAccount(Admin admin)
        //{
        //    var adminInfo = base.GetSingle(a => a.AdminAccount.Equals(admin.AdminAccount));
        //    if (adminInfo != null)
        //    {
        //        var adminType = base.Change<AdminType>().GetSingle(a => a.type_id.Equals(adminInfo.AdminType));
        //        adminInfo.TypeName = adminType.type_name;
        //    }
        //    return adminInfo;
        //}

        ///// <summary>
        ///// 获取所有管理员类型
        ///// </summary>
        ///// <returns></returns>
        //public List<AdminType> GetAllAdminTypes()
        //{
        //    var listAdminTypes = base.Change<AdminType>().GetList(a => a.delete_mk != 1);
        //    return listAdminTypes;
        //}

        ///// <summary>
        ///// 更新管理员账户
        ///// </summary>
        ///// <param name="admins"></param>
        ///// <returns></returns>
        //public bool UpdAccount(Admin admins)
        //{
        //    admins.DeleteMk = admins.DeleteMk == 0 ? 1 : 0;
        //    return base.Update(a => new Admin()
        //    {
        //        DeleteMk = admins.DeleteMk
        //    }, a => a.Id == admins.Id);
        //}
    }
}
