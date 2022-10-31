using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using DetailTECMovilApp.Models;
using System.Security.Cryptography;
using System.Runtime.InteropServices.ComTypes;

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
            db.CreateTableAsync<Cliente>();
            db.CreateTableAsync<Factura>();
            db.CreateTableAsync<Sucursal>();
            db.CreateTableAsync<TipoLavado>();
            Populate();

        }




        public void Populate()
        {

            db.DeleteAllAsync<Sucursal>();
            db.InsertAsync(new Sucursal()
            {
                Nombre = "Cartago",
                Provincia = "Cartago",
                Canton = "tres rios",
                Distrito = "Distrito"
            });

            db.InsertAsync(new Sucursal()
            {
                Nombre = "San Jose",
                Provincia = "San Jose",
                Canton = "Santa Ana",
                Distrito = "Pozos"
            });

           
            db.InsertAsync(new Sucursal()
            {
                Nombre = "Alajuela",
                Provincia = "Alajuela",
                Canton = "San Rafael",
                Distrito = "---"
            });

            db.DeleteAllAsync<Cliente>();
            db.InsertAsync(new Cliente()
            {
                Cedula = "184002109016",
                Nombre = "David",
                Apellido1 = "De la Hoz",
                Apellido2 = "Aguirre",
                Correo = "divad0907@gmail.com"
            });

            db.InsertAsync(new Cliente()
            {
                Cedula = "123456789",
                Nombre = "Marcos",
                Apellido1 = "Gonzalez",
                Apellido2 = "Araya",
                Correo = "quigonar@gmail.com"
            });


            db.DeleteAllAsync<Usuario>();
            db.InsertAsync(new Usuario()
            {
                username = "david0907",
                password = "0907",
                tipo = "Cliente",
                ID_dueno = "184002109016"
            });
            db.InsertAsync(new Usuario()
            {
                username = "quigonar",
                password = "12345",
                tipo = "Cliente",
                ID_dueno = "123456789"
            });

            db.DeleteAllAsync<TipoLavado>();
            db.InsertAsync(new TipoLavado()
            {
                Nombre = "lavado y aspirado",
                Costo = 15000,
                Duracion = 30,
                Puntacion = 8

            });

            db.InsertAsync(new TipoLavado()
            {
                Nombre = "lavado encerado",
                Costo = 15000,
                Duracion = 30,
                Puntacion = 8

            });

            db.InsertAsync(new TipoLavado()
            {
                Nombre = "lavado premium",
                Costo = 15000,
                Duracion = 30,
                Puntacion = 8

            });
            
            db.InsertAsync(new TipoLavado()
            {
                Nombre = "pulido",
                Costo = 15000,
                Duracion = 30,
                Puntacion = 8

            });

           

            



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
        public Task<List<Cita>> getClientCitas(string id)
        {
            return db.Table<Cita>().Where(p => p.CedCliente == id).ToListAsync();
        }

        public Task<Cita> getCita(int id)
        {
            return db.Table<Cita>().Where(p => p.Num_cita == id).FirstOrDefaultAsync();
        }


       

        public Task<int> deleteFacturas()
        {
            return db.DeleteAllAsync<Factura>();
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

        public Task<List<Factura>> getClientFacturas(string id)
        {

            return db.Table<Factura>().Where(p => p.client_id == id).ToListAsync();
        }
        public Task<Factura> searchFactura(int id)
        {

            return db.Table<Factura>().Where(p => p.Cita_Facturada == id).FirstOrDefaultAsync();
        }

        

        //USUARIO==========================================================================

        public Task<int> CreateUser(Usuario user)
        {
            return db.InsertAsync(user);
        }
        public Task<Usuario> SearchUser(string userin, string passin)
        {
            var user =  db.Table<Usuario>().Where(p => ( p.username == userin && p.password == passin)).FirstOrDefaultAsync();
            return user;
            
        }

        public Task<List<Usuario>> Readuser()
        {
            return db.Table<Usuario>().ToListAsync();
        }


        //Sucursal============================================================================

        public Task<List<Sucursal>> ReadSucursal()
        {
            return db.Table<Sucursal>().ToListAsync();
        }

        public Task<Usuario> SearchSucursal(string userin, string passin)
        {
            var user = db.FindAsync<Usuario>(userin);
            Console.WriteLine("============================================");
            //var user =  db.Table<Usuario>().Where(p => ( p.username == userin && p.password == passin)).FirstOrDefaultAsync();
            return user;


        }

        //Tipo de Lavado=============================================

        public Task<List<TipoLavado>> ReadTipoLavado()
        {
            return db.Table<TipoLavado>().ToListAsync();
        }

        public Task<TipoLavado> SearchLavado(int  id)
        {

            var user = db.Table<TipoLavado>().Where(p => p.Id == id).FirstOrDefaultAsync();

            return user;

        }

        public Task<TipoLavado> SearchLavadoPorN(string id)
        {

            var user = db.Table<TipoLavado>().Where(p => p.Nombre == id).FirstOrDefaultAsync();

            return user;

        }

        //Cliente=========================================================0

        public Task<List<Cliente>> ReadCliente()
        {
            return db.Table<Cliente>().ToListAsync();
        }

        public Task<Cliente> SearchCliente(string cedula)
        {
     
            var user = db.Table<Cliente>().Where(p => p.Cedula == cedula).FirstOrDefaultAsync();
            
            return user;

        }

        public Task<int> UpdateClienteUser(Usuario user)
        {
            return db.UpdateAsync(user);
        }

        public Task<int> UpdateCliente(Cliente cliente)
        {
            return db.UpdateAsync(cliente);
        }


    }
}
