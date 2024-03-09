namespace EOM.TSHotelManager.Common.Core
{
    /// <summary>
    /// 模块实体
    /// </summary>
    [SqlSugar.SugarTable("module")]
    public class Module : BaseDTO
    {
        /// <summary>
        /// 模块ID
        /// </summary>
        public int module_id { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string module_name { get; set; }

        /// <summary>
        /// 模块描述
        /// </summary>
        public string module_desc { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public int delete_mk { get; set; }
    }
}
