using System;
using System.Reflection;

namespace EOM.TSHotelManager.Common.Util
{
    public static class ValidateHelper
    {
        public static bool Validate(object obj)
        {
            Type type = obj.GetType();

            // 遍历所有属性
            foreach (PropertyInfo property in type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
            {
                // 检查属性是否具有 NeedValid 特性
                if (Attribute.IsDefined(property, typeof(NeedValidAttribute)))
                {
                    // 获取属性的值
                    object value = property.GetValue(obj);

                    // 根据不同的类型进行校验
                    if (value is string strValue && string.IsNullOrEmpty(strValue))
                    {
                        return false;
                    }
                    else if (value is int intValue && intValue < 0)
                    {
                        return false;
                    }
                    else if (value is decimal decValue && decValue < 0)
                    {
                        return false;
                    }
                    else if (value is double doubleValue && doubleValue < 0)
                    {
                        return false;
                    }
                    else if (value is float floatValue && floatValue < 0)
                    {
                        return false;
                    }
                    else if (value is DateTime dateTimeValue && dateTimeValue == default)
                    {
                        return false;
                    }
                }
            }

            // 如果所有校验均通过
            return true;
        }
    }
}
