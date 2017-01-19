using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2Client
{
    interface IOAuthAuthorizer
    {
        //Static
        string ClientName           { get; }
        string ClientId             { get; set; }
        string ClientSecret         { get; set; }
        Uri ClientAuthorizationUri  { get; }

        //Variable
        string Scope { get; set; }
        Uri RedirectUri { get; set; }
               
        string GetAuthorizationResponse(string code);
    }
}
