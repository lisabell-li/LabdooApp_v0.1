﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Collections.ObjectModel;


/*
 * View of " Dootrip page" which contains a list of the dootrips
 */
namespace LabdooApp01.Views
{

    /*
    * helperclass to create Edoovillage objects for the Edoovillage picker
    */
    public class Dootrips
    {
        // public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DootripPage : ContentPage
    {

        private IList<Dootrips> _dootrips;
        private const string Url = "http://jsonplaceholder.typicode.com/posts";
        public ObservableCollection<Dootrips> _dootripsCollection;


        public DootripPage()
        {
            InitializeComponent();
        }

        async void AddDootrip_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddDootripPage());
        }
        /*
        * Overrides the standard onAppearing Method
        * Dootrips: retrieves the jsononOject from the url given and shows the titles of the dootrips as a list
        */
        async protected override void OnAppearing()
        {

            var client = new HttpClient();
            var content = await client.GetStringAsync(Url);
            var dootripsFromContent = JsonConvert.DeserializeObject<List<Dootrips>>(content);
            _dootripsCollection = new ObservableCollection<Dootrips>(dootripsFromContent);
            dootripListView.ItemsSource = _dootripsCollection;

            base.OnAppearing();
        }


    }

    
}
