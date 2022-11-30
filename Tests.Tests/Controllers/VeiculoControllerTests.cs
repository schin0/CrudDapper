using CrudDapper.Controllers;
using Domain.Arguments;
using Domain.Filters.Veiculo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Tests.Mocks;
using Xunit;

namespace Tests.Tests.Controllers
{
    public class VeiculoControllerTests
    {
        private readonly IVeiculoService _mockService;
        private readonly VeiculoController _controller;

        public VeiculoControllerTests()
        {
            _mockService = Substitute.For<IVeiculoService>();

            _controller = new VeiculoController(_mockService);
        }

        #region Tests

        [Fact]
        public void Must_Call_Service_To_Delete()
        {
            _mockService.Delete(Arg.Any<int>(), Arg.Any<Guid>()).Returns(true);

            var response = _controller.Delete(1, Guid.NewGuid());

            var objectResult = Assert.IsType<OkObjectResult>(response);

            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsType<bool>(objectResult.Value);

            _mockService.Received().Delete(Arg.Any<int>(), Arg.Any<Guid>());
        }

        [Fact]
        public void Must_Call_Service_To_Get()
        {
            _mockService.GetById(Arg.Any<int>(), Arg.Any<Guid>()).Returns(GetVeiculo());

            var response = _controller.Get(1, Guid.NewGuid());

            var objectResult = Assert.IsType<OkObjectResult>(response);

            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsType<Domain.Models.Veiculo.Veiculo>(objectResult.Value);

            _mockService.Received().GetById(Arg.Any<int>(), Arg.Any<Guid>());
        }

        [Fact]
        public void Must_Call_Service_To_Insert()
        {
            _mockService.Insert(Arg.Any<Domain.Models.Veiculo.Veiculo>()).Returns(GetVeiculo());

            var response = _controller.Post(GetVeiculoRequest());

            var objectResult = Assert.IsType<OkObjectResult>(response);

            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsType<Domain.Models.Veiculo.Veiculo>(objectResult.Value);

            _mockService.Received().Insert(Arg.Any<Domain.Models.Veiculo.Veiculo>());
        }
        
        [Fact]
        public void Must_Call_Service_To_Update()
        {
            _mockService.Update(Arg.Any<Domain.Models.Veiculo.Veiculo>()).Returns(true);

            var response = _controller.Put(GetVeiculoRequest());

            var objectResult = Assert.IsType<OkObjectResult>(response);

            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsType<bool>(objectResult.Value);

            _mockService.Received().Update(Arg.Any<Domain.Models.Veiculo.Veiculo>());
        }
        
        [Fact]
        public void Must_Call_Service_To_List()
        {
            var veiculoList = ListVeiculos();

            _mockService.List(Arg.Any<FiltroVeiculo>()).Returns(veiculoList);

            var response = _controller.List(new FiltroVeiculo());

            var objectResult = Assert.IsType<OkObjectResult>(response);

            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsType<List<Domain.Models.Veiculo.Veiculo>>(objectResult.Value);

            _mockService.Received().List(Arg.Any<FiltroVeiculo>());
        }

        #endregion

        #region Mocks
        private static VeiculoRequest GetVeiculoRequest()
            => new()
            {
                Cor = Domain.Enums.CorEnum.Branco,
                Km = 123,
                ModeloId = 1,
                Placa = "ABC1234",
                TenantId = Guid.NewGuid()
            };

        private static Domain.Models.Veiculo.Veiculo GetVeiculo() => VeiculoMock.GetVeiculo();

        private static List<Domain.Models.Veiculo.Veiculo> ListVeiculos() => VeiculoMock.ListVeiculos();

        #endregion
    }
}
