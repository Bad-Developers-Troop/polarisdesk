// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace PolarisDesk.IdentityProvider
{
    public static class Config
    {
        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("polarisdeskapi", "PolarisDesk API")  {
                             Scopes = {
                                 "polarisdeskapi"
                             }
                         }
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile(),
                        new IdentityResources.Email()
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("polarisdeskapi","PolarisDesk API")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "polarisdeskapp",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedCorsOrigins = { "https://localhost:44396" },
                    AllowedScopes = { "openid", "profile", "email" , "polarisdeskapi" },
                    RedirectUris = { "https://localhost:44396/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost:44396/" },
                    Enabled = true
                }
            };
    }
}