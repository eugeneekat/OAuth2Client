using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OAuth2Client
{
    class FacebookAuthorizer : OAuthAuthorizer
    {
        public FacebookAuthorizer() : base ("Facebook")
        {
            this.RedirectUri    = new Uri(ConfigurationManager.AppSettings["FacebookDefaultRedirectUrl"]);
            this.AuthorizeUri   = new Uri(ConfigurationManager.AppSettings["FacebookAuthorizeUrl"]);
            this.TokenUri       = new Uri(ConfigurationManager.AppSettings["FacebookTokenUrl"]);
        }

        public FacebookAuthorizer(string clientId, string clientSecret, string scope) 
            : base("Facebook", clientId, clientSecret, scope, new Uri(ConfigurationManager.AppSettings["FacebookDefaultRedirectUrl"]))
        {
            this.AuthorizeUri   = new Uri(ConfigurationManager.AppSettings["FacebookAuthorizeUrl"]);
            this.TokenUri       = new Uri(ConfigurationManager.AppSettings["FacebookTokenUrl"]);
        }
    }
}
