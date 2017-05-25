namespace Springboard365.Xrm.Core.Test
{
    using System;
    using System.IO;
    using Springboard365.UnitTest.Core;
    using NUnit.Framework;

    [TestFixture]
    public class WhenGetCrmFieldNameReturnsNull : SpecificationBase
    {
        private CrmFieldNameHelperSpecificationFixture testFixture;
        private bool isExceptionThrown;
        private Exception exceptionThrown;

        protected override void Context()
        {
            base.Context();

            testFixture = new CrmFieldNameHelperSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            base.BecauseOf();

            try
            {
                testFixture.UnderTest.GetCrmFieldName<DummyEntity>(entity => entity.LastName);
            }
            catch (Exception exception)
            {
                isExceptionThrown = true;
                exceptionThrown = exception;
            }
        }

        [Test]
        public void ShouldNotSwallowExceptions()
        {
            Assert.IsTrue(isExceptionThrown);
        }

        [Test]
        public void ShouldThrowInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(ThrowException);
        }

        private void ThrowException()
        {
            throw exceptionThrown;
        }
    }
}