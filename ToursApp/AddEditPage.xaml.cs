﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToursApp.Properties;

namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Hotel _currentHotel = new Hotel();
        public AddEditPage(Hotel selectedHotel)
        {
            InitializeComponent();
            if (selectedHotel != null)
            {
                _currentHotel = selectedHotel;
            }
            DataContext = _currentHotel;
            ComboCountries.ItemsSource = ToursBaseEntities1.GetContext().Countries.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentHotel.Name)) {
                errors.AppendLine("Укажите название отеля");
            }
            if (_currentHotel.CountOfStars < 1 || _currentHotel.CountOfStars > 5)
            {
                errors.AppendLine("Количество звезд - число от 1 до 5");
            }
            if (_currentHotel.Country == null)
            {
                errors.AppendLine("Выберите страну");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                    return;
                
            }
            if (_currentHotel.Id == 0)
            {
                ToursBaseEntities1.GetContext().Hotels.Add(_currentHotel);
            }
            try
            {
                ToursBaseEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
