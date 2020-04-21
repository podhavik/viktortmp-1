using System;
using System.Configuration;
using Firefly.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Viktor.Models;

namespace Viktor
{
    class ServiceConfiguration
    {
        /// <summary>
        /// Main DI register
        /// </summary>
        private static IServiceCollection _serviceCollection;
        
        /// <summary>
        /// ctor
        /// </summary>
        public ServiceConfiguration()
        {
            _serviceCollection = new ServiceCollection();
            _serviceCollection.UseInlineDiRegistration();
            ConfigureServices();
        }

        /// <summary>
        /// Here you can register your services manually
        /// </summary>
        private void ConfigureServices()
        {
            // Database context

            var conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Já\\source\\repos\\Viktor\\Viktor\\Db.mdf;Integrated Security=True";
                //ConfigurationManager.AppSettings.Get("DbConnectionString");
            Console.Out.WriteLine("Found db conn string: {0}", conn);

            _serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(conn)
            );

            
        }

        /// <summary>
        /// Service provider build proxy
        /// </summary>
        /// <returns></returns>
        public IServiceProvider BuildServiceProvider()
            => _serviceCollection.BuildServiceProvider();
    }
}
