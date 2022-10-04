using CRUDDapper.Service.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace CRUDDapper.Service
{
    public class DapperService : IDapperService
    {
        private readonly IConfiguration _configuracao;
        private readonly string _conexao;

        public DapperService(IConfiguration configuracao, string conexao)
        {
            _configuracao = configuracao;
            _conexao = conexao;
        }

        public DbConnection GetConnection()
            => new SqlConnection(_conexao);

        public T Buscar<T>(string procedure, DynamicParameters parametros, CommandType tipoComando = CommandType.StoredProcedure)
        {
            using IDbConnection banco = new SqlConnection(_conexao);

            return banco.Query<T>(procedure, parametros, commandType: tipoComando).FirstOrDefault();
        }

        public List<T> Listar<T>(string procedure, DynamicParameters parametros, CommandType tipoComando = CommandType.StoredProcedure)
        {
            using IDbConnection banco = new SqlConnection(_conexao);

            return banco.Query<T>(procedure, parametros, commandType: tipoComando).ToList();
        }

        public T Inserir<T>(string procedure, DynamicParameters parametros, CommandType tipoComando = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection banco = new SqlConnection(_conexao);

            try
            {
                if (banco.State == ConnectionState.Closed)
                    banco.Open();

                using var transacao = banco.BeginTransaction();
                try
                {
                    result = banco.Query<T>(procedure, parametros,
                        commandType: tipoComando, transaction: transacao).FirstOrDefault();

                    transacao.Commit();
                }
                catch (Exception)
                {
                    transacao.Rollback();
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (banco.State == ConnectionState.Open) banco.Close();
            }

            return result;
        }

        public T Atualizar<T>(string procedure, DynamicParameters parametros, CommandType tipoComando = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection banco = new SqlConnection(_conexao);

            try
            {
                if (banco.State == ConnectionState.Closed)
                    banco.Open();

                using var transacao = banco.BeginTransaction();
                try
                {
                    result = banco.Query<T>(procedure, parametros,
                        commandType: tipoComando, transaction: transacao).FirstOrDefault();

                    transacao.Commit();
                }
                catch (Exception)
                {
                    transacao.Rollback();
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (banco.State == ConnectionState.Open) banco.Close();
            }

            return result;
        }

        public int Excluir<T>(string procedure, DynamicParameters parametros, CommandType tipoComando = CommandType.StoredProcedure)
        {
            using IDbConnection banco = new SqlConnection(_conexao);

            return banco.Execute(procedure, parametros, commandType: tipoComando);
        }

    }
}
