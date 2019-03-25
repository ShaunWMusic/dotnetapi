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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using LibraryApi.Models;
using JsonApiDotNetCore.Extensions;
using JsonApiDotNetCore.Data;
using LibraryApi.Domain.Authors;
using LibraryApi.Domain.Books;
using JsonApiDotNetCore.Models;
using LibraryApi.Domain.Users;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LibraryApi.Services;
using LibraryApi.Repositories;

namespace LibraryApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<AppDbContext>();
            services.AddJsonApi<AppDbContext>(options => 
            {
                options.ValidateModelState = true;
            });

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWT_SECRET"]));
            var creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            services.AddSingleton(signingKey);
            services.AddSingleton(creds);


            services.AddCors();

            services.AddScoped<CurrentUserService>();
            services.AddScoped<IEntityRepository<Author>, AuthorsRepository>();
            services.AddScoped<IEntityRepository<Book>, BooksRepository>();
            services.AddScoped<IEntityRepository<Review>, BelongsToUserRepository<Review>>();
            services.AddScoped<ResourceDefinition<User>, UserResource>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(a => a.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseMvc();
            app.UseJsonApi();

            // var crypto = new System.Security.Cryptography.RNGCryptoServiceProvider();
            // var bytes = new byte[48];
            // crypto.GetBytes(bytes);
            // Console.WriteLine(Convert.ToBase64String(bytes));
        }
    }
}
