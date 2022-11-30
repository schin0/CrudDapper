using Domain.Filters.Veiculo;
using Domain.Interfaces.Veiculo;
using NSubstitute;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Tests.Mocks;
using Xunit;

namespace Tests.Tests.Services.Veiculo
{
    public class VeiculoServiceTests : UnitTestBase
    {
        private readonly IVeiculoRepository _mockRepository;
        private readonly IVeiculoService _service;

        public VeiculoServiceTests()
        {
            _mockRepository = Substitute.For<IVeiculoRepository>();
            OverrideRegistration(provider => _mockRepository);

            _service = InstanceOf<IVeiculoService>();
        }

        #region Tests

        [Fact]
        public void Must_Delete()
        {
            _mockRepository.Delete(Arg.Any<int>(), Arg.Any<Guid>()).Returns(true);

            var result = _service.Delete(1, Guid.NewGuid());

            Assert.True(result);

            _mockRepository.Received().Delete(Arg.Any<int>(), Arg.Any<Guid>());
        }

        [Fact]
        public void Must_Get()
        {
            var veiculo = GetVeiculo();

            _mockRepository.GetById(Arg.Any<int>(), Arg.Any<Guid>()).Returns(veiculo);

            var result = _service.GetById(1, Guid.NewGuid());

            Assert.IsType<Domain.Models.Veiculo.Veiculo>(result);
            Assert.Equal(veiculo.Cor, result.Cor);
            Assert.Equal(veiculo.DataCadastro, result.DataCadastro);
            Assert.Equal(veiculo.Id, result.Id);
            Assert.Equal(veiculo.Km, result.Km);
            Assert.Equal(veiculo.ModeloId, result.ModeloId);
            Assert.Equal(veiculo.Placa, result.Placa);
            Assert.Equal(veiculo.TenantId, result.TenantId);

            _mockRepository.Received().GetById(Arg.Any<int>(), Arg.Any<Guid>());
        }

        [Fact]
        public void Must_Insert()
        {
            var veiculo = GetVeiculo();

            _mockRepository.Insert(Arg.Any<Domain.Models.Veiculo.Veiculo>()).Returns(veiculo);

            var result = _service.Insert(veiculo);

            Assert.IsType<Domain.Models.Veiculo.Veiculo>(result);
            Assert.Equal(veiculo.Cor, result.Cor);
            Assert.Equal(veiculo.DataCadastro, result.DataCadastro);
            Assert.Equal(veiculo.Id, result.Id);
            Assert.Equal(veiculo.Km, result.Km);
            Assert.Equal(veiculo.ModeloId, result.ModeloId);
            Assert.Equal(veiculo.Placa, result.Placa);
            Assert.Equal(veiculo.TenantId, result.TenantId);

            _mockRepository.Received().Insert(Arg.Any<Domain.Models.Veiculo.Veiculo>());
        }

        [Fact]
        public void Must_Update()
        {
            _mockRepository.Update(Arg.Any<Domain.Models.Veiculo.Veiculo>()).Returns(true);

            var result = _service.Update(GetVeiculo());

            Assert.True(result);

            _mockRepository.Received().Update(Arg.Any<Domain.Models.Veiculo.Veiculo>());
        }

        [Fact]
        public void Must_List()
        {
            var veiculoList = ListVeiculos();
            var veiculo = veiculoList.FirstOrDefault();

            _mockRepository.List(Arg.Any<FiltroVeiculo>()).Returns(veiculoList);

            var result = _service.List(new FiltroVeiculo()).FirstOrDefault();

            Assert.IsType<Domain.Models.Veiculo.Veiculo>(result);
            Assert.Equal(veiculo.Cor, result.Cor);
            Assert.Equal(veiculo.DataCadastro, result.DataCadastro);
            Assert.Equal(veiculo.Id, result.Id);
            Assert.Equal(veiculo.Km, result.Km);
            Assert.Equal(veiculo.ModeloId, result.ModeloId);
            Assert.Equal(veiculo.Placa, result.Placa);
            Assert.Equal(veiculo.TenantId, result.TenantId);

            _mockRepository.Received().List(Arg.Any<FiltroVeiculo>());
        }

        #endregion

        #region Mocks

        private static Domain.Models.Veiculo.Veiculo GetVeiculo() => VeiculoMock.GetVeiculo();

        private static List<Domain.Models.Veiculo.Veiculo> ListVeiculos() => VeiculoMock.ListVeiculos();

        #endregion
    }
}
