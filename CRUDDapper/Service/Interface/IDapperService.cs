using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace CRUDDapper.Service.Interface
{
    public interface IDapperService
    {
        DbConnection GetConnection();

        T Buscar<T>(string procedure, DynamicParameters parametros, CommandType tipoComando = CommandType.StoredProcedure);
        List<T> Listar<T>(string procedure, DynamicParameters parametros, CommandType tipoComando = CommandType.StoredProcedure);
        T Inserir<T>(string procedure, DynamicParameters parametros, CommandType tipoComando = CommandType.StoredProcedure);
        T Atualizar<T>(string procedure, DynamicParameters parametros, CommandType tipoComando = CommandType.StoredProcedure);
        int Excluir<T>(string procedure, DynamicParameters parametros, CommandType tipoComando = CommandType.StoredProcedure);
    }
}
