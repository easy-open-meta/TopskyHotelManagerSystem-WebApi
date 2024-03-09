namespace EOM.TSHotelManager.Common.Core
{
    /// <summary>
    /// 卡片代码
    /// </summary>
    [SqlSugar.SugarTable("cardcodes")]
    public class Cardcodes
    {
        /// <summary>
        /// 卡片代码
        /// </summary>
        public Cardcodes()
        {
        }

        private System.Int64 _id;
        /// <summary>
        /// 编号
        /// </summary>
        public System.Int64 id { get { return this._id; } set { this._id = value; } }

        private System.String _Province;
        /// <summary>
        /// 省份
        /// </summary>
        public System.String Province { get { return this._Province; } set { this._Province = value; } }

        private System.String _City;
        /// <summary>
        /// 城市
        /// </summary>
        public System.String City { get { return this._City; } set { this._City = value; } }

        private System.String _District;
        /// <summary>
        /// 地区
        /// </summary>
        public System.String District { get { return this._District; } set { this._District = value; } }

        private System.String _bm;
        /// <summary>
        /// 地区识别码
        /// </summary>
        public System.String bm { get { return this._bm; } set { this._bm = value; } }
    }
}
