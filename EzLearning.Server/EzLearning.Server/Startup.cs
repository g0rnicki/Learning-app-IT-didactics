using EzLearning.Server.Dal;
using EzLearning.Server.Middleware;
using EzLearning.Server.Services;
using EzLearning.Server.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EzLearning.Server
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
            services.AddCors();
            services.AddControllers();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EzLearning.Server", Version = "v1" });
            });

            services.AddDbContext<AppDataContext>(
                opt =>
                {
                    var connectionString = Configuration["MySqlConnectionString"];
                    opt.UseMySql(connectionString,
                        ServerVersion.AutoDetect(connectionString));
                });

            services.AddScoped<IUserService>(sp =>
            {
                var ctx = sp.GetRequiredService<AppDataContext>();
                return new UserService(ctx, Configuration.GetSection("AppSettings")["Secret"]);
            });
            services.AddScoped<ILearningService, LearningService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EzLearning.Server v1"));
            }

            UpdateDb(app);

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseMiddleware<JwtMiddleware>();

            //app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void UpdateDb(IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            using var ctx = scope.ServiceProvider.GetRequiredService<AppDataContext>();
            ctx.Database.Migrate();
        }
    }
}
