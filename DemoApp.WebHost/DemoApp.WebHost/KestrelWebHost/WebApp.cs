using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DemoApp.WebHost.Managers;
using DemoApp.WebHost.Models;

namespace DemoApp.WebHost.KestrelWebHost
{
    public class WebApp
    {

        private readonly IReceiptManager _receiptManager;
        
        private const string StartReceipt = "/StartReceipt";
        private const string AddItemToReceipt = "/AddItemToReceipt";
        private const string RemoveItemInReceipt = "/RemoveItemInReceipt";
        private const string FinishReceipt = "/FinishReceipt";
        
        
        private static readonly byte[] _helloWorldBytes = Encoding.UTF8.GetBytes(
            "Hello rom Kestrel serverrr");
        
        private static WebApp instance = new WebApp();
        private static WebApp Instance
        {
            get { return instance; }
        }

        public WebApp()
        {
            _receiptManager = new ReceiptManager();
        }

     

        public static Task OnHttpRequest(HttpContext httpContext)
        {
            
            try
            {
                Instance.RecognizeMethod(httpContext);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            var response = httpContext.Response;
            response.StatusCode = 200;
            response.ContentType = "text/plain";
            
            var helloWorld = _helloWorldBytes;
            response.ContentLength = helloWorld.Length;
             return response.Body.WriteAsync(helloWorld, 0, helloWorld.Length);
        }
        
        

        public   void RecognizeMethod(HttpContext context)
        {
        
            switch (context.Request.Path)
            {
                case StartReceipt:
                    var value = (ReceiptModel)DeserializeBody(context);
                    _receiptManager.StartReceipt(value);
                    break;
                case AddItemToReceipt:
                    var value1 = (ReceiptItemModel)DeserializeBody(context);
                    _receiptManager.AddItemToReceipt(value1);
                    break;
                case RemoveItemInReceipt:
                    var value2 = (Int32)DeserializeBody(context);
                    _receiptManager.RemoveItemInReceipt(value2);
                    break;
                case FinishReceipt:
                    var value3 = (bool)DeserializeBody(context);
                    _receiptManager.FinishReceipt(value3);
                    break;
                
            }
            
        }
        
        public static object DeserializeBody(HttpContext context)
        {
            return new object(); // TODO
        }
    }
}
