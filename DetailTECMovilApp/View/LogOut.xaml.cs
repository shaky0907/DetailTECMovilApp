using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DetailTECMovilApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogOut : ContentPage
    {
        public LogOut()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                App.Current.MainPage = new LoginUI();
            }
            catch
            {

            }
        }
    }
}