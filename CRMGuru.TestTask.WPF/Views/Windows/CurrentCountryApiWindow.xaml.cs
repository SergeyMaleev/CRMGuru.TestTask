using CRMGuru.TestTask.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRMGuru.TestTask.WPF.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для CurrentCountryApiWindow.xaml
    /// </summary>
    public partial class CurrentCountryApiWindow : Window
    {
        public static readonly DependencyProperty CountryProperty = DependencyProperty.Register(
            nameof(CountryModel),
            typeof(CountryModel),
            typeof(CurrentCountryApiWindow),
            new PropertyMetadata(null));
            
        public CountryModel CountryModel 
        { 
            get => (CountryModel)GetValue(CountryProperty); 
            set => SetValue(CountryProperty, value); 
        }
              
        public CurrentCountryApiWindow() => InitializeComponent();

        private void Save_Click(object sender, RoutedEventArgs e) => this.DialogResult = true;
        private void Сancel_Click(object sender, RoutedEventArgs e) => this.DialogResult = false;
    }
}
