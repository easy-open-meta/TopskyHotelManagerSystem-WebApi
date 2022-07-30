using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HotelManagerSystemWebApi.Web.Entry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args).Inject();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            var app = builder.Build();
            app.Run();
        }
        
    }
}