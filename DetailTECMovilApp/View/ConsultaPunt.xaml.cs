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
    public partial class ConsultaPunt : ContentPage
    {
        public ConsultaPunt()
        {
            InitializeComponent();
        }

        Cliente cliente;
        List<Factura> facutras;
        Cita cita;
        TipoLavado lavado;
        protected override async void OnAppearing()
        {
            try
            {

                base.OnAppearing();
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
                cliente = await App.MyDataBase.SearchCliente(App.mainuser.ID_dueno);
                
                Totales.Text = cliente.puntos.ToString();
                
                facutras = await App.MyDataBase.getClientFacturas(App.mainuser.ID_dueno);
                
                



                int redimidos = 0;
                foreach(Factura fac in facutras)
                {
                    Console.WriteLine("XD");
                    if(fac.tipo_de_pago == "Puntos")
                    {
                        cita = await App.MyDataBase.getCita(fac.Cita_Facturada);
                        lavado = await App.MyDataBase.SearchLavadoPorN(cita.TipoLavado);
                        redimidos += lavado.Puntacion;
                        Console.WriteLine(lavado.Puntacion);
                    }
                }
                
                Redimidos.Text = redimidos.ToString();

                Disponibles.Text = (cliente.puntos - redimidos).ToString();

                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine(cliente.puntos);

            }
            catch
            {

            }
        }

    }
}