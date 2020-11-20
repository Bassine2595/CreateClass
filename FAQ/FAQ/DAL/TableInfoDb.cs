using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class TableInfoDb : DALBase
    {
        static string allField = @" Name,
                                    Type";

        // GetTableInfoByName
        // 
        public static List<TableInfoDTO> GetTableInfoByName(string name)
        {

            SqlCommand command = GetDbSprocCommand("GetTableInfoByName");
            command.Parameters.Add(CreateParameter("@TableName", name, 250));
            // Exécute la commande.
            return GetDTOList<TableInfoDTO>(ref command);
        }

    }
}

