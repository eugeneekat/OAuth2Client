using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2Client
{
    public class VkontakteAuthorizer : OAuthAuthorizer
    {
        public override Uri AuthorizeUri { get; set; }  = new Uri("https://oauth.vk.com/authorize");
        public override Uri TokenUri { get; set; }      = new Uri("https://oauth.vk.com/access_token");
        public override Uri RedirectUri { get; set; }   = new Uri("https://oauth.vk.com/blank.html");

        //Base
        public VkontakteAuthorizer() : 
            base ("Vkontakte")
        {

        }

        //Without scope
        public VkontakteAuthorizer(string clientId, string clientSecret) :
           base("Vkontakte", clientId, clientSecret)
        {

        }

        //With scope
        public VkontakteAuthorizer(string clientId, string clientSecret, string scope) : 
            base("Vkontakte", clientId, clientSecret, scope)
        {

        }

        //With specific redirect Uri
        public VkontakteAuthorizer(string clientId, string clientSecret, string scope, Uri redirectUri) : 
            base("Vkontakte", clientId, clientSecret, scope)
        {
            this.RedirectUri = redirectUri;
        }
    }
}
