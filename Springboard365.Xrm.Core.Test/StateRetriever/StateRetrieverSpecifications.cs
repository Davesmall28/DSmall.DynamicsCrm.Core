namespace Springboard365.Xrm.Core.Test
{
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class StateRetrieverSpecifications : SpecificationBase
    {
        private StateRetrieverSpecificationFixture testFixture;

        private OptionSetValue result;

        protected override void Context()
        {
            base.Context();

            testFixture = new StateRetrieverSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            base.BecauseOf();

            result = testFixture.UnderTest.GetStateCodeFromStatusCode(testFixture.StatusCode, testFixture.EntityName);
        }

        [Test]
        public void ShouldReturnCorrectStateCode()
        {
            Assert.AreEqual(result.Value, testFixture.StateCode);
        }
    }
}