using BIT.Data.Functions;
using BIT.Xpo;
using BIT.Xpo.Functions;
using BIT.Xpo.Providers.WebApi.AspNetCore;
using DevExpress.Xpo.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using XpoDemoOrm;

namespace TestServer
{
    public class StartupXpoWebApiWithDal
    {
        public StartupXpoWebApiWithDal(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //IResolver<IDataStore> DataStoreResolver = new XpoDataStoreResolver("appsettings.json");
            //IStringSerializationService stringSerializationHelper = new StringSerializationHelper();
            //IObjectSerializationService objectSerializationHelper = new SimpleObjectSerializationService();

            //IFunction function = new DataStoreFunctionServer(DataStoreResolver, objectSerializationHelper);
            //services.AddSingleton<IResolver<IDataStore>>(DataStoreResolver);
            //services.AddSingleton<IStringSerializationService>(stringSerializationHelper);
            //services.AddSingleton<IObjectSerializationService>(objectSerializationHelper);
            //services.AddSingleton<IFunction>(function);

            services.AddXpoWebApiWithDal(typeof(Invoice), typeof(Customer));

            //services.AddXpoWebApi();

            //TODO review this code, at the momentis needed to use the  await for the operations in the fucntion rest client
            //services.Configure<KestrelServerOptions>(options =>
            //{
            //    options.AllowSynchronousIO = true;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
