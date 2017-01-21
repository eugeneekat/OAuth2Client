using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2Client
{
    public interface IOAuthAuthorizer
    {
        string ClientName       { get; }
        string ClientId         { get; set; }
        string ClientSecret     { get; set; }
        string Scope            { get; set; }
        Uri RedirectUri         { get; set; }

        Uri GetAuthorizationUri();
        Dictionary<string, string> GetAccessToken(string code);     
    }
}
