using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ls.core;


namespace ls.web.core
{
    /// <summary>
    /// SignalR的依赖注入初始化器Autofac实现
    /// </summary>
    public class AutofacSignalrIocInitializer : AutofacIocInitializerBase, ISignalRIocInitializer
    {
        /// <summary>
        /// 注册自定义类型
        /// </summary>
        protected override void RegisterCustomTypes()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterInstance(this).As<IIocInitializer>().SingleInstance();
            builder.RegisterType<SignalRIocResolver>().As<IIocResolver>().SingleInstance();
            builder.Update(Container);
        }

        /// <summary>
        /// 重写以实现设置SignalR框架的DependencyResolver
        /// </summary>
        /// <param name="assemblies"></param>
        protected override void SetResolver(Assembly[] assemblies)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterHubs(assemblies).AsSelf().PropertiesAutowired();
            builder.Update(Container);
            IDependencyResolver resolver = new global::Autofac.Integration.SignalR.AutofacDependencyResolver(Container);
            GlobalHost.DependencyResolver = resolver;
        }
    }
}