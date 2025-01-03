﻿using EOM.TSHotelManager.Common.Core;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 工具类接口
    /// </summary>
    public interface IUtilService
    {
        /// <summary>
        /// 查询身份证号码
        /// </summary>
        /// <param name="identityCard"></param>
        /// <returns></returns>
        string SelectCardCode(string identityCard);

        /// <summary>
        /// 检测版本号
        /// </summary>
        /// <returns></returns>
        Applicationversion CheckBaseVersion();

        /// <summary>
        /// 添加操作日志
        /// </summary>
        /// <param name="opr"></param>
        /// <returns></returns>
        bool AddLog(OperationLog opr);

        /// <summary>
        /// 查询所有操作日志
        /// </summary>
        /// <returns></returns>
        OSelectAllDto<OperationLog> SelectOperationlogAll(int? pageIndex, int? pageSize);
    }
}
