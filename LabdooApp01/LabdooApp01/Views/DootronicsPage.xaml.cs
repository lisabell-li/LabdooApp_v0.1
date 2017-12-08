using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LabdooApp01.Views
{
    public class Dootronics
    {
        // public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DootronicsPage : ContentPage
    {

        private IList<Dootrips> _dootronics;
        private const string Url = "http://jsonplaceholder.typicode.com/posts";
        public ObservableCollection<Dootronics> _dootronicsCollection;


        public DootronicsPage()
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
            var dootronicsFromContent = JsonConvert.DeserializeObject<List<Dootronics>>(content);
            _dootronicsCollection = new ObservableCollection<Dootronics>(dootronicsFromContent);
            dootripListView.ItemsSource = _dootronicsCollection;

            base.OnAppearing();
        }

    }

}
