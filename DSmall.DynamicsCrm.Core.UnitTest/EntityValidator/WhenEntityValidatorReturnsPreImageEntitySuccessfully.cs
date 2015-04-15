namespace DSmall.DynamicsCrm.Core.UnitTest
{
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The when entity validator returns pre image entity successfully.</summary>
    [TestFixture]
    public class WhenEntityValidatorReturnsPreImageEntitySuccessfully : SpecificationBase
    {
        private EntityValidatorSpecificationFixture testFixture;
        private Entity result;

        /// <summary>The should return valid entity.</summary>
        [Test]
        public void ShouldReturnValidEntity()
        {
            Assert.IsNotNull(result);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            result = testFixture.UnderTest.GetValidCrmTargetEntity<Entity>(testFixture.PluginContext.Object, EntityImageType.PreImage);
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            base.Context();

            testFixture = new EntityValidatorSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}
