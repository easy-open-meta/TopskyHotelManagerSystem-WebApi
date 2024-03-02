using EOM.TSHotelManager.Common.Core;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 导航控件模块接口
    /// </summary>
    public interface INavBarService
    {
        /// <summary>
        /// 导航控件列表
        /// </summary>
        /// <returns></returns>
        List<NavBar> NavBarList();
    }
}