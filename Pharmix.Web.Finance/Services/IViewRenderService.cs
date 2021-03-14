using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Web.Finance.Services
{
    public interface IViewRenderService
    {
        Task<string> RenderViewToStringAsync(ControllerContext controllerContext, string viewName, object model, Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary tempData, Dictionary<string, string> viewBagItems = null);
    }
}
