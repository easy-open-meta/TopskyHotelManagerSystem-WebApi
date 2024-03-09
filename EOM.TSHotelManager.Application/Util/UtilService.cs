using EOM.TSHotelManager.Common.Core;
using EOM.TSHotelManager.EntityFramework;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 工具接口实现类
    /// </summary>
    public class UtilService : IUtilService
    {
        /// <summary>
        /// 卡片代码
        /// </summary>
        private readonly PgRepository<Cardcodes> cardCodesRepository;

        /// <summary>
        /// 应用检测
        /// </summary>
        private readonly PgRepository<Applicationversion> applicationRepository;

        /// <summary>
        /// 操作日志
        /// </summary>
        private readonly PgRepository<OperationLog> operationLogRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardCodesRepository"></param>
        /// <param name="applicationRepository"></param>
        /// <param name="operationLogRepository"></param>
        public UtilService(PgRepository<Cardcodes> cardCodesRepository, PgRepository<Applicationversion> applicationRepository, PgRepository<OperationLog> operationLogRepository)
        {
            this.cardCodesRepository = cardCodesRepository;
            this.applicationRepository = applicationRepository;
            this.operationLogRepository = operationLogRepository;
        }

        /// <summary>
        /// 查询身份证号码
        /// </summary>
        /// <param name="identityCard"></param>
        /// <returns></returns>
        public string SelectCardCode(string identityCard)
        {
            var cardid = identityCard.Substring(0, 6).ToString();
            var pcd = string.Empty;
            var cardcodes = cardCodesRepository.GetSingle(a => a.bm == cardid);
            pcd = cardcodes == null ? "" : string.Join(",", cardcodes.Province + cardcodes.City + cardcodes.District);
            return pcd;
        }

        /// <summary>
        /// 检测版本号
        /// </summary>
        /// <returns></returns>
        public Applicationversion CheckBaseVersion()
        {
            return applicationRepository.GetSingle(a => a.base_versionId == 1);
        }

        /// <summary>
        /// 添加操作日志
        /// </summary>
        /// <param name="opr"></param>
        /// <returns></returns>
        public bool AddLog(OperationLog opr)
        {
            return operationLogRepository.Insert(opr);
        }

        /// <summary>
        /// 查询所有操作日志
        /// </summary>
        /// <returns></returns>
        public List<OperationLog> SelectOperationlogAll()
        {
            List<OperationLog> operationLogs = new List<OperationLog>();
            operationLogs = operationLogRepository.GetList(a => a.delete_mk != 1).OrderByDescending(a => a.OperationTime).ToList();
            operationLogs.ForEach(source =>
            {
                source.OperationLevelNm = source.OperationLevel == RecordLevel.Normal ? "常规操作" : source.OperationLevel == RecordLevel.Warning ? "敏感操作" : "严重操作";
            });
            return operationLogs;
        }

    }
}
