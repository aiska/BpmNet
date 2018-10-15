using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace BpmNet.Api.Tests
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                });


            services.AddDbContext<BpmNetContext>(options =>
            {
                options.UseBpmNet();
                // Use In Memory DB (only for testing purpose)
                //options.UseInMemoryDatabase(Guid.NewGuid().ToString());

                // Use Sql Server Database
                options.UseSqlServer("Data Source=(local);Initial Catalog=BPMNET_V1;Integrated Security=True");
            });


            // Add BpmNet Service
            services.AddBpmNet().AddCore().UseEntityFrameworkCore().UseDbContext<BpmNetContext>();

            // Add Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "BpmNet Test API", Version = "v1" });
                options.DescribeAllEnumsAsStrings();
                options.OperationFilter<BpmnFileFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<BpmNetContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BpmNet Test API V1");
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
