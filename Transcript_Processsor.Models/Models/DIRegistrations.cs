using System;
using System.Collections.Generic;
using System.Text;

namespace Transcript_Processsor.Models.Models
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

            services.AddDbContext<Liberty_Jedi_GodfreyContext>(Option => Option.UseSqlServer(Configuration.GetConnectionString("RepoConnection"), b => b.MigrationsAssembly("GoUni_Report.Core")));
            services.AddScoped<IUnitofWork<Liberty_Jedi_GodfreyContext>, UnitofWork<Liberty_Jedi_GodfreyContext>>();
            services.AddTransient<IAdmissionService, AdmissionService>();
            services.AddScoped<IStudentServicecs, StudentService>();
            services.AddTransient<IHostelService, HostelService>();
            services.AddTransient<IPaymentService, PaymentService>();
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
