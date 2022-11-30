using Domain.Common.Interfaces;
using Domain.Enums;
using Domain.Models.Veiculo;
using System;

namespace Domain.Arguments
{
    public class VeiculoRequest : IRequest<Veiculo>
    {
        public Guid TenantId { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string Placa { get; set; }
        public CorEnum Cor { get; set; }
        public int Km { get; set; }
        public int ModeloId { get; set; }
        public int? Id { get; set; }

        public Veiculo ToDomain()
            => new()
            {
                Cor = Cor,
                DataCadastro = DataCadastro ?? DateTime.Now,
                Id = Id.GetValueOrDefault(),
                Km = Km,
                ModeloId = ModeloId,
                Placa = Placa,
                TenantId = TenantId
            };
    }
}
