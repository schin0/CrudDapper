using System;
using System.Collections.Generic;

namespace Tests.Tests.Mocks
{
    public class VeiculoMock
    {
        public static Domain.Models.Veiculo.Veiculo GetVeiculo()
            => new()
            {
                Cor = Domain.Enums.CorEnum.Branco,
                DataCadastro = DateTime.Now,
                Id = 1,
                Km = 1230,
                ModeloId = 1,
                Placa = "ABC1234",
                TenantId = Guid.NewGuid()
            };

        public static List<Domain.Models.Veiculo.Veiculo> ListVeiculos()
            => new()
            {
                GetVeiculo()
            };
    }
}
