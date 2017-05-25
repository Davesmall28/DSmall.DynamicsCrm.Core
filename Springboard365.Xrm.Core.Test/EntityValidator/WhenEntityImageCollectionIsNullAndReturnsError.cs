namespace Springboard365.Xrm.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;
    using Springboard365.Xrm.Core;

    [TestFixture]
    public class WhenEntityImageCollectionIsNullAndReturnsError : SpecificationBase
    {
        private const EntityImageType EntityImageType = Core.EntityImageType.PostImage;
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
                testFixture.UnderTest.GetValidCrmTargetEntity<Entity>(testFixture.PluginContext.Object, EntityImageType);
            }
            catch (Exception exception)
            {
                exceptionThrown = exception;
            }
        }

        [Test]
        public void ShouldReturnCorrectExceptionMessage()
        {
            var exceptionMessage = string.Format("Parameters collection does not contain {0} entity or it is not equal to type of (Entity)", EntityImageType);
            Assert.AreEqual(exceptionMessage, exceptionThrown.Message);
        }
    }
}