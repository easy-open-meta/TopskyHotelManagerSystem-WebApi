using EOM.TSHotelManager.Shared;
using Microsoft.Extensions.Configuration;
using SqlSugar;
using System;

namespace EOM.TSHotelManager.WebApi
{
    public class SqlSugarClientFactory : ISqlSugarClientFactory
    {
        private readonly IConfiguration _configuration;

        public SqlSugarClientFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ISqlSugarClient CreateClient(string dbName = null)
        {
            // 读取默认数据库名称
            dbName ??= _configuration["DefaultDatabase"];

            var connectionString = _configuration.GetConnectionString(dbName + "ConnectStr");
            var dbType = GetDbType(dbName);

            ConnectionConfig config = new ConnectionConfig
            {
                ConnectionString = connectionString,
                DbType = dbType,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true,
                LanguageType = LanguageType.Chinese
            };

            switch (dbType)
            {
                case DbType.PostgreSQL:
                    config.MoreSettings = new ConnMoreSettings
                    {
                        PgSqlIsAutoToLower = false, //数据库存在大写字段的
                                                    //，需要把这个设为false ，并且实体和字段名称要一样
                                                    //如果数据库里的数据表本身就为小写，则改成true
                                                    //详细可以参考官网https://www.donet5.com/Home/Doc
                        DisableMillisecond = true
                    };
                    break;
            }

            return new SqlSugarClient(config);
        }

        private DbType GetDbType(string dbName)
        {
            return dbName switch
            {
                "PgSql" => DbType.PostgreSQL,
                "MySql" => DbType.MySql,
                "Oracle" => DbType.Oracle,
                "SqlServer" => DbType.SqlServer,
                "Sqlite" => DbType.Sqlite,
                _ => throw new ArgumentException("Unsupported database", nameof(dbName))
            };
        }
    }
}
