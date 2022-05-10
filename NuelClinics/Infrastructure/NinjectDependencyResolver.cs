using Ninject;
using NuelClinics.Domain.Abstract;
using NuelClinics.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuelClinics.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IDepartmentRepository>().To<EFDepartmentRepository>();

            kernel.Bind<IEmployeeRepository>().To<EFEmployeeRepository>();

            kernel.Bind<IEmployeeTypeRepository>().To<EFEmployeeTypeRepository>();

            kernel.Bind<IServiceRepository>().To<EFServiceRepository>();

            kernel.Bind<IAppointmentRepository>().To<EFAppointmentRepository>();

        }
    }
}