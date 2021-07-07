using CRMGuru.TestTask.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;


namespace CRMGuru.TestTask.WPF
{
    public class ServiceLocator
    {
        public MainWindowViewModel MainModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
