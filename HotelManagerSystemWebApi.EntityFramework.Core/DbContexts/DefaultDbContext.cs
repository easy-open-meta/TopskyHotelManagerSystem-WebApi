using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace HotelManagerSystemWebApi.EntityFramework.Core
{
    [AppDbContext("NpgSqlConnectStr", DbProvider.Npgsql)]
    public class DefaultDbContext : AppDbContext<DefaultDbContext>
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }
    }
}