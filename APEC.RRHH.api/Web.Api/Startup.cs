using Boundaries.Persistence.Context;
using Boundaries.Persistence.Repositories;
using Core.Managers;
using Core.Ports.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace Web.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            builder.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);


            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .Build());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "APEC RRHH API", Version = "v1" });
            });

            services.AddDbContext<ApecRrhhContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ApecRRHHDatabase")));

            services.AddMvc().AddJsonOptions(
                options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            BuildRepositoriesToScope(services);

            BuildManagerToScope(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            app.UseDeveloperExceptionPage();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "APEC RRHH");
                //c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static void BuildManagerToScope(IServiceCollection services)
        {
            services.AddScoped<UserManager, UserManager>();
            services.AddScoped<EmployeeManager, EmployeeManager>();
            services.AddScoped<CandidateEmployeeManager, CandidateEmployeeManager>();
            services.AddScoped<DepartamentManager, DepartamentManager>();
            services.AddScoped<JobManager, JobManager>();
            services.AddScoped<ConfigurationManager, ConfigurationManager>();
        }

        private static void BuildRepositoriesToScope(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<ICompetenceRepository, CompetenceRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IPreparationRepository, PreparationRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartamentRepository, DepartamentRepository>();
            services.AddScoped<ICandidateEmployeeRepository, CandidateEmployeeRepository>();
            services.AddScoped<ICandidateInterviewRepository, CandidateInterviewRepository>();
            services.AddScoped<ICandidateEmployeeAspiratedJobRepository, CandidateEmployeeAspiratedJobRepository>();

        }
    }
}
