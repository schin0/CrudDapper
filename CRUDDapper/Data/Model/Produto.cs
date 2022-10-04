using CRUDDapper.Data.Enum;
using System;

namespace CRUDDapper.Data.Model
{
    public class Veiculo
    {
        public int Id { get; set; }
        public Guid TenantId { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Placa { get; set; }
        public CorEnum Cor { get; set; }
        public int Km { get; set; }
        public Modelo Modelo { get; set; }
    }
}
