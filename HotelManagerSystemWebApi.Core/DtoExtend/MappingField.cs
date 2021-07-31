using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 字段映射
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class MappingField : Attribute
    {
        public string ColName { get; }
        public MappingField(string colName)
        {
            this.ColName = colName;
        }
    }
}
