using SqlSugar;

namespace EOM.TSHotelManager.Shared
{
    public interface ISqlSugarClientFactory
    {
        ISqlSugarClient CreateClient(string dbName = null);
    }
}
