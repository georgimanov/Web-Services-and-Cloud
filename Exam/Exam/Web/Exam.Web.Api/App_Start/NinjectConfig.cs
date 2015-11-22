namespace Exam.Web.Api
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using Data.Repositories;
    using Data;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;
    using Services.Data;
    using Services.Data.Contracts;
    using Commmon.Providers;
    using Common.Constants;

    public static class NinjectConfig
    {
        public static Action<IKernel> DependenciesRegistration = kernel =>
        {
            kernel.Bind<IExamDbContext>().To<ExamDbContext>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));
        };

        public static IKernel CreateKernel()
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
            DependenciesRegistration(kernel);

            kernel.Bind<IRandomProvider>().To<RandomProvider>();

            kernel.Bind(b => b
            .From(Assemblies.DataServices)
            .SelectAllClasses()
            .BindDefaultInterface());
        }
    }
}