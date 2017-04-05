﻿using System;
using System.Net.Http;
using System.Text;
using Klarna.Payments;
using Klarna.Payments.Models;
using Refit;
using Xunit;

namespace Test.Integration
{
    public class KlarnaPaymentTests
    {
        private string _apiUrl = "https://api-na.playground.klarna.com/";
        private string _username = "N100198";
        private string _password = "Gee4mawush+u<el8";

        private string _tempClientToken =
            "eyJhbGciOiJub25lIn0.ewogICJzZXNzaW9uX2lkIiA6ICJmOWMxOTBiNi04ZDM4LTUzZmUtODBiZS0wODI5M2MyNWVjNzEiLAogICJiYXNlX3VybCIgOiAiaHR0cHM6Ly9jcmVkaXQtbmEucGxheWdyb3VuZC5rbGFybmEuY29tIiwKICAiZGVzaWduIiA6ICJrbGFybmEiLAogICJsYW5ndWFnZSIgOiAiZW4iLAogICJwdXJjaGFzZV9jb3VudHJ5IiA6ICJVUyIsCiAgInRyYWNlX2Zsb3ciIDogZmFsc2UKfQ.";

        private string _tempSessionId = "f9c190b6-8d38-53fe-80be-08293c25ec71";

        private IKlarnaServiceApi _klarnaServiceApi;

        public IKlarnaServiceApi KlarnaServiceApi
        {
            get
            {
                if (_klarnaServiceApi == null)
                {
                    var byteArray = Encoding.ASCII.GetBytes($"{_username}:{_password}");
                    var httpClient = new HttpClient
                    {
                        BaseAddress = new Uri(_apiUrl)
                    };
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    var refitSettings = new RefitSettings();

                    _klarnaServiceApi = RestService.For<IKlarnaServiceApi>(httpClient, refitSettings);
                }
                return _klarnaServiceApi;
            }
        }

        [Fact]
        public void CreateSession()
        {
            var session = GetSession();

            try
            {
                var result = KlarnaServiceApi.CreatNewSession(session).Result;
              
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.False(true);
            }
        }

        [Fact]
        public void UpdateSession()
        {
            var session = GetSession();

            try
            {
                KlarnaServiceApi.UpdateSession(_tempSessionId, session);

                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.False(true);
            }
        }

        private Session GetSession()
        {
            var session = new Session();
            session.Design = null;
            session.PurchaseCountry = "US";
            session.PurchaseCurrency = "USD";
            session.Locale = "en-ud";
            session.BillingAddress = null;
            session.ShippingAddress = null;
            session.OrderAmount = 1000;
            session.OrderTaxAmount = 0;
            session.OrderLines = new[]
            {
                new OrderLine { Name = "Product a", Quantity = 1, TotalAmount = 1000, UnitPrice = 1000 }
            };
            session.Customer = null;
            session.MerchantUrl = new MerchantUrl
            {
                Confirmation = "http://localhost:9000",
                Notification = "http://localhost:9000"
            };
            session.MerchantReference1 = null;
            session.MerchantReference2 = null;
            session.MerchantData = null;
            session.Body = null;
            session.Options = null;

            return session;
        }
    }
}
