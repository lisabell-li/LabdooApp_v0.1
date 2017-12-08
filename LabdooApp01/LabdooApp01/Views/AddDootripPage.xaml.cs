using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ModernHttpClient;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;

/*
 * View of "Create Dootrip page" which contains a form to create a new dootrip
 */
namespace LabdooApp01.Views
{
    /*
     * helperclass to create Edoovillage objects for the Edoovillage picker
     */
    public class EdoovillagesForPicker
    {
       // public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }
  

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddDootripPage : ContentPage
    {

        private IList<EdoovillagesForPicker> _edoovillages;
        private const string Url = "http://jsonplaceholder.typicode.com/posts";
        private const string Url2 = "http://jsonplaceholder.typicode.com/posts";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<EdoovillagesForPicker> _schools;
        private DootripPage dootripPageInst = new DootripPage();

        public AddDootripPage()
        {           
            InitializeComponent();
            /*_edoovillages = GetEdoovillages();
            foreach (var school in GetEdoovillages())
                EdoovillagesPicker.Items.Add(school.Name);*/
        }
        /*
         * Overrides the standard onAppearing Method
         * Edoovillages: retrieves the jsononOject from the url given and saves it to the edoovillagepicker in the form
         */
        async protected override void OnAppearing()
        {

            var client = new HttpClient();
            var content = await client.GetStringAsync(Url);
            var edoovillagesFromContent = JsonConvert.DeserializeObject<List<EdoovillagesForPicker>>(content);
            _schools = new ObservableCollection<EdoovillagesForPicker>(edoovillagesFromContent);
            foreach (var school in _schools)     
                    EdoovillagesPicker.Items.Add(school.Title);
                
            base.OnAppearing();
        }

        //If the user already knows to which edoovillage he would like to go to
        public void YesClicked(Object render, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Yes was clicked");
            EdoovillageSection.IsVisible=true;

        }

        //If the userdoes not know to which edoovillage to go to
        public void NoClicked(Object render, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("No was clicked");
            EdoovillageSection.IsVisible=false;
           
        }

        //Picker for Edoovillages
        private void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (EdoovillagesPicker != null && EdoovillagesPicker.SelectedIndex <= EdoovillagesPicker.Items.Count)
            {
               var selectedEdoovillageName = EdoovillagesPicker.Items[EdoovillagesPicker.SelectedIndex];
                DisplayAlert("You selected edoovillages:", selectedEdoovillageName, "OK");
                
            }
        }
        /*
         * Add Dootrip via POST Request and by just adding a title. The other fields are being ignored
        */
        public void SaveDootrip(Object sender, EventArgs e)
        {
            DisplayAlert("Your Dootrip to "+ DestinationEntry.Text  + " has been saved", "We did send you a verification email. After you verified your email address we will publish your dootrip. ", "OK");
            string  dootripTitle = "Dootrip von "+ OriginCountry.Text + " nach " +  DestinationEntry.Text; 
            var dootrip = new Dootrips { Title = "Title" + dootripTitle };
            var content = JsonConvert.SerializeObject(dootrip);
            _client.PostAsync(Url2, new StringContent(content));
            /*
             * TODO: 
             * -add all required fields to the POST request and form. Minimize required fields on labdoo.org
             * -Add dootrip to dootripPage view
             */
        }
/*
     

         /*
          * EventHandler for Departure DatePicker
          * If the departure date is being set than the arrivaldate will be set to departure date + 2 days
          */
        private void DatePicker_DepartureDateSelected(object sender, DateChangedEventArgs e)
        {
            var selectedDate = e.NewDate;
            ArrivalDatePicker.Date = e.NewDate.AddDays(2);
        }

        /*
          * EventHandler for Arrival DatePicker
          * 
          */
        private void DatePicker_ArrivalDateSelected(object sender, DateChangedEventArgs e)
        {
            var selectedDate = e.NewDate;
        }
        
    }

 
   
}
