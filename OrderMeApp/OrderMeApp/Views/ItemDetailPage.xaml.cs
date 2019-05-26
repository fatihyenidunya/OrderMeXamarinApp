using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using OrderMeApp.Models;
using OrderMeApp.ViewModels;

namespace OrderMeApp.Views
{
    
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();
               

        }

        private async void onOrder(object sender, EventArgs e)
        {
            try
            {
                ProductModel product = viewModel.Item;


                OrderDto newOrder = new OrderDto
                {
                    Category = product.Category,
                    Number = Convert.ToInt32(txtAmount.Text),
                    Customer = "Me",
                    CustomerId = "1",
                    Description = product.Description,
                    Price = product.Price,
                    Product = product.Title,
                    isShipped = false,
                    OrderDate=new DateTime()
                     
                };
            

                viewModel.SaveOrderCommand(newOrder);

                await DisplayAlert("", "Order is successed", "OK");

            }
            catch (Exception exc)
            {
                DisplayAlert("", exc.Message, "OK");
            }





        }
    }
}