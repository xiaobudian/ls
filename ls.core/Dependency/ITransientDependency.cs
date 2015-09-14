namespace ls.core
{
    /// <summary>
    /// 实现此接口的类型将自动注册为<see cref="LifeCycleStyle.Transient"/>模式
    /// </summary>
    public interface ITransientDependency : IDependency
    { }
}