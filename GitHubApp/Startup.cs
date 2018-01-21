using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHubApp.Models;
using GitHubApp.GitHubApp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GitHubApp.DAL;

namespace GitHubApp
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
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<GitHubAppContext>(
                    options => options.UseNpgsql(
                Configuration.GetConnectionString("PSQLDatabase")));

            services.Configure<LanguageConfiguration>(Configuration.GetSection("LanguageConfiguration"));

            services.AddMvc();

            services.AddScoped<IGitHubAPI, GitHubAPI>();
            services.AddScoped<IGHRepoRepository, GHRepoRepository>();
            services.AddScoped<IGHRepoOwnerRepository, GHRepoOwnerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/GHRepos/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=GHRepos}/{action=Index}/{id?}");
            });
        }
    }
}
