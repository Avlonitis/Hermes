﻿using Hermes.Model;
using Hermes.Model.Models;
using System;
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
using System.Runtime.Caching;
using System.Globalization;
using Hermes.View.Upload;

namespace Hermes.View
{
    /// <summary>
    /// Interaction logic for UploadPage.xaml
    /// </summary>
    public partial class UploadPage : Page, IUploadPage
    {
        private UploadPresenter _presenter;

        public UploadPage()
        {
            InitializeComponent();

            //IF USER IS NOT LOGGED IN REDIRECT HIM TO LOG IN

            _presenter = new UploadPresenter(this);

            //---------------------------------------

            comboxUploadCategory.ItemsSource = _presenter.GetCategoryNames();
            comboxUploadCategory.SelectedIndex = 0;

            //---------------------------------------

            comboxUploadLocation.ItemsSource = _presenter.GetLocationNames();
            comboxUploadLocation.SelectedIndex = 0;

            //---------------------------------------

            radbtnUploadSell.IsChecked = true;
        }

        public string name
        {
            get
            {
                return txtboxUploadTitle.Text;
            }
        }

        public float price
        {
            get
            {
                return float.Parse(txtboxUploadPrice.Text, CultureInfo.InvariantCulture);
            }
        }

        public Location location
        {
            get
            {
                return _presenter.GetSelectedLocation((int)comboxUploadLocationTK.SelectedItem);
            }
        }

        public string description
        {
            get
            {
                return txtboxUploadDescription.Text;
            }
        }

        public SubCategory subcategory
        {
            get
            {
                return _presenter.GetSelectedSubCategory((string)comboxUploadSubcategory.SelectedItem);
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            txtboxUploadPrice.IsEnabled = !(bool)(checkBoxFreePrice.IsChecked);
            txtboxUploadPrice.Text = "0";
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            Location myLocation = _presenter.GetMyHomeLocation();
            comboxUploadLocation.SelectedItem = myLocation.Name;
            comboxUploadLocationTK.SelectedItem = myLocation.Tk.ToString();
            comboxUploadLocation.IsEnabled = !(bool)(checkBoxMyHome.IsChecked);
            comboxUploadLocationTK.IsEnabled = comboxUploadLocation.IsEnabled;
        }

        private void comboxUploadCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboxUploadSubcategory.ItemsSource = _presenter.GetSubCategoryNames(comboxUploadCategory.SelectedIndex);
            comboxUploadSubcategory.IsEnabled = true;
            comboxUploadSubcategory.SelectedIndex = 0;
        }

        private void comboxUploadLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboxUploadLocationTK.ItemsSource = _presenter.GetLocationTK((string)comboxUploadLocation.SelectedItem);
            comboxUploadLocationTK.SelectedIndex = 0;
        }

        private void btnUploadUpload_Click(object sender, RoutedEventArgs e)
        {
            bool result = _presenter.UploadListing(GetTaggedListingName(), price, location.Id, description, subcategory.Id, GetListingType());
            if (result)
            {
                MessageBox.Show("Listing uploaded succesfully", "Upload Complete", MessageBoxButton.OK);
                this.NavigationService.Navigate(new Uri("View/MyListings/MyListingsPage.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("Could not upload listing.\nSQL Error.","Error",MessageBoxButton.OK);
            }
        }

        private string GetTaggedListingName()
        {
            if (radbtnUploadSell.IsChecked == true)
            {
                return "[Selling] " + name;
            }
            else
            {
                return "[Looking for] " + name;
            }
        }

        private bool GetListingType()
        {
            if (radbtnUploadSell.IsChecked == true)
            {
                return false;
            }
            else
                return true;
        }

    }
}
