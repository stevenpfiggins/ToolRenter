using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin;
using MultipartDataMediaFormatter;
using MultipartDataMediaFormatter.Infrastructure;
using Owin;

[assembly: OwinStartup(typeof(ToolRenter.WebAPI.Startup))]

namespace ToolRenter.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            GlobalConfiguration.Configuration.Formatters.Add
            (new FormMultipartEncodedMediaTypeFormatter(new MultipartFormatterSettings()));
        }
    }
}
