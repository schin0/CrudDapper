using Domain.Models.Veiculo;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;

namespace CrudDapper.Controllers
{
    [Route("api/[controller]")]
    public class VeiculoController : Controller
    {
        // TODO: Inserir um validator para regras de negócio
        private readonly IVeiculoService _veiculoService;

        // TODO: Retornar IActionResult em todos endpoints
        [HttpPost]
        public Veiculo Post([FromBody] Veiculo model)
        {
            return (_veiculoService.Insert(model));
        }

        [HttpPut]
        public bool Put([FromBody] Veiculo model)
        {
            return (_veiculoService.Update(model));
        }

        [HttpDelete("{id},{tenantId}")]
        public bool Delete(int id, Guid tenantId)
        {
            return (_veiculoService.Delete(id, tenantId));
        }

        [HttpGet("{id},{tenantId}")]
        public Veiculo Get(int id, Guid tenantId)
        {
            return (_veiculoService.GetById(id, tenantId));
        }
    }
}
