using GoUni_Report.Core.Repo_s;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using Transcript_Processor_Data.Interfaces;
using Transcript_Processor_Data.Repo_s;

namespace Transcript_Processor.App.Extensions
{
    public static class DIRegistrations
    {
        public static void AddRegistrations(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddCors(options => options.AddPolicy("CorsPolicy",
   thisbuilder =>
   {
       thisbuilder.AllowAnyMethod()
              .AllowAnyHeader()
              .AllowAnyOrigin()
              .AllowCredentials();
   }));

            services.AddDbContext<ProcessorContext>(Option => Option.UseSqlServer(Configuration.GetConnectionString("RepoConnection"), b => b.MigrationsAssembly("Transcript_Processor.Data")));
            services.AddScoped<IUnitofWork<ProcessorContext>, UnitofWork<ProcessorContext>>();
            services.AddSwaggerGen();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = Configuration["Jwt:Issuer"],
                     ValidAudience = Configuration["Jwt:Issuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                 };
             });
        }

    }
}
