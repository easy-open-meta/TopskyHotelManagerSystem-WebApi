using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.LinqBuilder;
using HotelManagerSystemWebApi.Core;
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
    {
        /// <summary>
        /// 管理员信息仓储
        /// </summary>
        private readonly IRepository<AdminInfo> adminInfoRepository;

        /// <summary>
        /// 构造函数
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
    }
}
