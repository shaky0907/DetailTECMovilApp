using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using DetailTECMovilApp.Models;
using System.Security.Cryptography;

namespace DetailTECMovilApp
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;


        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Cita>();
            db.CreateTableAsync<Usuario>();
            db.CreateTableAsync<Factura>();
            
        }

        //CITA=========================================================
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

        
        public Task<List<Cita>> SearchCita(string search)
        {
            return db.Table<Cita>().Where(p => p.TipoLavado.StartsWith(search)).ToListAsync();
        }

        //FACTURA===========================================================================
        public Task<int> CreateFactura(Factura factura)
        {
            return db.InsertAsync(factura);
        }


        public Task<List<Factura>> ReadFacturas()
        {
            return db.Table<Factura>().ToListAsync();
        }


        public Task<int> UpdateFactura(Factura factura)
        {
            return db.UpdateAsync(factura);
        }

        public Task<int> DeleteFactura(Factura factura)
        {
            return db.DeleteAsync(factura);
        }



        //USUARIO==========================================================================

        public Task<int> CreateUser(Usuario user)
        {
            return db.InsertAsync(user);
        }
        public Task<Usuario> SearchUser(string userin, string passin)
        {
            var user = db.FindAsync<Usuario>(userin);
            Console.WriteLine("============================================");
            //var user =  db.Table<Usuario>().Where(p => ( p.username == userin && p.password == passin)).FirstOrDefaultAsync();
            return user;
            
           
        }




    }
}
