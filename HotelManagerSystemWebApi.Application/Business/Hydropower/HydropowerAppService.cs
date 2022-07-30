using Furion.DynamicApiController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 水电信息控制器
    /// </summary>
    public  class HydropowerAppService:IDynamicApiController
    {
        /// <summary>
        /// 水电信息
        /// </summary>
        private readonly IHydropowerService hydropowerService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hydropowerService"></param>
        public HydropowerAppService(IHydropowerService hydropowerService)
        {
            this.hydropowerService = hydropowerService;
        }

        /// <summary>
        /// 获取所有水电费信息
        /// </summary>
        /// <returns></returns>
        public OSelectHydropowerInfoAllDto SelectHydropowerInfoAll(SelectHydropowerInfoAllDto selectHydropowerInfoAllDto)
        {
            return hydropowerService.SelectHydropowerInfoAll(selectHydropowerInfoAllDto);
        }

        /// <summary>
        /// 添加水电费信息
        /// </summary>
        /// <param name="insertHydropowerInfoDto"></param>
        /// <returns></returns>
        public OInsertHydropowerInfoDto InsertHydropowerInfo(InsertHydropowerInfoDto insertHydropowerInfoDto)
        {
            return hydropowerService.InsertHydropowerInfo(insertHydropowerInfoDto);
        }

        /// <summary>
        /// 修改水电费信息
        /// </summary>
        /// <param name="updateHydropowerInfoDto"></param>
        /// <returns></returns>
        public OUpdateHydropowerInfoDto UpdateHydropowerInfo(UpdateHydropowerInfoDto updateHydropowerInfoDto)
        {
            return hydropowerService.UpdateHydropowerInfo(updateHydropowerInfoDto);
        }
    }
}
