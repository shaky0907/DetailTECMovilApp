using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace DetailTECMovilApp.Models
{
    [Table("Cita")]
    public class Cita
    {
        [PrimaryKey,AutoIncrement]
        public int Num_cita { get; set; }
        [MaxLength(50)]
        public int ID_Sucursal { get; set; }
        public string SucursalNombre { get; set; }
        public string CedTrabajador { get; set; }
        public string CedCliente { get; set; }
        public string TipoLavado { get; set; }
        public string PlacaVehiculo { get; set; }
        public TimeSpan Hora { get; set; }
        public string FechaM { get; set; }
        public DateTime Fecha { get; set; }
        public bool tipoPago { get; set; }
        
    }
}
