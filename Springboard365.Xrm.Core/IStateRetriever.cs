namespace Springboard365.Xrm.Core
{
    using Microsoft.Xrm.Sdk;

    public interface IStateRetriever
    {
        OptionSetValue GetStateCodeFromStatusCode(int statusCode, string entityName);
    }
}