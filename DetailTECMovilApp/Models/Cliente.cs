using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace DetailTECMovilApp.Models
{
    public class Cliente
    {
        [PrimaryKey]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public int puntos { get; set; }

    }
}
