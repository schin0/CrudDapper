using CRUDDapper.Data.Model;
using CRUDDapper.Service;
using CRUDDapper.Service.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace CRUDDapper.Repository
{
    public class VeiculoRepository : DapperService, IVeiculoRepository
    {
        private readonly IDapperService _dapperService;

        public VeiculoRepository(IDapperService dapperService, IConfiguration configuracao, string conexao) : base(configuracao, conexao)
        {
            _dapperService = dapperService;
        }

        // TODO: colocar TenantId em todos os métodos e services
        public Veiculo BuscarPorId(int veiculoId)
        {
            var query = "SELECT *" +
                "FROM [Treinamento].[Veiculo] " +
                $"WHERE VeiculoId = {veiculoId}";

            return _dapperService.Buscar<Veiculo>(query, null, tipoComando: CommandType.Text);
        }

        public List<Veiculo> Listar(int veiculoId)
        {
            // TODO: where tenant
            var query = "SELECT * FROM [Treinamento].[Veiculo] ";

            return _dapperService.Listar<Veiculo>(query, null, tipoComando: CommandType.Text);
        }

        public int Inserir(Veiculo veiculo)
        {
            var dbParametros = new DynamicParameters();
            dbParametros.Add("TenantId", veiculo.TenantId, DbType.Guid);
            dbParametros.Add("DataCadastro", veiculo.DataCadastro, DbType.DateTime);
            dbParametros.Add("Placa", veiculo.Placa, DbType.String);
            dbParametros.Add("Cor", veiculo.Cor, DbType.Int32);
            dbParametros.Add("Km", veiculo.Km, DbType.Int32);
            dbParametros.Add("Modelo", veiculo.Modelo);

            return _dapperService.Inserir<int>("proc inserir", dbParametros, tipoComando: CommandType.StoredProcedure);
        }

        public int Atualizar(Veiculo veiculo)
        {
            var dbParametros = new DynamicParameters();
            dbParametros.Add("VeiculoId", veiculo.Id);
            dbParametros.Add("TenantId", veiculo.TenantId, DbType.Guid);
            dbParametros.Add("DataCadastro", veiculo.DataCadastro, DbType.DateTime);
            dbParametros.Add("Placa", veiculo.Placa, DbType.String);
            dbParametros.Add("Cor", veiculo.Cor, DbType.Int32);
            dbParametros.Add("Km", veiculo.Km, DbType.Int32);
            dbParametros.Add("Modelo", veiculo.Modelo);

            return _dapperService.Atualizar<int>("proc atualizar", dbParametros, tipoComando: CommandType.StoredProcedure);
        }

        public int Excluir(int veiculoId)
        {
            var query = "DELETE [Treinamento].[Veiculo]" +
                $"WHERE VeiculoId = {veiculoId}";

            return _dapperService.Excluir<int>(query, null, tipoComando: CommandType.Text);
        }
    }
}
