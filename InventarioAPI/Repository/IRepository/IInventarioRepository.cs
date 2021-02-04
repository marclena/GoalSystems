using InventarioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository.IRepository
{
    public interface IInventarioRepository
    {
        public bool AddInventario(Inventario inventario);
        public Inventario GetInventarioByName(string name);
        public ICollection<Inventario> GetAllInventarios();

        public bool CheckInventarioByName(string name);

        public bool DeletekInventarioByName(string name);
    }
}
