using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using DetailTECMovilApp.Models;


namespace DetailTECMovilApp
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;


        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Cita>();
        }

        public Task<int> CreateCita (Cita cita)
        {
            return db.InsertAsync(cita);
        }


        public Task<List<Cita>> ReadCitas()
        {
            return db.Table<Cita>().ToListAsync();
        } 


        public Task <int> UpdateCita(Cita cita)
        {
            return db.UpdateAsync(cita);
        }

        public Task<int> DeleteCita(Cita cita)
        {
            return db.DeleteAsync(cita);
        }

        public Task<List<Cita>> Search(string search)
        {
            return db.Table<Cita>().Where(p => p.TipoLavado.StartsWith(search)).ToListAsync();
        }
    }
}
