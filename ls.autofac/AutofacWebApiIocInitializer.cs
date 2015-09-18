using System.Reflection;
using System.Web.Http.Dependencies;
using Autofac.Integration.WebApi;
using Autofac;
using ls.core;
using System.Web.Http;

namespace ls.autofac
{
    /// <summary>
    /// WebApi的依赖注入初始化器Autofac实现
    /// </summary>
    public class AutofacWebApiIocInitializer : AutofacIocInitializerBase, IWebApiIocInitializer
    {
        /// <summary>
        /// 注册自定义类型
        /// </summary>
        protected override void RegisterCustomTypes()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterInstance(this).As<IIocInitializer>().SingleInstance();
            builder.RegisterType<WebApiIocResolver>().As<IIocResolver>().SingleInstance();
            builder.Update(Container);
        }

        /// <summary>
        /// 重写以实现设置WebAPI框架的DependencyResolver
        /// </summary>
        /// <param name="assemblies"></param>
        protected override void SetResolver(Assembly[] assemblies)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterApiControllers(assemblies).AsSelf().PropertiesAutowired();
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            builder.Update(Container);
            IDependencyResolver resolver = new AutofacWebApiDependencyResolver(Container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}