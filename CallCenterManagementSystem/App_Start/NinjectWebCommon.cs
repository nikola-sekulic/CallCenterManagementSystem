[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CallCenterManagementSystem.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CallCenterManagementSystem.App_Start.NinjectWebCommon), "Stop")]

 namespace CallCenterManagementSystem.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Web;
    using Ninject.Extensions.Conventions;
    using System.Web.Http;
    using Ninject.Web.WebApi;

    public static class NinjectWebCommon
{
    private static readonly Bootstrapper bootstrapper = new Bootstrapper();

    public static void Start()
    {
        DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
        DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        bootstrapper.Initialize(CreateKernel);
    }

    public static void Stop()
    {
        bootstrapper.ShutDown();
    }

    private static IKernel CreateKernel()
    {
        var kernel = new StandardKernel();
        kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
        kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

        RegisterServices(kernel);
            kernel.Bind(x =>
            {
                x.FromThisAssembly()
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            return kernel;
    }
    private static void RegisterServices(IKernel kernel)
    {
        //kerne  l.Bind<IRepo>().ToMethod(ctx => new Repo("Ninject Rocks!"));
    }
}
}