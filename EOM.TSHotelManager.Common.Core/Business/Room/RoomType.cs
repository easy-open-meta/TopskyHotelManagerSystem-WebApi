/*
 * MIT License
 *Copyright (c) 2021 易开元(Easy-Open-Meta)

 *Permission is hereby granted, free of charge, to any person obtaining a copy
 *of this software and associated documentation files (the "Software"), to deal
 *in the Software without restriction, including without limitation the rights
 *to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *copies of the Software, and to permit persons to whom the Software is
 *furnished to do so, subject to the following conditions:

 *The above copyright notice and this permission notice shall be included in all
 *copies or substantial portions of the Software.

 *THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *SOFTWARE.
 *
 *模块说明：房间类型类
 */
namespace EOM.TSHotelManager.Common.Core
{
    /// <summary>
    /// 房间类型
    /// </summary>
    [SqlSugar.SugarTable("roomtype")]
    public class RoomType : BaseDTO
    {
        /// <summary>
        /// 类型编号
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "RoomType")]
        public int Roomtype { get; set; }
        /// <summary>
        /// 房间类型
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// 房间租金
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "room_rent", ColumnDataType = "decimal")]
        public decimal RoomRent { get; set; }

        /// <summary>
        /// 房间押金
        /// </summary>
        [SqlSugar.SugarColumn(ColumnName = "room_deposit")]
        public decimal RoomDeposit { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public int delete_mk { get; set; }
    }
}
