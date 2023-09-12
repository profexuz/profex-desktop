﻿using Microsoft.IdentityModel.Tokens;
using Profex_Desktop.Components.Vacancies;
using Profex_Integrated.Services.Vacancies;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Profex_Desktop.Pages
{
    /// <summary>
    /// Interaction logic for Vacancies.xaml
    /// </summary>
    public partial class Vacancies : Page
    {
        private VacancyService _vacancyService = new VacancyService();
        private string BASE_URL = "http://64.227.42.134:4040/";
        public Vacancies()
        {
            InitializeComponent();

        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wrpNewsVacancy.Children.Clear();
            wrpAdvertising.Children.Clear();
            var result = await _vacancyService.GetAllAsync(1);
            string[] values = new string[3];
            byte count = 0;
            foreach (var item in result)
            {
                if (count == 6) break; count++;
                Vacancy vacancy = new Vacancy();
                vacancy.vacancyId = item.Id;
                values[0] = BASE_URL + item.ImagePath[0];
                values[1] = item.Title;
                values[2] = item.Price.ToString();
                vacancy.SetData(values);
                wrpNewsVacancy.Children.Add(vacancy);
            }
            count = 0;
            foreach (var item in result)
            {
                if (count <= 6)
                {
                    count++;
                    continue;
                }
                Vacancy vacancy = new Vacancy();
                vacancy.vacancyId = item.Id;
                values[0] = BASE_URL + item.ImagePath[0];
                values[1] = item.Title;
                values[2] = item.Price.ToString();
                vacancy.SetData(values);
                wrpAdvertising.Children.Add(vacancy);
                
            }
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = Search.Text; // Qidiruv so'zini olish

            // Qidiruvni boshlash uchun VacancyService dan foydalanish
            var searchResults = await _vacancyService.SearchAsync(searchText);

            wrpNewsVacancy.Children.Clear();
            wrpAdvertising.Children.Clear();
            string[] values = new string[3];
            byte count = 0;

            foreach (var item in searchResults)
            {
                if (count == 6) break;
                Vacancy vacancy = new Vacancy();
                vacancy.vacancyId = item.Id;
                values[0] = BASE_URL + item.ImagePath[0];
                values[1] = item.Title;
                values[2] = item.Price.ToString();
                vacancy.SetData(values);
                wrpNewsVacancy.Children.Add(vacancy);
                count++;
            }

            count = 0;

            foreach (var item in searchResults)
            {
                if (count <= 6)
                {
                    count++;
                    continue;
                }
                Vacancy vacancy = new Vacancy();
                vacancy.vacancyId = item.Id;
                values[0] = BASE_URL + item.ImagePath[0];
                values[1] = item.Title;
                values[2] = item.Price.ToString();
                vacancy.SetData(values);
                wrpAdvertising.Children.Add(vacancy);
            }
        }
    }
}
