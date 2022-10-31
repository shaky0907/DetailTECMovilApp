using DetailTECMovilApp.Models;
using DetailTECMovilApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DetailTECMovilApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroCitas : ContentPage
    {
        public RegistroCitas()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                CitasView.ItemsSource = await App.MyDataBase.getClientCitas(App.mainuser.ID_dueno);
            }
            catch
            {

            }
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CitaDetail());
        }

        async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var cita = item.CommandParameter as Cita;
            await Navigation.PushAsync(new CitaDetail(cita));
        }

        async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var cita = item.CommandParameter as Cita;
            var result = await DisplayAlert("Delete",$"Quiere eliminar la cita #{cita.Num_cita} de sus citas","Yes","No");
            if (result)
            {
                await App.MyDataBase.DeleteCita(cita);
                CitasView.ItemsSource = await App.MyDataBase.ReadCitas();
            }
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            CitasView.ItemsSource = await App.MyDataBase.SearchCita(e.NewTextValue);
        }

        private async void SwipeItem_Invoked_2(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var cita = item.CommandParameter as Cita;
            var citaInfoPage = new CitaInfo();
            citaInfoPage.BindingContext = cita;
            await Navigation.PushAsync(citaInfoPage);
        }
    }
}