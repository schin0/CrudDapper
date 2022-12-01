using SqlKata;
using SqlKata.Compilers;
using System.Collections.Generic;
using System.Text;

namespace Data.QueryBuilder
{
    public static class QueryBuilder
    {
        private static readonly SqlServerCompiler compiler = new SqlServerCompiler();

        public static string Get(Query query)
        {
            SqlResult result = compiler.Compile(query);
            return RenameParameters(result.Sql, result.Bindings);
        }

        private static string RenameParameters(string sqlKata, List<object> bindings)
        {
            StringBuilder builder = new StringBuilder(sqlKata);

            for (int i = bindings.Count - 1; i >= 0; i--)
                builder.Replace("@p" + i.ToString(), bindings[i].ToString());

            return builder.ToString().Replace("\n", string.Empty);
        }
    }
}
