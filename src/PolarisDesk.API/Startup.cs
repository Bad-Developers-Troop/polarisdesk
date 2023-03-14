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
using PolarisDesk.DataAccessLayer;
using Hellang.Middleware.ProblemDetails;
using PolarisDesk.API.Managers;

namespace PolarisDesk.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IPolarisDeskContext, PolarisDeskContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    dbOptions => dbOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(3), null)));

            services.AddControllers();
            services.AddProblemDetails();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://localhost:5001/";
                    options.Audience = "polarisdeskapi";
                });

            if (WebHostEnvironment.IsDevelopment())
            {
                services.AddTransient<ICrudService<Ticket, Guid>, TicketServiceMock>();
                services.AddTransient<ICrudService<TicketStatus, Guid>, TicketStatusService<TicketStatus, Guid>>();
                services.AddTransient<ICrudService<TicketPriority, Guid>, TicketPriorityService<TicketPriority, Guid>>();
                services.AddTransient<ICrudService<Customer, Guid>, CustomerServiceMock>();
            }
            else
            {
                services.AddTransient<ICrudService<Ticket, Guid>, TicketService<Ticket, Guid>>();
                services.AddTransient<ICrudService<TicketStatus, Guid>, TicketStatusService<TicketStatus, Guid>>();
                services.AddTransient<ICrudService<TicketPriority, Guid>, TicketPriorityService<TicketPriority, Guid>>();
                services.AddTransient<ICrudService<Customer, Guid>, CustomerService<Customer, Guid>>();
            }

            services.AddScoped<ITicketsManager, TicketsManager>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PolarisDesk.API", Version = "v1" });
            });

            var allowedOrigins = Configuration.GetValue<string>("AllowedOrigins")?.Split(",") ?? Array.Empty<string>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowedOrigins", builder => { builder.WithOrigins(allowedOrigins).AllowAnyHeader(); });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseProblemDetails();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PolarisDesk.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowedOrigins");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
