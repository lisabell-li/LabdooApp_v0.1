using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
      public int Id { get; set; }
      public string Title { get; set; }
      public string Body { get; set; }
    }


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddDootripPage : ContentPage
    {

        private IList<EdoovillagesForPicker> _edoovillages;
        private const string Url = "http://jsonplaceholder.typicode.com/posts";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<EdoovillagesForPicker> _schools;

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
            var content =await _client.GetStringAsync(Url);
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

        public void SaveDootrip(Object render, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Forms should be saved now");
        }
/*
        private IList<EdoovillagesForPicker> GetEdoovillages()
        {
            return new List<EdoovillagesForPicker>
        {
            new EdoovillagesForPicker{ Id = 1, Title ="PNH Orphanage Nepal" },
             new EdoovillagesForPicker{ Id = 1, Title ="Hope School Kathmandu" }
        };
        }*/

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
