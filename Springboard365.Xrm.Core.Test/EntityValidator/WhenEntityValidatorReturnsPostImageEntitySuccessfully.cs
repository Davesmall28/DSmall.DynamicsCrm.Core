namespace Springboard365.Xrm.Core.Test
{
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class WhenEntityValidatorReturnsPostImageEntitySuccessfully : SpecificationBase
    {
        private EntityValidatorSpecificationFixture testFixture;
        private Entity result;

        protected override void Context()
        {
            base.Context();

            testFixture = new EntityValidatorSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            base.BecauseOf();

            result = testFixture.UnderTest.GetValidCrmTargetEntity<Entity>(testFixture.PluginContext.Object, EntityImageType.PostImage);
        }

        [Test]
        public void ShouldReturnValidPostImageEntity()
        {
            Assert.IsNotNull(result);
        }
    }
}