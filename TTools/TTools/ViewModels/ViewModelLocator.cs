using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTools.Views;

namespace TTools.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            Ioc.Default.ConfigureServices(
            new ServiceCollection()
            .AddSingleton<HomeView>()
            .AddSingleton<MainViewModel>()
            .AddSingleton<UACViewModel>()
            .AddSingleton<UACView>()
            .AddSingleton<PDFView>()
            .AddSingleton<JsonView>()
            .AddSingleton<SystemView>()
            .AddSingleton<ToolView>()
            .AddSingleton<SystemViewModel>()
            .AddSingleton<JsonViewModel>()
            .AddSingleton<HomeViewModel>()
            .AddSingleton<PDFViewModel>()
            .AddSingleton<ToolViewModel>()
            .BuildServiceProvider()
             );
        }
        public MainViewModel MainView
        {
            get
            {

                return Ioc.Default.GetService<MainViewModel>() ?? new MainViewModel();
            }
        }
        public UACViewModel UAC
        {
            get
            {
                return Ioc.Default.GetService<UACViewModel>() ?? new UACViewModel();
            }
        }
        public GpeditViewModel Gpedit
        {
            get
            {
                return Ioc.Default.GetService<GpeditViewModel>() ?? new GpeditViewModel();
            }
        }
        public JsonViewModel Json
        {
            get
            {
                return Ioc.Default.GetService<JsonViewModel>() ?? new JsonViewModel();
            }
        }
    }
}
