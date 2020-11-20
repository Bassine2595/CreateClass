using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{

    public abstract class DALBase
    {
        protected static ConnectionStringSettings ConnectionString = ConfigurationManager.ConnectionStrings["DefaultTsee"];
        // ConnectionString

        //protected static ConnectionStringSettings ConnectionString;

        protected static string Connection;

        public static void SetConnectionString(string _connectionString)
        {

            if (!string.IsNullOrEmpty(_connectionString))
            {
                SqlConnectionStringBuilder builder =
                    new SqlConnectionStringBuilder(Connection)
                    {
                        InitialCatalog = _connectionString
                    };

                Connection = builder.ConnectionString;
            }
        }

        public static void SetConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentException("Aucune chaine de connexion n'est définit.");

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            Connection = builder.ConnectionString;
        }


        // GetDbSqlCommand
        protected static SqlCommand GetDbSQLCommand(string sqlQuery)
        {

            SqlCommand command = new SqlCommand();
            command.Connection = GetDbConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = sqlQuery;
            return command;


        }
        protected static SqlCommand GetDbSqlProcStoc(string procStockName)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = GetDbConnection();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procStockName;
            return command;
        }

        // GetDbConnection
        public static System.Data.SqlClient.SqlConnection GetDbConnection()
        {
            if (string.IsNullOrEmpty(Connection)) Connection = ConnectionString.ConnectionString;
            return new System.Data.SqlClient.SqlConnection(Connection);
        }

        public static string GetDbConnectionString()
        {
            return Connection;
        }

        // GetDbSprocCommand
        protected static SqlCommand GetDbSprocCommand(string sprocName)
        {
            SqlCommand command = new SqlCommand(sprocName);
            command.Connection = GetDbConnection();
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        // CreateNullParameter
        protected static SqlParameter CreateNullParameter(string name, SqlDbType paramType)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = paramType;
            parameter.ParameterName = name;
            parameter.Value = DBNull.Value;
            parameter.Direction = ParameterDirection.Input;
            return parameter;
        }

        // CreateNullParameter - avec la taille pour nvarchars
        protected static SqlParameter CreateNullParameter(string name, SqlDbType paramType, int size)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = paramType;
            parameter.ParameterName = name;
            parameter.Size = size;
            parameter.Value = null;
            parameter.Direction = ParameterDirection.Input;
            return parameter;
        }

        // CreateOutputParameter
        protected static SqlParameter CreateOutputParameter(string name, SqlDbType paramType)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = paramType;
            parameter.ParameterName = name;
            parameter.Direction = ParameterDirection.Output;
            return parameter;
        }

        // CreateOuputParameter - avec la taille pour nvarchars
        protected static SqlParameter CreateOutputParameter(string name, SqlDbType paramType, int size)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = paramType;
            parameter.Size = size;
            parameter.ParameterName = name;
            parameter.Direction = ParameterDirection.Output;
            return parameter;
        }

        // CreateParameter - uniqueidentifier
        protected static SqlParameter CreateParameter(string name, Guid value)
        {
            if (value.Equals(CommonBase.Guid_NullValue))
            {
                // Si la valeur est null alors crée un paramètre null.
                return CreateNullParameter(name, SqlDbType.UniqueIdentifier);
            }
            else
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.UniqueIdentifier;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }

        // CreateParameter - int
        protected static SqlParameter CreateParameter(string name, int value)
        {
            if (value == CommonBase.Int_NullValue)
            {
                // Si la valeur est null alors crée un paramètre null.
                return CreateNullParameter(name, SqlDbType.Int);
            }
            else
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.Int;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }

        // CreateParameter - int
        protected static SqlParameter CreateParameter(string name, int? value)
        {
            if (value == CommonBase.Int_NullValue)
            {
                // Si la valeur est null alors crée un paramètre null.
                return CreateNullParameter(name, SqlDbType.Int);
            }
            else
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.Int;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }
        // CreateParameter - Bool
        protected static SqlParameter CreateParameter(string name, bool value)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = SqlDbType.Bit;
            parameter.ParameterName = name;
            parameter.Value = value;
            parameter.Direction = ParameterDirection.Input;
            return parameter;
        }



        // CreateParameter - datetime
        protected static SqlParameter CreateParameter(string name, DateTime? value)
        {
            if (value == CommonBase.DateTime_NullValue)
            {
                // Si la valeur est null alors crée un paramètre null.
                return CreateNullParameter(name, SqlDbType.DateTime);
            }
            else
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.DateTime;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }

        // CreateParameter - datetime
        protected static SqlParameter CreateParameter(string name, TimeSpan? value)
        {
            if (value == CommonBase.TimeSpan_NullValue)
            {
                // Si la valeur est null alors crée un paramètre null.
                return CreateNullParameter(name, SqlDbType.Time);
            }
            else
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.Time;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }


        // CreateParameter - datetime
        protected static SqlParameter CreateParameter(string name, DateTime value)
        {
            if (value == CommonBase.DateTime_NullValue)
            {
                // Si la valeur est null alors crée un paramètre null.
                return CreateNullParameter(name, SqlDbType.DateTime);
            }
            else
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.DateTime;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }

        // CreateParameter - decimal
        protected static SqlParameter CreateParameter(string name, Decimal value)
        {
            if (value == CommonBase.Decimal_NullValue)
            {
                // Si la valeur est null alors crée un paramètre null.
                return CreateNullParameter(name, SqlDbType.Decimal);
            }
            else
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.Decimal;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }


        // CreateParameter - nvarchar
        protected static SqlParameter CreateParameter(string name, string value, int size)
        {
            if (value == CommonBase.String_NullValue)
            {
                // Si la valeur est null alors crée un paramètre null.
                return CreateNullParameter(name, SqlDbType.NVarChar);
            }
            else
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Size = size;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }

        // GetSingleDTO
        protected static T GetSingleDTO<T>(ref SqlCommand command) where T : DTOBase
        {
            T dto = null;
            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    DTOParser parser = DTOParserFactory.GetParser(typeof(T));
                    parser.PopulateOrdinals(reader);
                    dto = (T)parser.PopulateDTO(reader);
                    reader.Close();
                }
                else
                {
                    // S'il n'y a pas de données, nous renvoyons null.
                    dto = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error populating data", e);
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
            }
            // Renvoie le DTO, rempli soit avec des données soit avec null.
            return dto;
        }

        // GetDTOList
        protected static List<T> GetDTOList<T>(ref SqlCommand command) where T : DTOBase
        {
            List<T> dtoList = new List<T>();
            try
            {
                command.Connection.Open();
                command.CommandTimeout = 3600;             
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    // Obtenir un analyseur (parser) pour ce type de DTO et remplir les ordinaux.
                    DTOParser parser = DTOParserFactory.GetParser(typeof(T));
                    parser.PopulateOrdinals(reader);
                    // Utilise l'analyseur (parser) pour construire notre liste de DTO.
                    while (reader.Read())
                    {
                        T dto = null;
                        dto = (T)parser.PopulateDTO(reader);
                        dtoList.Add(dto);
                    }
                    reader.Close();
                }
                else
                {
                    // S'il n'y a pas de données, nous renvoyons null.
                    dtoList = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error populating data", e);
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
            }
            return dtoList;
        }

        // ExecuteNoReturn
        protected static void ExecuteNoReturn(ref SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception("Error populating data", e);
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
            }
        }

        protected static int ConvertIntToBool(bool b)
        {
            return (b ? 1 : 0);

        }

        protected static SqlCommand GetDbSprocCommand(string prodName, Dictionary<string, object> inputParams)
        {
            SqlCommand command = GetDbSprocCommand(prodName);

            if (inputParams != null && inputParams.Count > 0)
            {
                AddCommandParam(command, inputParams);
            }

            return command;
        }

        private static void AddCommandParam(SqlCommand command, Dictionary<string, object> inputParams)
        {
            foreach (var item in inputParams)
            {
                command.Parameters.Add(CreateParameter($"@{item.Key}", item.Value));
            }
        }

        private static SqlParameter CreateParameter(string name, object obj)
        {
            System.TypeCode targetType = System.Type.GetTypeCode(obj.GetType());

            switch (targetType)
            {
                case TypeCode.String:
                    string value = (string)obj;
                    return CreateParameter(name, value, value.Length);
                case TypeCode.Int32:
                    return CreateParameter(name, (Int32)obj);
                case TypeCode.DateTime:
                    return CreateParameter(name, (DateTime)obj);
                case TypeCode.Decimal:
                    return CreateParameter(name, (decimal)obj);
                case TypeCode.Boolean:
                    return CreateParameter(name, (bool)obj);
                default:
                    throw new InvalidOperationException("Type inconnnu");
            }
        }

    }
}

