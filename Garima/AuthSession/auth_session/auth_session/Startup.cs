﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_session.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace auth_session
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
            services.AddDbContext<auth_sessionContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:localDb"]));

            services.AddCors(options => {
                options.AddPolicy("ApiCorsPolicy", builder =>
{
builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
});
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("ApiCorsPolicy");
            app.UseMvc();
        }
    }
}
