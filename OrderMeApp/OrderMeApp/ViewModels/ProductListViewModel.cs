using OrderMeApp.Models;
using OrderMeApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OrderMeApp.ViewModels
{
   public class ProductListViewModel:BaseViewModel
    {

        readonly ServiceProvider provider = new ServiceProvider();

        public ObservableCollection<ProductModel> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command SaveOrderCommand { get; set; }


        public ProductListViewModel()
        {
            Title = "Browse";

            Items = new ObservableCollection<ProductModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await provider.GetList();
                foreach (var item in items)
                {
                    Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
