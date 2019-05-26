using System;
using System.Threading.Tasks;
using OrderMeApp.Models;
using OrderMeApp.Services;
using Xamarin.Forms;

namespace OrderMeApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ProductModel Item { get; set; }
    

        readonly ServiceProvider provider = new ServiceProvider();

       

        public ItemDetailViewModel(ProductModel item = null)
        {
            Item = item;
           
        }

        public async Task SaveOrderCommand(OrderDto order)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {

                var items = await provider.Process(order, "post");


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
