using SqlKata;

namespace Data.Queries
{
    public class VeiculoQuery
    {
        private const string TABELA = "treinamentoVeiculo.Veiculo";

        public static string GetById()
        {
            var query = new Query(TABELA)
                .Select("Id", "DataCadastro", "Placa", "Cor", "Km", "ModeloId", "TenantId")
                .Where("Id", "@Id")
                .Where("TenantId", "@TenantId");

            return QueryBuilder.QueryBuilder.Get(query);
        }

        public static string Insert()
        {
            var query = new Query(TABELA)
                .AsInsert(new
                {
                    TenantId = "@TenantId",
                    DataCadastro = "@DataCadastro",
                    Placa = "@Placa",
                    Cor = "@Cor",
                    Km = "@Km",
                    ModeloId = "@ModeloId"
                });

            return QueryBuilder.QueryBuilder.Get(query) + "SELECT CAST(SCOPE_IDENTITY() AS INT)";
        }

        public static string Update()
        {
            var query = new Query(TABELA)
                .AsUpdate(new
                {
                    TenantId = "@TenantId",
                    DataCadastro = "@DataCadastro",
                    Placa = "@Placa",
                    Cor = "@Cor",
                    Km = "@Km",
                    ModeloId = "@ModeloId"
                })
                .Where("Id", "@Id")
                .Where("TenantId", "@TenantId");

            return QueryBuilder.QueryBuilder.Get(query);
        }

        public static string Delete()
        {
            var query = new Query(TABELA)
                .Where("Id", "@Id")
                .Where("TenantId", "@TenantId")
                .AsDelete();

            return QueryBuilder.QueryBuilder.Get(query);
        }

        public static string List()
        {
            var query = new Query(TABELA)
                   .Select("Id", "DataCadastro", "Placa", "Cor", "Km", "ModeloId", "TenantId")
                   .Where("TenantId", "@TenantId")
                   .OrderBy("DataCadastro");

            return QueryBuilder.QueryBuilder.Get(query);
        }

    }
}
