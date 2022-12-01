using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using System.Linq;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace Tests.Tests
{
    public class UnitTestBase
    {
        protected IServiceProvider provider;

        public UnitTestBase()
        {
            Initialize();
        }

        private ServiceCollection _collection { get; set; }

        private void Initialize()
        {
            _collection = new ServiceCollection();
            var configuration = Substitute.For<IConfiguration>();

            CrossCutting.Bootstraper.RegisterIDbConnection(_collection, configuration);
            CrossCutting.Bootstraper.RegisterServices(_collection, configuration);
        }

        protected T InstanceOf<T>()
        {
            return provider.GetService<T>();
        }

        protected void OverrideRegistration<T>(Func<IServiceProvider, T> expression) where T : class
        {
            _collection.Remove(_collection.FirstOrDefault(x => x.ImplementationType == typeof(T)));
            _collection.AddScoped(expression);
            provider = _collection.BuildServiceProvider();
        }
    }
}
