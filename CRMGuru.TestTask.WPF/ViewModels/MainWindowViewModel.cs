using CRMGuru.TestTask.Interfaces.Repositories;
using CRMGuru.TestTask.WebApiClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRMGuru.TestTask.WPF.ViewModels
{
    public class MainWindowViewModel
    {
        private readonly IWebRepository _webRepository;
        public string Title { get; set; }

        public MainWindowViewModel(IWebRepository webRepository)
        {
            _webRepository = webRepository;
            Title = "Главная страница сайта";
            restcountries = _webRepository.GetArray<RestcountriesModel>("moscow").Result;
        }

        public RestcountriesModel[] restcountries { get; set; }

        
    }
}
