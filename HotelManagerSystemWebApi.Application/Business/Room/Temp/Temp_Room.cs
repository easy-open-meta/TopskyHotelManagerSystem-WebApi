using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Application
{
    /// <summary>
    /// 房间实体类
    /// </summary>
    public class Temp_Room
    {
        /// <summary>
        /// 房间编号
        /// </summary>
        public string RoomNo { get; set; }
        /// <summary>
        /// 房间类型
        /// </summary>
        public int RoomType { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustoNo { get; set; }
        /// <summary>
        /// 房间状态ID
        /// </summary>
        public int RoomStateId { get; set; }
        /// <summary>
        /// 房间单价
        /// </summary>
        public decimal RoomMoney { get; set; }
        /// <summary>
        /// 房间押金
        /// </summary>
        public decimal RoomDeposit { get; set; }
        /// <summary>
        /// 房间位置
        /// </summary>
        public string RoomPosition { get; set; }



        /// <summary>
        /// 房间类型描述
        /// </summary>
        public string RoomTypeNm { get; set; }
        /// <summary>
        /// 客户编号描述
        /// </summary>
        public string CustoNm { get; set; }
        /// <summary>
        /// 房间状态描述
        /// </summary>
        public string RoomStateNm { get; set; }

    }
}
