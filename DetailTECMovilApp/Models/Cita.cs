using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace DetailTECMovilApp.Models
{
    public class Cita
    {
        [PrimaryKey,AutoIncrement]
        public int Num_cita { get; set; }
        [MaxLength(50)]
        public string ID_Sucursal { get; set; }
        //public string CedTrabajador { get; set; }
        //public string CedCliente { get; set; }
        public string TipoLavado { get; set; }
        //public string PlacaVehiculo { get; set; }
        //public DateTime Fecha_hora { get; set; }
    }
}
