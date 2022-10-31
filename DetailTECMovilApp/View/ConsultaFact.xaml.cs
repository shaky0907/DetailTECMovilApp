using DetailTECMovilApp.Models;
using DetailTECMovilApp.View;
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
    public partial class ConsultaFact : ContentPage
    {
        public ConsultaFact()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();

                List<Cita> citas = await App.MyDataBase.getClientCitas(App.mainuser.ID_dueno);

                await App.MyDataBase.deleteFacturas();

                foreach(Cita cita in citas)
                {
                    string var;
                    if (cita.tipoPago)
                    {
                        var = "Puntos";
                    }
                    else
                    {
                        var = "Tarejeta/Efecivo";
                    }
                    await App.MyDataBase.CreateFactura(new Factura()
                    {
                        Cita_Facturada = cita.Num_cita,
                        tipo_de_pago = var,
                        monto = 15000,
                        client_id = App.mainuser.ID_dueno
                    });
                }
                FacturaView.ItemsSource = await App.MyDataBase.getClientFacturas(App.mainuser.ID_dueno);
            }
            catch
            {

            }
        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var cita = item.CommandParameter as Factura;
            var citaInfoPage = new FacturaInfo();
            citaInfoPage.BindingContext = cita;
            await Navigation.PushAsync(citaInfoPage);
        }
    }
}