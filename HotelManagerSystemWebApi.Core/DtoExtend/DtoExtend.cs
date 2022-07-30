using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        /// 对结果进行分页处理
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<T1> GetPageList<T1>(this List<T1> source,int pageIndex,int pageSize,ref int count)
        {
            var listSource =  source.Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize).ToList();
            count = source.Count;
            return listSource;
        }

        /// <summary>
        /// 实体集合转换成指定实体集合
        /// </summary>
        /// <typeparam name="T1">输入实体类型</typeparam>
        /// <typeparam name="T2">输出实体类型</typeparam>
        /// <param name="source">输入数据源</param>
        /// <returns>输出数据源</returns>
        public static List<T2> CopyToModel<T1, T2>(this List<T1> source)
        {
            List<T2> listT2 = new List<T2>();

            T2 _T2 = default(T2);
            PropertyInfo[] _T1PI = typeof(T1).GetProperties();
            PropertyInfo[] _T2PI = typeof(T2).GetProperties();
            foreach (T1 _T1 in source)
            {
                _T2 = Activator.CreateInstance<T2>();
                for (int i = 0; i < _T2PI.Length; i++)
                {
                    //判断源实体中有没有对应的字段属性
                    var _PI = _T1PI.Where(a => a.Name.ToUpper() == _T2PI[i].Name.ToUpper()).FirstOrDefault();
                    if (_PI == null)
                    {
                        //字段名称
                        var propName = string.Empty;
                        //获取字段的自定义属性
                        var mappingField = _T2PI[i].GetCustomAttribute<MappingField>();
                        //如果自定义的映射属性存在，则取属性名称
                        if (mappingField != null)
                        {
                            propName = mappingField.ColName;
                        }
                        else
                        {
                            propName = _T2PI[i].Name;
                        }
                        //判断源实体中有没有对应的字段属性
                        _PI = _T1PI.Where(a => a.Name.ToUpper() == propName.ToUpper()).FirstOrDefault();
                    }
                    if (_PI != null)
                    {
                        object value = _PI.GetValue(_T1, null);
                        Type t = _T2PI[i].PropertyType;
                        if ((!t.Equals(_PI.PropertyType)) && value != null)
                        {
                            if (t == typeof(int))
                            {
                                value = Convert.ToInt32(_PI.GetValue(_T1, null));
                            }
                            else if (t == typeof(int?))
                            {
                                value = Convert.ToInt32(_PI.GetValue(_T1, null));
                            }
                            else if (t == typeof(string))
                            {
                                if (_PI.PropertyType == typeof(byte[]))
                                {
                                    value = System.Text.Encoding.UTF8.GetString((byte[])_PI.GetValue(_T1, null));
                                }
                                else
                                {
                                    value = _PI.GetValue(_T1, null) + "";
                                }
                            }
                            else if (t == typeof(DateTime))
                            {
                                value = Convert.ToDateTime(_PI.GetValue(_T1, null));
                            }
                            else if (t == typeof(DateTime?))
                            {
                                value = Convert.ToDateTime(_PI.GetValue(_T1, null));
                            }
                            else if (t == typeof(decimal?))
                            {
                                value = Convert.ToDecimal(_PI.GetValue(_T1, null));
                            }
                            else if (t == typeof(decimal))
                            {
                                value = Convert.ToDecimal(_PI.GetValue(_T1, null));
                            }
                            else
                            {
                                value = _PI.GetValue(_T1, null);
                            }
                        }
                        _T2PI[i].SetValue(_T2, value, null);
                    }
                }
                listT2.Add(_T2);
            }
            return listT2;
        }

        /// <summary>
        /// 复制实体A的数据到实体B
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="t1"></param>
        /// <returns></returns>
        public static T2 CopyToModel<T1, T2>(this T1 t1) where T2 : class, new()
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

        /// <summary>
        /// 实体更新数据
        /// </summary>
        /// <typeparam name="T1">输出实体类型</typeparam>
        /// <typeparam name="T2">输入实体类型</typeparam>
        /// <param name="_T1">输入数据源</param>
        /// <param name="_T2">输入数据源</param>
        /// <returns>输出数据源</returns>
        /// <returns></returns>
        public static T1 UpdateToModel<T1, T2>(this T1 _T1, T2 _T2) where T2 : class where T1 : class, new()
        {
            if (_T1 == null)
            {
                _T1 = new T1();
            }
            List<PropertyInfo> _T1PI = typeof(T1).GetProperties().ToList();
            List<PropertyInfo> _T2PI = typeof(T2).GetProperties().ToList();
            if (_T2 == null)
            {
                return _T1;
            }

            _T1PI.ForEach(_PI1 =>
            {
                _T2PI.ForEach(_PI2 =>
                {
                    //字段名称
                    var propName = _PI2.Name.ToUpper();
                    //判断源实体中有没有对应的字段属性
                    if (!propName.Equals(_PI1.Name.ToUpper()))
                    {
                        //获取字段的自定义属性
                        var mappingField = _PI2.GetCustomAttribute<MappingField>();
                        //如果自定义的映射属性存在，则取属性名称
                        if (mappingField != null)
                        {
                            propName = mappingField.ColName;
                        }
                        else
                        {
                            propName = _PI2.Name;
                        }
                    }
                    //判断源实体中有没有对应的字段属性
                    if (propName.ToUpper().Equals(_PI1.Name.ToUpper()))
                    {
                        object value = _PI2.GetValue(_T2, null);
                        Type t = _PI1.PropertyType;
                        if ((!t.Equals(_PI2.PropertyType)) && value != null)
                        {
                            if (t == typeof(int))
                            {
                                value = Convert.ToInt32(_PI2.GetValue(_T2, null));
                            }
                            else if (t == typeof(int?))
                            {
                                value = Convert.ToInt32(_PI2.GetValue(_T2, null));
                            }
                            else if (t == typeof(string))
                            {
                                if (_PI2.PropertyType == typeof(byte[]))
                                {
                                    value = System.Text.Encoding.UTF8.GetString((byte[])_PI2.GetValue(_T2, null));
                                }
                                else
                                {
                                    value = _PI2.GetValue(_T2, null) + "";
                                }
                            }
                            else if (t == typeof(DateTime))
                            {
                                value = Convert.ToDateTime(_PI2.GetValue(_T2, null));
                            }
                            else if (t == typeof(DateTime?))
                            {
                                value = Convert.ToDateTime(_PI2.GetValue(_T2, null));
                            }
                            else if (t == typeof(decimal?))
                            {
                                value = Convert.ToDecimal(_PI2.GetValue(_T2, null));
                            }
                            else if (t == typeof(decimal))
                            {
                                value = Convert.ToDecimal(_PI2.GetValue(_T2, null));
                            }
                            else if (t == typeof(byte[]))
                            {
                                value = System.Text.Encoding.UTF8.GetBytes(_PI2.GetValue(_T2, null) + "");
                            }
                            else
                            {
                                value = _PI2.GetValue(_T2, null);
                            }
                        }
                        if (_PI1.CustomAttributes.Count(a => a.AttributeType.Name.Equals("KeyAttribute")) > 0)
                        {
                            if ((value + "") != "")
                            {
                                _PI1.SetValue(_T1, value, null);
                            }
                        }
                        else
                        {
                            _PI1.SetValue(_T1, value, null);
                        }
                    }
                });
            });
            return _T1;
        }

        /// <summary>
        /// 设置调用成功
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static T OK<T>(this T dto, string strMsg = "请求成功") where T : MsgDto
        {
            dto.Status = StatusCode.OK;
            return dto;
        }

        /// <summary>
        /// 成功，空数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static T setEmpty<T>(this T dto, string strMsg = "无数据") where T : MsgDto
        {
            dto.Status = StatusCode.Empty;
            dto.ErrorMessage = strMsg;
            return dto;
        }

        /// <summary>
        /// 异常报错
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static T Error<T>(this T dto, string strMsg = "异常报错") where T : MsgDto
        {
            dto.Status = StatusCode.Error;
            dto.ErrorMessage = strMsg;
            return dto;
        }

        /// <summary>
        /// 缺少参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static T Error_Required<T>(this T dto, string strMsg = "缺少参数") where T : MsgDto
        {
            dto.Status = StatusCode.Required;
            dto.ErrorMessage = strMsg;
            return dto;
        }

        /// <summary>
        /// 数据过期
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static T Error_Exp<T>(this T dto, string strMsg = "数据已过期") where T : MsgDto
        {
            dto.Status = StatusCode.Exp;
            dto.ErrorMessage = strMsg;
            return dto;
        }

        /// <summary>
        /// 数据不存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static T Error_NotFound<T>(this T dto, string strMsg = "数据不存在") where T : MsgDto
        {
            dto.Status = StatusCode.NotFound;
            dto.ErrorMessage = strMsg;
            return dto;
        }

        /// <summary>
        /// 参数问题
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static T Error_Param<T>(this T dto, string strMsg = "参数问题") where T : MsgDto
        {
            dto.Status = StatusCode.Param;
            dto.ErrorMessage = strMsg;
            return dto;
        }

        /// <summary>
        /// 服务器中止操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static T Error_Stop<T>(this T dto, string strMsg = "服务器中止操作") where T : MsgDto
        {
            dto.Status = StatusCode.Stop;
            dto.ErrorMessage = strMsg;
            return dto;
        }

        /// <summary>
        /// 异常调用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static T Error_ExceptionCall<T>(this T dto, string strMsg = "接口异常调用") where T : MsgDto
        {
            dto.Status = StatusCode.ExceptionCall;
            dto.ErrorMessage = strMsg;
            return dto;
        }

        /// <summary>
        /// ORM数据库操作失败
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static T Error_ORM<T>(this T dto, string strMsg = "数据库操作失败") where T : MsgDto
        {
            dto.Status = StatusCode.ORMError;
            dto.ErrorMessage = strMsg;
            return dto;
        }

        /// <summary>
        /// 数据已经存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static T Error_Exist<T>(this T dto, string strMsg = "信息已存在") where T : MsgDto
        {
            dto.Status = StatusCode.Exist;
            dto.ErrorMessage = strMsg;
            return dto;
        }

        /// <summary>
        /// 密码错误
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static T Error_Pwd<T>(this T dto, string strMsg = "密码错误") where T : MsgDto
        {
            dto.Status = StatusCode.PwdError;
            dto.ErrorMessage = strMsg;
            return dto;
        }


        #region Token 状态集合
        /// <summary>
        /// 设置状态为Token缺失
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static T Token_Null<T>(this T dto, string strMsg = "Token缺失") where T : MsgDto
        {
            dto.Status = StatusCode.TokenNull;
            dto.ErrorMessage = strMsg;
            return dto;
        }

        /// <summary>
        /// 设置状态为Token格式不正确
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static T Token_Format<T>(this T dto, string strMsg = "Token格式不正确") where T : MsgDto
        {
            dto.Status = StatusCode.TokenFormat;
            dto.ErrorMessage = strMsg;
            return dto;
        }

        /// <summary>
        /// 设置状态为Token过期
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static T Token_Exp<T>(this T dto, string strMsg = "Token过期") where T : MsgDto
        {
            dto.Status = StatusCode.TokenExp;
            dto.ErrorMessage = strMsg;
            return dto;
        }
        #endregion

    }
}
