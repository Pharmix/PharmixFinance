using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Web.Finance.Services
{
    public class ViewRenderService : IViewRenderService
    {
        private readonly IRazorViewEngine _razorViewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IServiceProvider _serviceProvider;
        private readonly ICompositeViewEngine _viewEngine;

        public ViewRenderService(IRazorViewEngine razorViewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider
            , ICompositeViewEngine viewEngine)
        {
            _razorViewEngine = razorViewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
            _viewEngine = viewEngine;
        }

        public async Task<string> RenderViewToStringAsync(ControllerContext controllerContext, string viewName, object model, Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary tempData, Dictionary<string, string> viewBagItems = null)
        {
            var view = _viewEngine.FindView(controllerContext, viewName, true).View;

            var writer = new StringWriter();

            var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = model
            };


            var viewContext = new ViewContext(
                controllerContext, view, viewDictionary,
                tempData, writer, new HtmlHelperOptions()
            );
            if (viewBagItems != null)
            {
                foreach (var item in viewBagItems)
                {
                    viewContext.ViewData.Add(item.Key, item.Value);
                }
            }

            await view.RenderAsync(viewContext);

            return writer.ToString();
        }


        //public async Task<string> RenderToStringAsync(string viewName, object model)
        //{
        //    var httpContext = new DefaultHttpContext { RequestServices = _serviceProvider };
        //    var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

        //    using (var sw = new StringWriter())
        //    {
        //        var viewResult = _razorViewEngine.FindView(actionContext, viewName, false);

        //        if (viewResult.View == null)
        //        {
        //            throw new ArgumentNullException($"{viewName} does not match any available view");
        //        }

        //        var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
        //        {
        //            Model = model
        //        };

        //        var viewContext = new ViewContext(
        //            actionContext,
        //            viewResult.View,
        //            viewDictionary,
        //            new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
        //            sw,
        //            new HtmlHelperOptions()
        //        );

        //        await viewResult.View.RenderAsync(viewContext);
        //        return sw.ToString();
        //    }
        //}
    }
}
