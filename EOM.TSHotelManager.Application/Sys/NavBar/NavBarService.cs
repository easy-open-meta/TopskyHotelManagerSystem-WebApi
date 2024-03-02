using EOM.TSHotelManager.Common.Core;
using EOM.TSHotelManager.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 导航控件模块
    /// </summary>
    public class NavBarService:INavBarService
    {
        /// <summary>
        /// 导航控件
        /// </summary>
        private readonly PgRepository<NavBar> navBarRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="navBarRepository"></param>
        public NavBarService(PgRepository<NavBar> navBarRepository)
        {
            this.navBarRepository = navBarRepository;
        }

        /// <summary>
        /// 导航控件列表
        /// </summary>
        /// <returns></returns>
        public List<NavBar> NavBarList()
        {
            var navBarList = navBarRepository.GetList(a => a.delete_mk != 1);

            return navBarList;
        }
    }
}
