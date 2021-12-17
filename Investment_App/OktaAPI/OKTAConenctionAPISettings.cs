using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Investment_App.OktaAPI
{
    public class OKTAConenctionAPISettings
    {
        public static class OpenIdConnectNames
        {
            public const string Okta = "Okta";
        }

        public class OpenIdConnectSettings
        {
            public string Authority { get; set; }
            public string Audience { get; set; }
        }

        public class OpenIdConnectClientSettings
        {
            public string ClientId { get; set; }
            public string ProviderUrl { get; set; }
            public string AuthorizationEndPoint { get; set; }
            public string TokenEndPoint { get; set; }
        }
    }
}
