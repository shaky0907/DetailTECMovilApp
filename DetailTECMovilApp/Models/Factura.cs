using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DetailTECMovilApp.Models
{
    public class Factura
    {
        [PrimaryKey,AutoIncrement]
        public int Numero_factura { get; set; }
        public int Cita_Facturada { get; set; }
        public string tipo_de_pago { get; set; }
        public int monto { get; set; }
        public string client_id { get; set; }

    }
}
