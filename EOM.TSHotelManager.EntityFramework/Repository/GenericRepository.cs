using SqlSugar;

namespace EOM.TSHotelManager.EntityFramework
{
    public class GenericRepository<T> : SimpleClient<T> where T : class, new()
    {
        public GenericRepository(ISqlSugarClient client) : base(client)
        {
            // 初始化数据库上下文，设置必要的配置（例如错误处理）
            base.Context.Aop.OnError = (ex) => { /* 处理错误 */ };
        }
    }
}
