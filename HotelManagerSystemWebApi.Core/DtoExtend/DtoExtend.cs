using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 实体类库
    /// </summary>
    public static class DtoExtend
    {
        /// <summary>
        /// 是否为空值或空字符串(集合)
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T1>(this List<T1> source)
        {
            //集合不为空和集合数量大于0
            return !(source != null && source.Count > 0);
        }

        /// <summary>
        /// 是否为空值或空字符串(实体)
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="t1"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T1>(this T1 t1) where T1 : class
        {
            return t1 == null;
        }

        /// <summary>
        /// 是否为空值或空字符串(字符串)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// 是否为空值或空字符串(整数)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public static bool IsNullOrEmpty(this int? value)
        {
            return value == null;
        }

        /// <summary>
        /// 是否为空值或空字符串(十进制)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public static bool IsNullOrEmpty(this decimal? value)
        {
            return value == null;
        }

        /// <summary>
        /// 是否为空值或空字符串(长整型)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public static bool IsNullOrEmpty(this long? value)
        {
            return value == null;
        }

        /// <summary>
        /// 复制实体A的数据到实体B
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="t1"></param>
        /// <returns></returns>
        public static T2 CopyModelTo<T1, T2>(this T1 t1) where T2 : class, new()
        {
            T2 t2 = Activator.CreateInstance<T2>();
            var tInType = t1.GetType();
            foreach (var itemOut in t1.GetType().GetProperties())
            {
                var itemIn = tInType.GetProperty(itemOut.Name); ;
                if (itemIn != null)
                {
                    itemOut.SetValue(t2, itemIn.GetValue(t1));
                }
            }
            return t2;
        }


    }
}
