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

namespace Hermes.View
{
    /// <summary>
    /// Interaction logic for FavoritesPage.xaml
    /// </summary>
    public partial class FavoritesPage : Page
    {
        public FavoritesPage()
        {
            InitializeComponent();
        }

        private void btnListingSelectedFavorite_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProfileMyProfile_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("View/ProfilePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnProfileHistory_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("View/HistoryPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnProfileFavorites_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("View/FavoritesPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnProfileListings_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("View/MyListings/MyListingsPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}