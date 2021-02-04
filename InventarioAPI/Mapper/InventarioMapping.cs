using AutoMapper;
using InventarioAPI.Models;
using InventarioAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Mapper
{
    public class InventarioMapping:Profile
    {
        public InventarioMapping()
        {
            CreateMap<Inventario, InventarioDTO>().ReverseMap();
            CreateMap<Inventario, InventarioSimpleDTO>().ReverseMap();

        }
    }
}
