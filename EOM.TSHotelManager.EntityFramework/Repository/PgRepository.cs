using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EOM.TSHotelManager.EntityFramework
{
    public class PgRepository<T> : SimpleClient<T> where T : class, new()
    {
        public PgRepository(ISqlSugarClient context = null) : base(context)//注意这里要有默认值等于null
        {
            if (context == null)
            {
                base.Context = new SqlSugarClient(new ConnectionConfig()
                {
                    DbType = SqlSugar.DbType.PostgreSQL,//此处为设置数据库，支持各大主流数据库
                    InitKeyType = InitKeyType.Attribute,//此处为初始化配置类型，有按特性进行初始化，也有其他的进行初始化
                    IsAutoCloseConnection = true,//此处为是否自动关闭数据库连接，可以理解为是DBHelper里的Close()方法
                    MoreSettings = new ConnMoreSettings()
                    {
                        PgSqlIsAutoToLower = false, //数据库存在大写字段的
                                                  //，需要把这个设为false ，并且实体和字段名称要一样
                                                  //如果数据库里的数据表本身就为小写，则改成true
                                                  //详细可以参考官网https://www.donet5.com/Home/Doc
                    },
                    ConnectionString = AppSettingsJson.GetAppSettings().GetConnectionString("PgSqlConnectStr")
                });

                base.Context.Aop.OnError = (ex) =>
                {
                    //此处为AOP切面编程代码块，常用于数据库连接日志记录
                    //或者查看详细的报错信息，打印ex的内容即可
                };
            }
        }

    }
}
