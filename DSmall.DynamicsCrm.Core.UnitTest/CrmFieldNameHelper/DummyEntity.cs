namespace DSmall.DynamicsCrm.Core.UnitTest
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The dummy entity.</summary>
    public class DummyEntity : Entity
    {
        /// <summary>Gets or sets the customer reference.</summary>
        [AttributeLogicalName("customerreference")]
        public string CustomerReference { get; set; }

        /// <summary>Gets or sets the first name.</summary>
        public string FirstName { get; set; }
    }
}