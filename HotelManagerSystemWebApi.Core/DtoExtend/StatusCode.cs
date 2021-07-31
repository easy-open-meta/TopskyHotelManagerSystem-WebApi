namespace HotelManagerSystemWebApi.Core
{
    /// <summary>
    /// 状态码枚举类
    /// </summary>
    public enum StatusCode
    {
        /// <summary>
        /// 初始化状态
        /// </summary>
        INIT = 0,
        /// <summary>
        /// 成功
        /// </summary>
        OK = 200,
        /// <summary>
        /// 无数据
        /// </summary>
        Empty = 201,
        /// <summary>
        /// 异常报错
        /// </summary>
        Error = 400,
        /// <summary>
        /// 缺少参数
        /// </summary>
        Required = 401,
        /// <summary>
        /// 过期
        /// </summary>
        Exp = 403,
        /// <summary>
        /// 不存在
        /// </summary>
        NotFound = 404,
        /// <summary>
        /// 参数问题
        /// </summary>
        Param = 405,
        /// <summary>
        /// 服务器中止操作
        /// </summary>
        Stop = 406,
        /// <summary>
        /// 异常调用
        /// </summary>
        ExceptionCall = 407,
        /// <summary>
        /// ORM数据库操作失败
        /// </summary>
        ORMError = 408,
        /// <summary>
        ///数据已经存在
        /// </summary>
        Exist = 409,
        /// <summary>
        /// 密码错误
        /// </summary>
        PwdError = 410,
        /// <summary>
        /// Token缺失
        /// </summary>
        TokenNull = 301,
        /// <summary>
        /// Token格式不正确
        /// </summary>
        TokenFormat = 302,
        /// <summary>
        /// Token过期
        /// </summary>
        TokenExp = 303

    }
}