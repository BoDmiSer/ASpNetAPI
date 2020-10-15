using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ASpNetAPI.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using AutoMapper;
using Newtonsoft.Json.Serialization;
using ASpNetAPI.Models;
using ASpNetAPI.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ASpNetAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ASpNetAPIContext>(opt => opt.UseInMemoryDatabase("ASpNetAPIContext"));
            services.AddDbContextPool<ASpNetAPIContext>(opt => opt.UseMySql(Configuration.GetConnectionString("ASpNetAPIContext"))) ;
            services.AddControllersWithViews().AddDataAnnotationsLocalization();
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddCors();
            //services.AddScoped<ITutorialRepo, MockTutorialRepo>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ITutorialRepo<Tutorial>, MySQTutorialRepo<Tutorial>>();
            services.AddScoped<ITutorialRepoAsync<Tutorial>, MySQTutorialRepo<Tutorial>>();
            services.AddIdentity<User, IdentityRole>().
                AddEntityFrameworkStores<ASpNetAPIContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(options =>
              {
                  options.SaveToken = true;
                  options.RequireHttpsMetadata = false;
                  options.TokenValidationParameters = new TokenValidationParameters()
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidAudience = Configuration["JWT:ValidAudience"],
                      ValidIssuer = Configuration["JWT:ValidIssuer"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                  };
              });
            //services
            //.AddEntityFrameworkInMemoryDatabase()
            //.AddDbContext<ASpNetAPIContext>((sp, options) =>
            //{
            //    options.UseInMemoryDatabase("ASpNetAPIContext").UseInternalServiceProvider(sp);
            //});
            //services.AddDbContext<ASpNetAPIContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("ASpNetAPIContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
