using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OAuth2Client
{
    public class FacebookAuthorizer : OAuthAuthorizer
    {

        public override Uri AuthorizeUri { get; set; }  = new Uri("https://www.facebook.com/v2.8/dialog/oauth");
        public override Uri TokenUri { get; set; }      = new Uri("https://graph.facebook.com/v2.8/oauth/access_token");
        public override Uri RedirectUri { get; set; }   = new Uri("https://www.facebook.com/connect/login_success.html");
        //Base
        public FacebookAuthorizer() : 
            base ("Facebook")
        {
            
        }

        //Without scope
        public FacebookAuthorizer(string clientId, string clientSecret) :
           base("Facebook", clientId, clientSecret)
        {

        }

        //With scope
        public FacebookAuthorizer(string clientId, string clientSecret, string scope) : 
            base("Facebook", clientId, clientSecret, scope)
        {
           
        }

        //With specific redirect Uri
        public FacebookAuthorizer(string clientId, string clientSecret, string scope, Uri redirectUri) : 
            base("Facebook", clientId, clientSecret, scope)
        {
            this.RedirectUri = redirectUri;
        }
    }
}
