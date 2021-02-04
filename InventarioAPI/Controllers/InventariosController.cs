using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InventarioAPI.Models;
using InventarioAPI.Models.DTO;
using InventarioAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventariosController : ControllerBase
    {
        private InventarioRepository _inventarioRepo;
        private readonly IMapper _mapper;

        public InventariosController(InventarioRepository inventarioRepo, IMapper mapper)
        {
            _inventarioRepo = inventarioRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// GetInventarios devuelve todos los inventarios dados de alta
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(200,Type=typeof(List<InventarioSimpleDTO>))]
        [ProducesResponseType(400)]
        
        public IActionResult GetInventarios()
        {
            var objList = _inventarioRepo.GetAllInventarios();
           
            var objDTO=_mapper.Map<List<InventarioSimpleDTO>>(objList);
            return Ok(objDTO);
        }

        /// <summary>
        /// Esta funcion devuelve un inventario
        /// </summary>
        /// <param name="name"> Filtra los inventarios por el nombre</param>
        /// <returns></returns>
        [HttpGet("{name}",Name ="GetInventario")]
        public IActionResult GetInventarioByName(string name)
        {
            var objList = _inventarioRepo.GetInventarioByName(name);
            if (objList == null)
                return NotFound();

            var objDTO = _mapper.Map<InventarioDTO>(objList);
            return Ok(objDTO);
        }

        [HttpDelete("{name}", Name = "GetInventario")]
        public IActionResult DeleteInventarioByName(string name)
        {
            if (_inventarioRepo.DeletekInventarioByName(name))
            {
                return Ok("Inventario eliminado");
            }
            return NotFound();
            
        }

        /// <summary>
        /// Este metodo añadira un inventario si no existe
        /// </summary>
        /// <param name="inventario"> El objeto a añadir</param>
        /// <returns>Retornara un 201 created si es ok y un error si el inventario ya existe o hay un error de sistema</returns>
        [ProducesResponseType(201, Type = typeof(List<Inventario>))]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult CrearInventario([FromBody] Inventario inventario)
        {
            if (_inventarioRepo.CheckInventarioByName(inventario.Nombre))
            {
                ModelState.AddModelError("", "El Inventario Ya Existe");
                return StatusCode(404, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          
            if (!_inventarioRepo.AddInventario(inventario))
            {
                ModelState.AddModelError("", $"Algo ha ido mal al guardar el inventario {inventario.Nombre}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetInventario",new { name=inventario.Nombre }, inventario);
        }

    }



}
