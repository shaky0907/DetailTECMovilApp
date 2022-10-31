using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace DetailTECMovilApp.Models
{
    [Table("TypoLavado")]
    public class TipoLavado
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Costo { get; set; }
        public int Duracion { get; set; }
        public int Puntacion { get; set; } 



    }
}
