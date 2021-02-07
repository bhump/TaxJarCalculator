using System;
namespace TaxJar.Constants
{
    public class UrlConstants
    {
#if DEBUG
        public const string BaseUrl = "https://localhost:5001/api";
#else
        public const string BaseUrl = "";
#endif
        public const string Tax = "/tax";
    }
}
