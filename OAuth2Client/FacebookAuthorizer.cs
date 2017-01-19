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
        //Base
        public FacebookAuthorizer() : 
            base ("Facebook", 
            new Uri("https://www.facebook.com/dialog/oauth"), 
            new Uri("https://graph.facebook.com/oauth/access_token")
            )
        {

        }

        //Without scope
        public FacebookAuthorizer(string clientId, string clientSecret) :
           base("Facebook",
           new Uri("https://www.facebook.com/dialog/oauth"),
           new Uri("https://graph.facebook.com/oauth/access_token"),
           clientId, clientSecret)
        {

        }

        //With scope
        public FacebookAuthorizer(string clientId, string clientSecret, string scope) : 
            base("Facebook",
            new Uri("https://www.facebook.com/dialog/oauth"),
            new Uri("https://graph.facebook.com/oauth/access_token"),
            clientId, clientSecret, scope)
        {
           
        }

        //With specific redirect Uri
        public FacebookAuthorizer(string clientId, string clientSecret, string scope, Uri redirectUri) : 
            base("Facebook",
            new Uri("https://www.facebook.com/dialog/oauth"),
            new Uri("https://graph.facebook.com/oauth/access_token"),
            clientId, clientSecret, scope, redirectUri)
        {
            
        }
    }
}
