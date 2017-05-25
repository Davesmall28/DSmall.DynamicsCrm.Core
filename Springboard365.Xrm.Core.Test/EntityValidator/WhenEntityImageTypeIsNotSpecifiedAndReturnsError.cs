namespace Springboard365.Xrm.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class WhenEntityImageTypeIsNotSpecifiedAndReturnsError : SpecificationBase
    {
        private EntityValidatorSpecificationFixture testFixture;
        private Exception exceptionThrown;

        protected override void Context()
        {
            base.Context();

            testFixture = new EntityValidatorSpecificationFixture();
            testFixture.PerformTestSetupWithNullPostImage();
        }

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

        [Test]
        public void ShouldReturnCorrectExceptionMessage()
        {
            Assert.AreEqual("Please specify an Entity Image Type.", exceptionThrown.Message);
        }
    }
}