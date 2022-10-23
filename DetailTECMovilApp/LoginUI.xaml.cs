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
    public partial class LoginUI : ContentPage
    {
        public LoginUI()
        {
            InitializeComponent();
        }

        private void Login(object sender, EventArgs e)
        {
            if(txtUsername.Text=="admin" && txtPassword.Text == "0907")
            {
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                DisplayAlert("Alert","No se ingreso correctamente la información","Ok");
            }
        }
    }
}