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

            return oAdminInfoListDto;
        }
    }
}
