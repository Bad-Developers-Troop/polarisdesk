using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PolarisDesk.API.Interface;
using PolarisDesk.API.Services;
using PolarisDesk.Models;
using System;
using Microsoft.EntityFrameworkCore;
using PolarisDesk.API.Data;

namespace PolarisDesk.API
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
            services.AddDbContext<PolarisDeskContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://localhost:5001/";
                    options.Audience = "polarisdeskapi";
                });


            //Dep
#if DEBUG            
            services.AddScoped<ICrudService<Ticket,Guid>, TicketServiceMock>();
            services.AddScoped<ICrudService<Customer, Guid>, CustomerServiceMock>();
            services.AddScoped<ICrudService<TicketStatus, Guid>, TicketStatusService<TicketStatus, Guid>>();
            services.AddScoped<ICrudService<TicketPriority, Guid>, TicketPriorityService<TicketPriority, Guid>>();
#endif

#if !DEBUG
            services.AddScoped<ICrudService<Ticket, Guid>, TicketService<Ticket, Guid>>();
            services.AddScoped<ICrudService<TicketStatus, Guid>, TicketStatusService<TicketStatus, Guid>>();
            services.AddScoped<ICrudService<TicketPriority, Guid>, TicketPriorityService<TicketPriority, Guid>>();
            services.AddScoped<ICrudService<Customer, Guid>, CustomerService<Customer, Guid>>();
#endif

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PolarisDesk.API", Version = "v1" });
            });

            var allowedorigins = Configuration.GetValue<string>("AllowedOrigins")?.Split(",") ?? new string[0];

            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowedOrigins", builder => { builder.WithOrigins(allowedorigins).AllowAnyHeader(); });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PolarisDesk.API v1"));
            }

            app.UseCors("AllowedOrigins");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
