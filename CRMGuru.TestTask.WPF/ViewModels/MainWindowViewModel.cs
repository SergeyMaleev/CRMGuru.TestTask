using System;
using System.Collections.Generic;
using System.Text;

namespace CRMGuru.TestTask.WPF.ViewModels
{
   public class MainWindowViewModel
   {
        public string Title { get; set; }

        public MainWindowViewModel()
        {
            Title = "Главная страница сайта";
        }
   }
}
