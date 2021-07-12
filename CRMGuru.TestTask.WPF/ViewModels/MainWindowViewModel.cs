using CRMGuru.TestTask.Interfaces.Models;
using CRMGuru.TestTask.Interfaces.Services;
using CRMGuru.TestTask.WPF.ViewModels.Base;
using CRMGuru.TestTask.WPF.Views.Windows;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace CRMGuru.TestTask.WPF.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private readonly IAddCountryService _addCountry;
        private readonly ILoadContryService _loadContry;
        private string _inputContryName;
        private CountryModel _currentCountry;
        public string Title { get; set; }
        private IEnumerable<CountryModel> _countries;
        private bool _listCountriesStatus;
        private CurrentCountryApiWindow _countryApiWindow;

        /// <summary>
        /// Статус отображения списка стран
        /// </summary>
        public bool ListCountriesStatus
        {
            get => _listCountriesStatus;
            set => Set(ref _listCountriesStatus, value);
        }
        /// <summary>
        /// Поле ввода страны пользователем
        /// </summary>
        public string InputContryName
        {
            get => _inputContryName;
            set => Set(ref _inputContryName, value);
        }

        /// <summary>
        /// Коллекция стран
        /// </summary>
        public IEnumerable<CountryModel> Countries 
        { get => _countries; 
          set => Set(ref _countries, value);
        }
        
        /// <summary>
        /// Страна от Api сервера
        /// </summary>
        public CountryModel CurrentCountry 
        { 
            get => _currentCountry; 
            set => Set(ref _currentCountry, value); 
        }

        public MainWindowViewModel(IAddCountryService addCountry, ILoadContryService loadContry)
        {
            _addCountry = addCountry;
            _loadContry = loadContry;
             Title = "Тестовое задание CRMGuru";       
        }

        /// <summary>
        /// Загрузка данных о стране с webClient
        /// </summary>
        public ICommand LoadCountryCommand => new DelegateCommand(async () => {

            try
            {
                CurrentCountry = await _loadContry.LoadContryWebApi(InputContryName);

                _countryApiWindow = new CurrentCountryApiWindow { CountryModel = CurrentCountry };
                _countryApiWindow.ShowDialog();

                if (_countryApiWindow.DialogResult == true)
                {
                    await _addCountry.AddCountryDb(CurrentCountry);
                    _countryApiWindow.Close();

                    MessageBox.Show("Успешно добавлено");
                    
                }
                else
                {
                    _countryApiWindow.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка ответа сервера {e.Message}");
            }
        }, () => !String.IsNullOrEmpty(InputContryName));
             
        /// <summary>
        /// Загрузка стран из базы данных
        /// </summary>
        public ICommand LoadCountriesDbCommand => new DelegateCommand(async () => {
            ListCountriesStatus = true;
            try
            {
                Countries = await _loadContry.LoadContryDb();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка в работе с базой данных {e.Message}, попробуйте еще раз ");
            }
            
            MessageBox.Show("Обновлено");
        });



    }
}
