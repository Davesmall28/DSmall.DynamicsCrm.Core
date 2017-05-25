namespace Springboard365.Xrm.Core.Test
{
    using Microsoft.Xrm.Sdk;

    public class DummyEntity : Entity
    {
        [AttributeLogicalName("firstname")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}