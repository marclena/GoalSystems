using InventarioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository.IRepository
{
    public class InventarioRepository : IInventarioRepository
    {
        private List<Inventario> _inventarios = new List<Inventario>();

        public InventarioRepository()
        {
            _inventarios.Add(new Inventario { Nombre = "test", Tipo = "Fragil", FechaCaducidad = DateTime.Now, Color="Rojo",Peso="10"});
            _inventarios.Add(new Inventario { Nombre = "test1", Tipo = "Fragil", FechaCaducidad = DateTime.Now, Color = "Amarillo", Peso = "20" });
            _inventarios.Add(new Inventario { Nombre = "test2", Tipo = "Fragil", FechaCaducidad = DateTime.Now, Color = "Verde", Peso = "30" });
        }
        public bool AddInventario(Inventario inventario)
        {
            _inventarios.Add(inventario);
            return true;
        }

        public ICollection<Inventario> GetAllInventarios()
        {
           
            return _inventarios;
        }

        public Inventario GetInventarioByName(string name)
        {
            return _inventarios.Where(p => p.Nombre == name).FirstOrDefault();
        }

        public bool CheckInventarioByName(string name)
        {
            return _inventarios.Exists(p => p.Nombre == name);
        }

       public  bool DeletekInventarioByName(string name)
        {
            var obj= _inventarios.Where(p => p.Nombre == name).FirstOrDefault();
            return _inventarios.Remove(obj);
        }
    }
}
