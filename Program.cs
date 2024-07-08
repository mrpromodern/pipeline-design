using Microsoft.Extensions.DependencyInjection;
using PipelineDesign.Data;
using PipelineDesign.forms;
using PipelineDesign.Forms;
using PipelineDesign.Repositories;
using PipelineDesign.Services;
using System;
using System.Windows.Forms;

namespace PipelineDesign
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureService(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }

        private static void ConfigureService(IServiceCollection services)
        {
            services.AddSingleton<AppDbContext>(provider => new AppDbContext());

            services.AddSingleton<INodeService, NodeService>();
            services.AddSingleton<IPipelineService, PipelineService>();

            services.AddSingleton<INodeRepository, NodeRepository>();
            services.AddSingleton<IPipelineRepository, PipelineRepository>();

            services.AddSingleton<MainForm>();
            services.AddSingleton<CreateForm>();
            services.AddSingleton<UpdateForm>();
        }
    }
}
