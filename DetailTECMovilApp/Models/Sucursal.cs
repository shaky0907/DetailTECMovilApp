using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace DetailTECMovilApp.Models
{
    [Table("Sucursal")]
    public class Sucursal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Ced_Admin { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_apertura { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }

        public string Telefono { get; set; }
        public string Fecha_Gerente { get; set; }
    }
}
