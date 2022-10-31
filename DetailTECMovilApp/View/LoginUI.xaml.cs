using DetailTECMovilApp.Models;
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

        private async void Login(object sender, EventArgs e)
        {
            Usuario user = await App.MyDataBase.SearchUser(txtUsername.Text, txtPassword.Text);
            Console.WriteLine("===============================");
            
            Console.WriteLine(txtUsername.Text);
            Console.WriteLine(txtPassword.Text);
           
            
            
            if(user != null)
            {
                Application.Current.MainPage = new Home();
                App.mainuser = user;
            }
            else
            {
                await DisplayAlert("Error","El usuario ingresado no existe o se ingreso la constraseña incorrecta","Ok");
            }
        }
    }
}