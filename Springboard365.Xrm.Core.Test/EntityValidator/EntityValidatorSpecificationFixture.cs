namespace Springboard365.Xrm.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Moq;
    using Springboard365.Xrm.Core;
    using Springboard365.Xrm.UnitTest.Core;

    public class EntityValidatorSpecificationFixture
    {
        public IEntityValidator UnderTest { get; private set; }

        public Mock<IPluginExecutionContext> PluginContext { get; private set; }

        public void PerformTestSetup()
        {
            UnderTest = new EntityValidator();

            PluginContext = ServiceProviderInitializer.SetupPluginContext()
                .WithInputParameters(GetTargetEntityCollection)
                .WithPreEntityImages(GetPreImageEntityCollection)
                .WithPostEntityImages(GetPostImageEntityCollection);
        }

        public void PerformTestSetupWithNullPostImage()
        {
            UnderTest = new EntityValidator();

            PluginContext = ServiceProviderInitializer.SetupPluginContext()
                .WithPostEntityImages(() => new EntityImageCollection { { "PostImage", null } });
        }

        private static ParameterCollection GetTargetEntityCollection()
        {
            return new ParameterCollection
            {
                { "Target", new Entity("contact") { Id = Guid.NewGuid() } }
            };
        }

        private static EntityImageCollection GetPreImageEntityCollection()
        {
            return new EntityImageCollection
            {
                { "PreImage", new Entity("contact") { Id = Guid.NewGuid() } }
            };
        }

        private static EntityImageCollection GetPostImageEntityCollection()
        {
            return new EntityImageCollection
            {
                { "PostImage", new Entity("contact") { Id = Guid.NewGuid() } }
            };
        }
    }
}