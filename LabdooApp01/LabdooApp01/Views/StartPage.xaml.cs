using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


/*
 * View of the start screen which contains buttons for easy access
 */
namespace LabdooApp01.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {

            InitializeComponent();
        }
        async void AddDootrip_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddDootripPage());
        }
        
            async void ShowDootrip_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DootripPage());
        }
        
                async void ShowDootronics_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DootronicsPage());
        }
    }

  

       
}
