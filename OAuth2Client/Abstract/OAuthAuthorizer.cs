using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace OAuth2Client
{
    public abstract class OAuthAuthorizer : IOAuthAuthorizer
    {
        //Client name, id, secret, scope (permissions)
        public string ClientName { get; protected set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }

        //Authorization URL - for login
        public virtual Uri AuthorizeUri { get; set; }
        //URL for get ACCESS_TOKEN
        public virtual Uri TokenUri { get; set; }
        //Redirect URL after - login
        public virtual Uri RedirectUri { get; set; }
        
        //Additional params
        public Dictionary<string, string> Params { get; set; }

        //Get Uri for Authorize user in app
        public Uri GetAuthorizationUri()
        {
            UriBuilder uriBuilder = new UriBuilder(AuthorizeUri);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["client_id"] = ClientId;
            query["redirect_uri"] = RedirectUri.AbsoluteUri;
            if (!string.IsNullOrEmpty(Scope))
                query["scope"] = Scope;
            if (Params != null)
            {
                foreach (var param in Params)
                    query[param.Key] = query[param.Value];
            }
            uriBuilder.Query = query.ToString();
            return uriBuilder.Uri;
        }

        //Helper Function - Get request Url for taking ACCESS_TOKEN
        private Uri TokenRequestUri(string code)
        {
            UriBuilder uriBuilder = new UriBuilder(TokenUri);
            var query = HttpUtility.ParseQueryString(TokenUri.Query);
            query["client_id"] = ClientId;
            query["client_secret"] = ClientSecret;
            query["redirect_uri"] = RedirectUri.AbsoluteUri;
            query["code"] = code;
            if (Params != null)
            {
                foreach (var param in Params)
                    query[param.Key] = query[param.Value];
            }
            uriBuilder.Query = query.ToString();
            return uriBuilder.Uri;
        }

        //GET ACCESS_TOKEN from CODE - может сделать абстрактным для конкретных классов авторизации и возвращать сразу код?
        public Dictionary<string, string> GetAuthorizationResult(string code)
        {
            Uri uri = TokenRequestUri(code);
            WebRequest webRequest = WebRequest.Create(uri);
            Dictionary<string, string> obj = null;
            try
            {
                using (var webResponse = webRequest.GetResponse())
                {
                    using (var reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        obj = js.Deserialize<Dictionary<string, string>>(reader.ReadToEnd());                       
                    }
                }
            }
            catch (WebException ex)
            {
                //EXCEPTION!!!
            }
            return obj;
        }

        //Constructors
        //Base
        public OAuthAuthorizer(string clientName)
        {
            this.ClientName = clientName;
        }

        //Without scope
        public OAuthAuthorizer(string clientName, string clientId, string clientSecret)
            : this(clientName)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
        }

        //With scope
        public OAuthAuthorizer(string clientName, string clientId, string clientSecret, string scope)
            : this(clientName, clientId, clientSecret)
        {
            this.Scope = scope;
        }
    }
}
