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
                // machine to machine client
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                },
                
                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "web_client_1",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Implicit,
                    
                    // where to redirect to after login
                    RedirectUris = { "http://localhost:4200/auth-callback" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "http://localhost:4200/" },

                    AllowedCorsOrigins = {"http://localhost:4200"},

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
