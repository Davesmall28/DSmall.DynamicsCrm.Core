namespace Springboard365.Xrm.Core.Test
{
    using Springboard365.UnitTest.Core;
    using NUnit.Framework;

    [TestFixture]
    public class WhenGetCrmFieldNameReturnsSuccessfully : SpecificationBase
    {
        private CrmFieldNameHelperSpecificationFixture testFixture;
        private string result;

        protected override void Context()
        {
            base.Context();
            testFixture = new CrmFieldNameHelperSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            base.BecauseOf();

            result = testFixture.UnderTest.GetCrmFieldName<DummyEntity>(entity => entity.FirstName);
        }

        [Test]
        public void ShouldReturnCorrectCrmFieldName()
        {
            Assert.AreEqual("firstname", result);
        }
    }
}