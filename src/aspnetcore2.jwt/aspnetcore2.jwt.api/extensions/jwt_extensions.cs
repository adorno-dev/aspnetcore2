using System;
using AspnetCore2.Jwt.Api.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace AspnetCore2.Jwt.Api
{
    public static class JwtExtension
    {
        public static AuthenticationBuilder SetAuthentication(this IServiceCollection services)
            => services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            });
        
        public static IServiceCollection SetJwtTokenBearer(this AuthenticationBuilder builder, TokenOptions tokenOptions)
        {
            builder.AddJwtBearer(options =>
            {
                var jwt = options.TokenValidationParameters;
                jwt.IssuerSigningKey = tokenOptions.Key;
                jwt.ValidAudience = tokenOptions.Audience;
                jwt.ValidIssuer = tokenOptions.Issuer;

                jwt.ValidateIssuerSigningKey = true;
                jwt.ValidateLifetime = true;
                jwt.ClockSkew = TimeSpan.Zero;
            });

            return builder.Services;
        }

        public static IServiceCollection SetAuthorization(this IServiceCollection services)
            => services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim("Jwt", "Admin"));
                options.AddPolicy("User", policy => policy.RequireClaim("Jwt", "User"));
            });
    }
}