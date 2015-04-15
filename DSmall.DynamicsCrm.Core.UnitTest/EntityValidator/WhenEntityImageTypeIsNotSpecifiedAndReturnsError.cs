namespace DSmall.DynamicsCrm.Core.UnitTest
{
    using System;
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The when entity image type is not specified and returns error.</summary>
    [TestFixture]
    public class WhenEntityImageTypeIsNotSpecifiedAndReturnsError : SpecificationBase
    {
        private EntityValidatorSpecificationFixture testFixture;
        private Exception exceptionThrown;

        /// <summary>The should return correct exception message.</summary>
        [Test]
        public void ShouldReturnCorrectExceptionMessage()
        {
            Assert.AreEqual("Please specify an Entity Image Type.", exceptionThrown.Message);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            try
            {
                testFixture.UnderTest.GetValidCrmTargetEntity<Entity>(testFixture.PluginContext.Object, EntityImageType.NotSpecified);
            }
            catch (Exception exception)
            {
                exceptionThrown = exception;
            }
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            base.Context();

            testFixture = new EntityValidatorSpecificationFixture();
            testFixture.PerformTestSetupWithNullPostImage();
        }
    }
}
