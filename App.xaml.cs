using Microsoft.Extensions.DependencyInjection;
using PublishingHouse.DataAccessLayer;
using PublishingHouse.Interfaces;
using PublishingHouse.Repositories;
using PublishingHouse.Services;
using PublishingHouse.Stores;
using PublishingHouse.ViewModels;
using System;
using System.Windows;

namespace PublishingHouse
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<PublishingHouseContext>();

            services.AddSingleton(s => CreateHomeNavigationService(s));

            services.AddSingleton<UnitOfWork>();
            services.AddSingleton<NavigationStore>();
            
            services.AddSingleton<AuthenticationService>();
            services.AddSingleton<PrintedEditionService>();
            services.AddSingleton<UserService>();
            services.AddSingleton<OrderService>();

            services.AddSingleton<MainViewModel>();

            services.AddTransient(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            services.AddTransient(s => new LoginViewModel(
                s.GetRequiredService<AuthenticationService>(),
                CreateRegistrationNavigationService(s),
                CreateMainPageNavigationService(s)));

            services.AddTransient(s => new RegistrationViewModel(
                s.GetRequiredService<AuthenticationService>(),
                CreateLoginNavigationService(s)));

            services.AddTransient(s => CreateMainPageViewModel(s));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService initialNavigationService = 
                _serviceProvider.GetRequiredService<INavigationService>();

            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<LoginViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<LoginViewModel>());
        }

        private INavigationService CreateRegistrationNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<RegistrationViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<RegistrationViewModel>());
        }

        private INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider) 
        {
            return new NavigationService<LoginViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<LoginViewModel>());
        }

        private INavigationService CreateBookInfoNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<PrintedEditionViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>());
        }

        private INavigationService CreateMainPageNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<MainPageViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<MainPageViewModel>());
        }

        private MainPageViewModel CreateMainPageViewModel(IServiceProvider serviceProvider)
        {
            return MainPageViewModel.LoadViewModel(serviceProvider.GetRequiredService<LoginViewModel>(),
                CreateBookInfoNavigationService(serviceProvider),
                serviceProvider.GetRequiredService<PrintedEditionService>(),
                serviceProvider.GetRequiredService<OrderService>(),
                serviceProvider.GetRequiredService<UserService>());
        }
    }
}
