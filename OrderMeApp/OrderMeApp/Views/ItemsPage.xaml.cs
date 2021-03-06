﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using OrderMeApp.Models;
using OrderMeApp.Views;
using OrderMeApp.ViewModels;

namespace OrderMeApp.Views
{
   
    public partial class ItemsPage : ContentPage
    {
       // ItemsViewModel viewModel;


        ProductListViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            //BindingContext = viewModel = new ItemsViewModel();

            BindingContext = viewModel = new ProductListViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ProductModel;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

           
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}