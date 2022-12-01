using Domain.Enums;
using System;

namespace Domain.Models.Veiculo
{
    public class Veiculo : BaseModelo
    {
        public Veiculo()
        {
            DataCadastro = DateTime.Now;
        }

        public Guid TenantId { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string Placa { get; set; }
        public CorEnum Cor { get; set; }
        public int Km { get; set; }
        public int ModeloId { get; set; }
    }
}
