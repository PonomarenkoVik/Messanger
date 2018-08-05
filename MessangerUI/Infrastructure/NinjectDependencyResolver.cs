using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessangerDataLayer;
using MessangerDataLayer.Abstraction;
using Moq;
using Ninject;

namespace MessangerUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            Mock<IDataRepository> mock = new Mock<IDataRepository>();
            mock.Setup(m => m.Users).Returns(new MessageDatabaseContext().Users);
            mock.Setup(m => m.Messages).Returns(new MessageDatabaseContext().Messages);
            _kernel.Bind<IDataRepository>().ToConstant((mock.Object));
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}