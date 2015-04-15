namespace DSmall.DynamicsCrm.UnitTest.Core
{
    using Microsoft.Xrm.Sdk;
    using Moq;

    /// <summary>The plugin execution context extensions.</summary>
    public static class PluginExecutionContextExtensions
    {
        /// <summary>The with input parameters.</summary>
        /// <param name="pluginContextMock">The plugin context mock.</param>
        /// <param name="parameterCollection">The parameter collection.</param>
        /// <returns>The <see cref="Mock"/>.</returns>
        public static Mock<IPluginExecutionContext> WithInputParameters(this Mock<IPluginExecutionContext> pluginContextMock, ParameterCollection parameterCollection)
        {
            pluginContextMock
                .Setup(context => context.InputParameters)
                .Returns(parameterCollection);
            
            return pluginContextMock;
        }

        /// <summary>The with pre entity images.</summary>
        /// <param name="pluginContextMock">The plugin context mock.</param>
        /// <param name="entityImageCollection">The entity image collection.</param>
        /// <returns>The <see cref="Mock"/>.</returns>
        public static Mock<IPluginExecutionContext> WithPreEntityImages(this Mock<IPluginExecutionContext> pluginContextMock, EntityImageCollection entityImageCollection)
        {
            pluginContextMock
                .Setup(context => context.PreEntityImages)
                .Returns(entityImageCollection);

            return pluginContextMock;
        }

        /// <summary>The with post entity images.</summary>
        /// <param name="pluginContextMock">The plugin context mock.</param>
        /// <param name="entityImageCollection">The entity image collection.</param>
        /// <returns>The <see cref="Mock"/>.</returns>
        public static Mock<IPluginExecutionContext> WithPostEntityImages(this Mock<IPluginExecutionContext> pluginContextMock, EntityImageCollection entityImageCollection)
        {
            pluginContextMock
                .Setup(context => context.PostEntityImages)
                .Returns(entityImageCollection);

            return pluginContextMock;
        }

        /// <summary>The with default.</summary>
        /// <param name="pluginContextMock">The plugin context mock.</param>
        /// <returns>The <see cref="Mock"/>.</returns>
        public static Mock<IPluginExecutionContext> WithDefault(this Mock<IPluginExecutionContext> pluginContextMock)
        {
            pluginContextMock
                .Setup(context => context.PostEntityImages)
                .Returns(new EntityImageCollection());

            return pluginContextMock;
        }
    }
}
