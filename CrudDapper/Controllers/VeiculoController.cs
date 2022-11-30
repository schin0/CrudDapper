using Domain.Arguments;
using Domain.Filters.Veiculo;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;

namespace CrudDapper.Controllers
{
    [Route("api/[controller]")]
    public class VeiculoController : Controller
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] VeiculoRequest model)
        {
            return Ok(_veiculoService.Insert(model.ToDomain()));
        }

        [HttpPut]
        public IActionResult Put([FromBody] VeiculoRequest model)
        {
            return Ok(_veiculoService.Update(model.ToDomain()));
        }

        [HttpDelete("{id},{tenantId}")]
        public IActionResult Delete(int id, Guid tenantId)
        {
            return Ok(_veiculoService.Delete(id, tenantId));
        }

        [HttpGet("{id},{tenantId}")]
        public IActionResult Get(int id, Guid tenantId)
        {
            return Ok(_veiculoService.GetById(id, tenantId));
        }

        [HttpGet]
        public IActionResult List(FiltroVeiculo filtro)
        {
            return Ok(_veiculoService.List(filtro));
        }

    }
}
