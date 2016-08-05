﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParkingRampApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            var client = new HttpClient(new HttpClientHandler
                { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            var json = await client.GetStringAsync("http://parkingrampsimulatorservices.azurewebsites.net/api/FacilityStatus");
            var obj = JsonConvert.DeserializeObject<FacilityStatus>(json);
            this.OutputText.Text = string.Format("{0:0.#}", obj.PercentageOpen);
        }
    }
}
