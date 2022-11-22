using Domain.Interfaces.Dapper;
using Domain.Models.Veiculo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDapper.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class oi : Controller
    {
        private readonly IDapperRepository _dapper;

        public oi(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        [HttpGet]
        public List<Veiculo> Get([FromQuery] Domain.Filters.Veiculo.FiltroVeiculo filtro)
        {
            return _dapper.List(filtro);
        }
    }
}
