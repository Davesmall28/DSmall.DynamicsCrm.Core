namespace DSmall.DynamicsCrm.UnitTest.Core
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Moq;

    /// <summary>The service provider extensions.</summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>The with input parameters.</summary>
        /// <param name="serviceProviderMock">The service provider mock.</param>
        /// <param name="parameterCollection">The parameter collection.</param>
        /// <returns>The <see cref="Mock"/>.</returns>
        public static Mock<IServiceProvider> WithInputParameters(this Mock<IServiceProvider> serviceProviderMock, ParameterCollection parameterCollection)
        {
            var mockPluginContext = new Mock<IPluginExecutionContext>();

            mockPluginContext
                .Setup(context => context.InputParameters)
                .Returns(parameterCollection);

            serviceProviderMock
                .Setup(provider => provider.GetService(typeof(IPluginExecutionContext)))
                .Returns(mockPluginContext.Object);

            return serviceProviderMock;
        }

        /// <summary>The with pre entity images.</summary>
        /// <param name="serviceProviderMock">The service provider mock.</param>
        /// <param name="entityImageCollection">The entity image collection.</param>
        /// <returns>The <see cref="Mock"/>.</returns>
        public static Mock<IServiceProvider> WithPreEntityImages(this Mock<IServiceProvider> serviceProviderMock, EntityImageCollection entityImageCollection)
        {
            var mockPluginContext = new Mock<IPluginExecutionContext>();

            mockPluginContext
                .Setup(context => context.PreEntityImages)
                .Returns(entityImageCollection);

            serviceProviderMock
                .Setup(provider => provider.GetService(typeof(IPluginExecutionContext)))
                .Returns(mockPluginContext.Object);

            return serviceProviderMock;
        }

        /// <summary>The with post entity images.</summary>
        /// <param name="serviceProviderMock">The service provider mock.</param>
        /// <param name="entityImageCollection">The entity image collection.</param>
        /// <returns>The <see cref="Mock"/>.</returns>
        public static Mock<IServiceProvider> WithPostEntityImages(this Mock<IServiceProvider> serviceProviderMock, EntityImageCollection entityImageCollection)
        {
            var mockPluginContext = new Mock<IPluginExecutionContext>();

            mockPluginContext
                .Setup(context => context.PostEntityImages)
                .Returns(entityImageCollection);

            serviceProviderMock
                .Setup(provider => provider.GetService(typeof(IPluginExecutionContext)))
                .Returns(mockPluginContext.Object);

            return serviceProviderMock;
        }

        /// <summary>The with default.</summary>
        /// <param name="serviceProviderMock">The service provider mock.</param>
        /// <returns>The <see cref="Mock"/>.</returns>
        public static Mock<IServiceProvider> WithDefault(this Mock<IServiceProvider> serviceProviderMock)
        {
            var mockPluginContext = new Mock<IPluginExecutionContext>().WithDefault();

            mockPluginContext
                .Setup(context => context.InputParameters)
                .Returns(new ParameterCollection { { "Target", new Entity("contact") { Id = Guid.NewGuid() } } });

            mockPluginContext
                .Setup(context => context.PreEntityImages)
                .Returns(new EntityImageCollection { { "PreImage", new Entity("contact") { Id = Guid.NewGuid() } } });

            mockPluginContext
                .Setup(context => context.PostEntityImages)
                .Returns(new EntityImageCollection { { "PostImage", new Entity("contact") { Id = Guid.NewGuid() } } });

            serviceProviderMock
                .Setup(provider => provider.GetService(typeof(IPluginExecutionContext)))
                .Returns(mockPluginContext.Object);

            return serviceProviderMock;
        }
    }
}
