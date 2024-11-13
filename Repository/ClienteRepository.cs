using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitTecnicoDPlus.Helpers;
using FitTecnicoDPlus.Model;

namespace FitTecnicoDPlus.Repository
{
    public class ClienteRepository 
    {
        public SQLiteConnection connection;
        public string mensagemBD {  get; set; }

        public ClienteRepository()
        {
            connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            connection.CreateTable<Cliente>();
        }
        public void Add(Cliente cliente)
        {
            int result = 0;
            try
            {
                result = connection.Insert(cliente);
                mensagemBD = $"{result} linha(s) inseridas";
            }
            catch (Exception ex)
            {
                mensagemBD = $"Error: {ex.Message}";
                
            }
        }
        public void Update(Cliente cliente)
        {
            if(cliente == null) return;
            int result = 0;
            try
            {
                if (cliente.Id != 0)
                {
                    result = connection.Update(cliente);
                    mensagemBD = $"{result} linha(s) alteradas";
                }

            }
            catch (Exception ex)
            {
                mensagemBD = $"Error: {ex.Message}";

            }
        }

        public ICollection<Cliente> GetAll()
        {
            try
            {
                return connection.Table<Cliente>().ToList();
            }
            catch (Exception ex)
            {
                mensagemBD = $"Error: {ex.Message}";
            }
            return null;
        }

        public Cliente Get(int id)
        {
            try
            {
                return connection.Table<Cliente>().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                mensagemBD = $"Error: {ex.Message}";
            }
            return null;
        }

        public void Delete(Cliente cliente) 
        {
            try
            {
                    connection.Delete(cliente);
            }
            catch (Exception ex)
            {
                mensagemBD = $"Error: {ex.Message}";
            }
        }

    }
}
