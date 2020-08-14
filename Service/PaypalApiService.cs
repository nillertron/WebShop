using Model;
using Newtonsoft.Json;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using System.Linq;

namespace Service
{
    public class PaypalApiService : IPaypalApiService
    {
        private static string clientId = "";
        private static string secret = "";
        private static HttpClient client;
        public static HttpClient Client()
        {
            PayPalEnvironment environment = new SandboxEnvironment(clientId, secret);
            var client = new PayPalHttpClient(environment);
            return client;
        }
        public PaypalApiService()
        {
            client = Client();

        }

        public async Task<string> CreateOrder(WS_Ordre ordre)
        {
            var total = 0.00;
            ordre.OrdreLinjer.ForEach(x => total += x.EnhedsPris);
            string totalString = total.ToString();
            totalString = totalString.Replace(',', '.');
            HttpResponse response;
            var order = new OrderRequest()
            {
                CheckoutPaymentIntent = "CAPTURE",
                PurchaseUnits = new List<PurchaseUnitRequest>()
                {
                    new PurchaseUnitRequest()
                    {
                        AmountWithBreakdown = new AmountWithBreakdown()
                        {
                            CurrencyCode = "USD",
                            Value = totalString
                        }
                    }
                },
                ApplicationContext = new ApplicationContext()
                {
                    ReturnUrl = "http://www.webshop.nillertron.com/api/Order/"+ordre.Id,
                    CancelUrl = "http://www.webshop.nillertron.com"
                }
            };

            var request = new OrdersCreateRequest();
            request.Prefer("return=representation");
            request.RequestBody(order);
            response = await Client().Execute(request);
            var statusCode = response.StatusCode;
            Order result = response.Result<Order>();
            var url = result.Links.Where(x => x.Rel.ToLower() == "approve").FirstOrDefault();
            return url.Href;

        }
        //public async Task captureOrder(string ordreId, int ourOurderId)
        //{
        //    // Construct a request object and set desired parameters
        //    // Replace ORDER-ID with the approved order id from create order
        //    bool succes = false;
        //    for(int i = 0; i<3600; i++)
        //    {
        //        var request = new OrdersGetRequest(ordreId);
        //        HttpResponse response = await Client().Execute(request);
        //        var statusCode = response.StatusCode;
        //        if(statusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            Order result = response.Result<Order>();
        //            if(result.Status.ToUpper() == "COMPLETED" || result.Status.ToUpper() == "APPROVED")
        //            {
        //                Succes?.Invoke(ourOurderId);
        //                succes = true;
        //                break;
        //            }
        //            else if(result.Status.ToUpper() == "VOIDED")
        //            {
        //                break;
        //            }
        //        }
        //        await Task.Delay(1000);
        //    }
        //    if(!succes)
        //    {
        //        Failure?.Invoke(ourOurderId);
        //    }


        //}
    }
}
