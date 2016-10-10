using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace Gold
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder App)
        {
            App.UseSession();
            App.UseStaticFiles();
            App.UseMvc();
            
        }
    }
}