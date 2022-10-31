using DetailTECMovilApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DetailTECMovilApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClienteGestion : ContentPage
    {
        Cliente cliente;
        public ClienteGestion()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                Console.WriteLine("ID:");
                Console.WriteLine(App.mainuser);

                
                cliente = await App.MyDataBase.SearchCliente(App.mainuser.ID_dueno);
                
            
                NameDisplay.Text = cliente.Nombre;
                CedulaDisplay.Text = cliente.Cedula;
                ApDisplay.Text = cliente.Apellido1+" "+cliente.Apellido2;
                CorreoDisplay.Text = cliente.Correo;
                Contraseña.Text = App.mainuser.password;
            }
            catch
            {

            }
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Contraseña.Text))
            {
                await DisplayAlert("Invalido", "Espacio en blanco o vacio no es valido", "OK");
            }
            else
            {
                App.mainuser.password = Contraseña.Text;
                await App.MyDataBase.UpdateClienteUser(App.mainuser);
                await DisplayAlert("Cambio Completado", "Su contraseña ha sido cambiada","OK");
            }
            
        }
    }
}