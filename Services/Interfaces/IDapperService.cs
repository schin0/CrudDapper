using Dapper;
using System.Data;
using System.Data.Common;

namespace Services.Interfaces
{
    public interface IDapperService
    {
        DbConnection GetConnection();
        T GetById<T>(string procedure, DynamicParameters parametros, CommandType tipoComando = CommandType.StoredProcedure);
        T Insert<T>(string procedure, DynamicParameters parametros, CommandType tipoComando = CommandType.StoredProcedure);
        int Update<T>(string procedure, DynamicParameters parametros, CommandType tipoComando = CommandType.StoredProcedure);
        bool Delete<T>(string procedure, DynamicParameters parametros, CommandType tipoComando = CommandType.StoredProcedure);
        // TODO: Inserir Listar
        //List<T> Listar<T>(string procedure, DynamicParameters parametros, CommandType tipoComando = CommandType.StoredProcedure);
    }
}
