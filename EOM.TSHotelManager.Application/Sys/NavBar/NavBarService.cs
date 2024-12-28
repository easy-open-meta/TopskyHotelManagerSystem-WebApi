using EOM.TSHotelManager.Common.Core;
using EOM.TSHotelManager.EntityFramework;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 导航控件模块
    /// </summary>
    public class NavBarService : INavBarService
    {
        /// <summary>
        /// 导航控件
        /// </summary>
        private readonly GenericRepository<NavBar> navBarRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="navBarRepository"></param>
        public NavBarService(GenericRepository<NavBar> navBarRepository)
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
