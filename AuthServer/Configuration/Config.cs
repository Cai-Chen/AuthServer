using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace AuthServer.Configuration
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("api1", "My API")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "api1" }
                },
                //new Client
                //{
                //    ClientId = "web_client_1",
                //    ClientSecrets = { new Secret("secret".Sha256()) },
                //    AllowedGrantTypes = GrantTypes.Implicit,
                //    RedirectUris = 
                //    { 
                //        "https://oauthclient.dev.com.au/auth-callback"
                //    },
                //    PostLogoutRedirectUris = 
                //    { 
                //        "https://oauthclient.dev.com.au/"
                //    },
                //    AllowedCorsOrigins = 
                //    { 
                //        "https://oauthclient.dev.com.au"
                //    },
                //    AllowAccessTokensViaBrowser = true,
                //    AllowedScopes = new List<string>
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "api1"
                //    }
                //},
                new Client
                {
                    ClientId = "web_client_1",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris =
                    {
                        "https://oauthclient.azurewebsites.net/auth-callback"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://oauthclient.azurewebsites.net/"
                    },
                    AllowedCorsOrigins =
                    {
                        "https://oauthclient.azurewebsites.net"
                    },
                    AllowAccessTokensViaBrowser = true,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    }
                }
            };
    }
}
