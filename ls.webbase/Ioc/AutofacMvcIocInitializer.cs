using System.Reflection;
using System.Web.Mvc;
using Autofac;
using ls.core;
using Autofac.Integration.Mvc;

namespace ls.web.core
{
    /// <summary>
    /// MVC的依赖注入初始化器Autofac实现
    /// </summary>
    public class AutofacMvcIocInitializer : AutofacIocInitializerBase, IMvcIocInitializer
    {
        /// <summary>
        /// 注册自定义类型
        /// </summary>
        protected override void RegisterCustomTypes()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterInstance(this).As<IIocInitializer>().SingleInstance();
            builder.RegisterType<MvcIocResolver>().As<IIocResolver>().SingleInstance();
            builder.Update(Container);
        }

        /// <summary>
        /// 重写以实现设置Mvc框架的DependencyResolver
        /// </summary>
        /// <param name="assemblies"></param>
        protected override void SetResolver(Assembly[] assemblies)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(assemblies).AsSelf().PropertiesAutowired();
            builder.RegisterFilterProvider();
            builder.Update(Container);
            IDependencyResolver resolver = new AutofacDependencyResolver(Container);
            DependencyResolver.SetResolver(resolver);
        }
    }
}