using Furion.DatabaseAccessor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 地区识别码
    /// </summary>
    [Table("cardcodes")]
    public class CardCodes : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public CardCodes()
        {
        }

        /// <summary>
        /// 编号
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public System.Int64 id { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public System.String Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public System.String City { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        public System.String District { get; set; }

        /// <summary>
        /// 地区识别码
        /// </summary>
        public System.String bm { get; set; }
    }
}
