using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Linq;

namespace EOM.TSHotelManager.WebApi.Filter
{
    public class AuthorizeAllControllersConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                var hasAllowAnonymousAttribute = controller.ControllerType.GetCustomAttributes(true)
                    .Any(attr => attr.GetType() == typeof(AllowAnonymousAttribute));

                if (!hasAllowAnonymousAttribute)
                {
                    controller.Filters.Add(new AuthorizeFilter());
                }

                foreach (var action in controller.Actions)
                {
                    var hasAllowAnonymousAttributeOnAction = action.ActionMethod.GetCustomAttributes(true)
                        .Any(attr => attr.GetType() == typeof(AllowAnonymousAttribute));

                    if (!hasAllowAnonymousAttributeOnAction)
                    {
                        action.Filters.Add(new AuthorizeFilter());
                    }
                }
            }
        }
    }
}
