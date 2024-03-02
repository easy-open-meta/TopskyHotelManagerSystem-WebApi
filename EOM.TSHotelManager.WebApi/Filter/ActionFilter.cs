using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace EOM.TSHotelManager.WebApi.Filter
{
    public class ActionFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Action方法调用之前执行
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;

            string param = string.Empty;
            string globalParam = string.Empty;

            foreach (var arg in context.ActionArguments)
            {
                string value = Newtonsoft.Json.JsonConvert.SerializeObject(arg.Value);
                param += $"{arg.Key} : {value} \r\n";
                globalParam += value;
            }
            Console.WriteLine($"webapi方法名称:【{descriptor.ActionName}】接收到参数为：{param}");
        }
        
        /// <summary>
        /// Action 方法调用后，Result 方法调用前执行
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context) { }
        
        /// <summary>
        /// Result 方法调用前执行
        /// </summary>
        /// <param name="context"></param>
        public override void OnResultExecuting(ResultExecutingContext context) { }
        
        /// <summary>
        /// Result 方法调用后执行
        /// </summary>
        /// <param name="context"></param>
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;

            string result = string.Empty;
            if (context.Result is ObjectResult)
            {
                result = Newtonsoft.Json.JsonConvert.SerializeObject(((ObjectResult)context.Result).Value);
            }

            Console.WriteLine($"webapi方法名称【{descriptor.ActionName}】执行的返回值 :  {result}");
        }
    }
}
