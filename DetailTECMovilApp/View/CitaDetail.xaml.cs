using DetailTECMovilApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

            sucursalEntry.Text = "No Office Selected";
            sucursalEntry.IsVisible = false;
            tipolavadoEntry.IsVisible = false;
            sucLabel.IsVisible = false;
            lavadolabel.IsVisible = false;
            

        }

        Models.Cita _cita;
        List<Sucursal> sucursales;
        List<TipoLavado> lavados;
        public CitaDetail(Models.Cita cita)
        {
            InitializeComponent();
            Title = "Edit Appointment";
            _cita = cita;
            
            sucursalEntry.Text = cita.SucursalNombre;
            sucursalEntry.IsVisible = true;
            tipolavadoEntry.IsVisible = true;
            tipolavadoEntry.Text = cita.TipoLavado;
            sucLabel.IsVisible = true;
            lavadolabel.IsVisible = true;
            
            fechaEntry.Date = cita.Fecha;

            tiempoEntry.Time = cita.Hora;

            placaEntry.Text = cita.PlacaVehiculo;

            pagoEntry.IsChecked = cita.tipoPago;
            sucursalEntry.Focus();
            
           

        }

        
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                sucursales = await App.MyDataBase.ReadSucursal();
                SucursalPick.ItemsSource = sucursales;
                lavados = await App.MyDataBase.ReadTipoLavado();
                TipoLavadoPick.ItemsSource = lavados;
            }
            catch
            {

            }
        }

        

        async void Button_Save(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SucursalPick.SelectedItem.ToString()) || string.IsNullOrWhiteSpace(TipoLavadoPick.SelectedItem.ToString()))
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
           
            Factura fac = await App.MyDataBase.searchFactura(_cita.Num_cita);
            
            _cita.ID_Sucursal = SucursalPick.SelectedIndex;
            _cita.SucursalNombre = sucursales[SucursalPick.SelectedIndex].Nombre.ToString();
            _cita.TipoLavado = lavados[TipoLavadoPick.SelectedIndex].Nombre.ToString();
      
            _cita.FechaM = fechaEntry.Date.ToString("dd/MM/yyyy");
            _cita.Fecha = fechaEntry.Date;
            _cita.Hora = tiempoEntry.Time;
            _cita.PlacaVehiculo = placaEntry.Text;
            _cita.CedCliente = App.mainuser.ID_dueno;
            _cita.tipoPago = pagoEntry.IsChecked;

            

            await App.MyDataBase.UpdateCita(_cita);
            await Navigation.PopAsync();
        }

        async void AddNewCita()
        {
            DateTime fechhora = fechaEntry.Date;
            fechhora.AddHours(tiempoEntry.Time.Hours).AddMinutes(tiempoEntry.Time.Minutes);
            await App.MyDataBase.CreateCita(new Models.Cita
            {
                
                ID_Sucursal = SucursalPick.SelectedIndex,
                SucursalNombre = sucursales[SucursalPick.SelectedIndex].Nombre.ToString(),
                TipoLavado = lavados[TipoLavadoPick.SelectedIndex].Nombre.ToString(),
                Fecha = fechaEntry.Date,
                FechaM = fechaEntry.Date.ToString("dd/MM/yyyy"),
                Hora = tiempoEntry.Time,
                PlacaVehiculo = placaEntry.Text,
                CedCliente = App.mainuser.ID_dueno,
                tipoPago = pagoEntry.IsChecked

            });

            Cliente cliente = await App.MyDataBase.SearchCliente(App.mainuser.ID_dueno);
            
          
            cliente.puntos += lavados[TipoLavadoPick.SelectedIndex].Puntacion;
            Console.WriteLine(cliente.puntos);
            await App.MyDataBase.UpdateCliente(cliente);


            await Navigation.PopAsync();
        }
    }
}