using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using ProjetoDDD.Application;
using ProjetoDDD.Application.Interface;
using ProjetoDDD.Domain.Interfaces.Repositories;
using ProjetoDDD.Domain.Interfaces.Services;
using ProjetoDDD.Domain.Services;
using ProjetoDDD.Infra.Data.Repositories;
using ProjetoDDD.MVC;
using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace ProjetoDDD.MVC
{
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
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof (IAppServiceBase<>)).To(typeof (AppServiceBase<>));
            kernel.Bind<IClientAppService>().To<ClientAppService>();
            kernel.Bind<IProductAppService>().To<ProductAppService>();

            kernel.Bind(typeof (IServiceBase<>)).To(typeof (ServiceBase<>));
            kernel.Bind<IClientService>().To<ClientService>();
            kernel.Bind<IProductService>().To<ProductService>();

            kernel.Bind(typeof (IRepositoryBase<>)).To(typeof (RepositoryBase<>));
            kernel.Bind<IClientRepository>().To<ClientRepository>();
            kernel.Bind<IProductRepository>().To<ProductRepository>();
        }
    }
}
