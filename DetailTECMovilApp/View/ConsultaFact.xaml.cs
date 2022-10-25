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
            App.MyDataBase.CreateFactura(new Models.Factura()
            {
                Cita_Facturada=1,
                monto="$200",
                tipo_de_pago= "Efectivo"
            });
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                FacturaView.ItemsSource = await App.MyDataBase.ReadFacturas();
            }
            catch
            {

            }
        }

        private void SwipeItem_Invoked(object sender, EventArgs e)
        {

        }
    }
}