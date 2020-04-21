using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace Viktor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var di = new ServiceConfiguration();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var rootScope = di.BuildServiceProvider().CreateScope())
            {
                var provider = rootScope.ServiceProvider;
                var form = provider.GetRequiredService<Form1>();
                Application.Run(form);
            }
        }
    }
}
