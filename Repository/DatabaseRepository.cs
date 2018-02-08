using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetcore_city_info.Repository
{
    public abstract class DatabaseRepository
    {
        protected string ConnectionString { get; set; }
        public DatabaseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        
        /// <summary>
        /// Takes a value and checks for null,  returning either the value or DBNull.Value if null
        /// </summary>
        /// <param name="value">The value to null check</param>
        /// <returns>value or DBNull.Value</returns>
        protected object AsDbObject(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Executes a DML query and returns the number of affected rows.
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="sqlParameters"></param>
        /// <param name="commandType"></param>
        /// <returns>Number of affected rows</returns>
        protected int Write(string queryString, IEnumerable<SqlParameter> sqlParameters, CommandType commandType)
        {
            return CustomWrite(queryString, sqlParameters, commandType,
                sqlCmd => sqlCmd.ExecuteNonQuery());
        }

        /// <summary>
        /// Executes a DML query and returns a scalar cast to type T (eg. SCOPE_IDENTITY())
        /// </summary>
        /// <typeparam name="T">Native scalar type</typeparam>
        /// <param name="queryString"></param>
        /// <param name="sqlParameters"></param>
        /// <param name="commandType"></param>
        /// <returns>Scalar value cast to type T or null</returns>
        protected T WriteAndReturnScalar<T>(string queryString, IEnumerable<SqlParameter> sqlParameters, CommandType commandType)
        {
            return CustomWrite(queryString, sqlParameters, commandType,
                sqlCmd =>
                {
                    var result = sqlCmd.ExecuteScalar();

                    return (T)result;
                });
        }

        protected T CustomWrite<T>(string queryString, IEnumerable<SqlParameter> sqlParameters, CommandType commandType,
            Func<SqlCommand, T> writeFunc)
        {
            using (var sqlConn = new SqlConnection(ConnectionString))
            {
                sqlConn.Open();

                using (var sqlCmd = new SqlCommand(queryString, sqlConn))
                {
                    sqlCmd.CommandType = commandType;

                    if (sqlParameters != null)
                    {
                        foreach (var sqlParameter in sqlParameters)
                        {
                            sqlCmd.Parameters.Add(sqlParameter);
                        }
                    }

                    var result = writeFunc(sqlCmd);

                    return result;
                }
            }
        }

        protected T Read<T>(string queryString, IEnumerable<SqlParameter> sqlParameters, CommandType commandType, Func<SqlDataReader, T> readAction)
        {
            return CustomRead(queryString, sqlParameters, commandType, sqlCmd =>
            {
                using (var results = sqlCmd.ExecuteReader())
                {
                    return readAction(results);
                }
            });
        }

        protected T ReadScalar<T>(string queryString, IEnumerable<SqlParameter> sqlParameters, CommandType commandType)
        {
            return CustomRead(queryString, sqlParameters, commandType, sqlCmd =>
            {
                var result = sqlCmd.ExecuteScalar();

                if (result == DBNull.Value)
                    return default(T);

                return (T)result;
            });
        }

        protected T CustomRead<T>(string queryString, IEnumerable<SqlParameter> sqlParameters, CommandType commandType,
            Func<SqlCommand, T> readCommand)
        {
            using (var sqlConn = new SqlConnection(ConnectionString))
            {
                sqlConn.Open();

                using (var sqlCmd = new SqlCommand(queryString, sqlConn))
                {
                    sqlCmd.CommandType = commandType;

                    if (sqlParameters != null)
                    {
                        foreach (var sqlParameter in sqlParameters)
                        {
                            sqlCmd.Parameters.Add(sqlParameter);
                        }
                    }

                    return readCommand(sqlCmd);
                }
            }
        }
    }
}
