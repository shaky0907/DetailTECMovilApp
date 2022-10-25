using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace DetailTECMovilApp.Models
{
    public class Usuario
    {
        [PrimaryKey]
        public string username { get; set; }
        [MaxLength(15)]
        public string password { get; set; }

        public string ID_dueno { get; set; }
        public string tipo { get; set; }

    }
}
