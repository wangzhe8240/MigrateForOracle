using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.IO;
using System.Threading.Tasks;
using System;
using Jinhe;

namespace WebSelfHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);

            //静态文件托管  
            app.Use((context, fun) =>
            {
                return myhandle(context, fun);
            });
        }

        public Task myhandle(IOwinContext context, Func<Task> next)
        {
            //获取物理文件路径  
            var path = GetFilePath(context.Request.Path.Value);

            //验证路径是否存在  
            if (File.Exists(path))
            {
                return SetResponse(context, path);
            }

            //不存在返回下一个请求
            return next();
        }
        public static string GetFilePath(string relPath)
        {
            return Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                Config.GetAppSettings("SiteDir"),
                relPath.TrimStart('/').Replace('/', '\\'));
        }

        public Task SetResponse(IOwinContext context, string path)
        {
            var perfix = Path.GetExtension(path);
            if (perfix == ".html")
                context.Response.ContentType = "text/html; charset=utf-8";
            else if (perfix == ".js")
                context.Response.ContentType = "application/x-javascript";
            else if (perfix == ".css")
                context.Response.ContentType = "text/css";
            return context.Response.WriteAsync(File.ReadAllText(path));
        }
    }
}
