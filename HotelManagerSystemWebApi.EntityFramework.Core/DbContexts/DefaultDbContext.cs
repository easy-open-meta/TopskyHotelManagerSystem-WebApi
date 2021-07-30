using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace HotelManagerSystemWebApi.EntityFramework.Core
{
    [AppDbContext("MySqlConnectStr", DbProvider.MySqlOfficial)]
    public class DefaultDbContext : AppDbContext<DefaultDbContext>
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }
    }
}