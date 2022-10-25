using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DetailTECMovilApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CitaDetail : ContentPage
    {
        public CitaDetail()
        {
            InitializeComponent();
        }

        Models.Cita _cita;
        public CitaDetail(Models.Cita cita)
        {
            InitializeComponent();
            Title = "Edit Cita";
            _cita = cita;
            sucursalEntry.Text = cita.ID_Sucursal;
            lavadoEntry.Text = cita.TipoLavado;
            sucursalEntry.Focus();
            
        }


        async void Button_Save(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sucursalEntry.Text) || string.IsNullOrWhiteSpace(lavadoEntry.Text))
            {
                await DisplayAlert("Invalido", "Espacio en blanco o vacio no es valido", "OK");
            }
            else if (_cita != null)
            {
                UpdateCita();
            }
            else
            {
                AddNewCita();
            }
        }

        async void UpdateCita()
        {
            _cita.ID_Sucursal = sucursalEntry.Text;
            _cita.TipoLavado = lavadoEntry.Text;
            await App.MyDataBase.UpdateCita(_cita);
            await Navigation.PopAsync();
        }

        async void AddNewCita()
        {
            await App.MyDataBase.CreateCita(new Models.Cita
            {
                ID_Sucursal = sucursalEntry.Text,
                TipoLavado = lavadoEntry.Text
            });
            await Navigation.PopAsync();
        }
    }
}