using Newtonsoft.Json;
using OrderMeApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrderMeApp.Services
{
    public class ServiceProvider
    {

        public string Url = "https://261fbc04.ngrok.io";


        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

        public async Task<IList<ProductModel>> GetList()
        {
            var result = "";
            IList<ProductModel> productList = null;

            var _data = new ResponseData();


            string apiUrl = Url + "/api/product/getproductsformobile";

      

            try
            {
                HttpClient client = await GetClient();
                result = await client.GetStringAsync(apiUrl);
                // ResponseData mobilResult = JsonConvert.DeserializeObject<ResponseData>(result);
                productList = JsonConvert.DeserializeObject<IList<ProductModel>>(result.ToString());
            }
            catch (Exception exc)
            {
                throw;
            }
            return productList;
        }


        public async Task<IList<OrderDto>> GetMyOrders(string orderId, string getMethod)
        {

            var result = "";
            IList<OrderDto> orderList = null;

            try
            {


                HttpClient client = await GetClient();
                result = await client.GetStringAsync(Url + "/api/order/" + getMethod + "/" + orderId);
                ResponseData mobilResult = JsonConvert.DeserializeObject<ResponseData>(result);
                orderList = JsonConvert.DeserializeObject<IList<OrderDto>>(mobilResult.data.ToString());

            }
            catch (Exception exc)
            {

                throw;
            }




            return orderList;
        }


        public async Task<IList<QueryModel>> Process(OrderDto model, string postMethod)
        {

            var result = "";
            IList<QueryModel> productList = null;

            try
            {

                HttpClient client = await GetClient();
                
                var response = await client.PostAsync(Url + "/api/order/" + postMethod,
                    new StringContent(JsonConvert.SerializeObject(model),
                    Encoding.UTF8, "application/json"));
               
            }
            catch (Exception exc)
            {

                throw;
            }




            return productList;
        }

    }
}
