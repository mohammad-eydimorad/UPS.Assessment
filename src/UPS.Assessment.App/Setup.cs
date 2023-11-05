using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using UPS.Assessment.ACL.GoRest;
using UPS.Assessment.App.Services;
using UPS.Assessment.App.ViewModels;
using UPS.Assessment.ApplicationService;
using UPS.Assessment.ApplicationService.DTO;

namespace UPS.Assessment.App
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {


                services.AddTransient((s) => CreateReservationListingViewModel(s));
                services.AddSingleton<Func<EmployeeListViewModel>>((s) => () => s.GetRequiredService<EmployeeListViewModel>());
                services.AddSingleton<NavigationService<EmployeeListViewModel>>();

                services.AddTransient<NewEmployeeViewModel>();
                services.AddSingleton<Func<NewEmployeeViewModel>>((s) => () => s.GetRequiredService<NewEmployeeViewModel>());
                services.AddSingleton<NavigationService<NewEmployeeViewModel>>();

                services.AddSingleton<MainViewModel>();
            });

            return hostBuilder;
        }

        private static EmployeeListViewModel CreateReservationListingViewModel(IServiceProvider services)
        {
            return EmployeeListViewModel.LoadViewModel(
                services.GetRequiredService<IEmployeeService>(),
                services.GetRequiredService<NavigationService<NewEmployeeViewModel>>());
        }
    }
}
