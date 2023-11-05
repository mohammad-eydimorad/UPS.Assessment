using System.Windows;
using UPS.Assessment.App.Services;
using UPS.Assessment.App.ViewModels;
using Microsoft.Extensions.Hosting;
using UPS.Assessment.App.Store;
using Microsoft.Extensions.DependencyInjection;
using UPS.Assessment.ACL.GoRest;
using UPS.Assessment.ApplicationService.DTO;
using UPS.Assessment.ApplicationService;
using Microsoft.Extensions.Configuration;

namespace UPS.Assessment.App
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddViewModels()
                .ConfigureServices((hostContext, services) =>
                {
                    var restClient = new RestClient<EmployeeDto>(
                        hostContext.Configuration.GetValue<string>("EmployeeHostBaseURl"),
                        hostContext.Configuration.GetValue<string>("EmployeeHostToken")
                        );
                    services.AddSingleton<IRestClient<EmployeeDto>>(restClient);
                    services.AddSingleton<IEmployeeService, EmployeeService>();
                    services.AddSingleton<NavigationStore>();

                    services.AddSingleton(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<MainViewModel>()
                    });
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            NavigationService<EmployeeListViewModel> navigationService = _host.Services.GetRequiredService<NavigationService<EmployeeListViewModel>>();
            navigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
