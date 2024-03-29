﻿using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer
{
    /// <summary>
    /// Identity server configuration
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Identity server clients
        /// </summary>
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client // Sample ASP.NET Core MVC Web App client
                {
                    ClientId = "oidcMVCApp",
                    ClientName = "Sample ASP.NET Core MVC Web App",
                    ClientSecrets = new List<Secret> {new Secret("secret".Sha256())},

                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string> {"https://localhost:7104/signin-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    RequirePkce = true,
                    AllowPlainTextPkce = false
                },
                new Client // Movie API client
                {
                    ClientId = "movieAPI",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "movieAPI" }
                },
                new Client // Movie MVC application client
                {
                    ClientId = "movieMVC",
                    ClientName = "Movie MVC Web application",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = false,
                    AllowRememberConsent = false,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:7251/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:7251/signout-callback-oidc"
                    },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                        , "movieMVC"
                    }
                }
            };
        /// <summary>
        /// API scopes
        /// </summary>
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("movieAPI", "Movie API")
                , new ApiScope("movieMVC", "Movie MVC Web application")
            };
        /// <summary>
        /// Identity resources
        /// </summary>
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
                //new IdentityResources.Address(),
                //new IdentityResources.Email(),
                //new IdentityResource(
                //    "roles",
                //    "Your role(s)",
                //    new List<string>() { "role" })
            };
        /// <summary>
        /// Test user
        /// </summary>
        public static List<TestUser> TestUsers =>
            new List<TestUser>()
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "test",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Role, "role")
                    }
                }
            };
    }
}
