using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
 
namespace DTO
    {
        public class DTOParser_Question : DTOParser
        {
            public int ord_Id  {get; set;} 
            public int ord_IdTheme  {get; set;} 
            public int ord_Libelle  {get; set;} 
        public override void PopulateOrdinals(SqlDataReader reader)
            {
                ord_Id = reader.GetOrdinal("Id");
                ord_IdTheme = reader.GetOrdinal("IdTheme");
                ord_Libelle = reader.GetOrdinal("Libelle");
            }
        public override DTOBase PopulateDTO(SqlDataReader reader)
        {
            QuestionDTO theTDO = new QuestionDTO();
            // Id
            if (!reader.IsDBNull(ord_Id)) { theTDO.Id = reader.GetInt32(ord_Id); }
            // IdTheme
            if (!reader.IsDBNull(ord_IdTheme)) { theTDO.IdTheme = reader.GetString(ord_IdTheme); }
            // Libelle
            if (!reader.IsDBNull(ord_Libelle)) { theTDO.Libelle = reader.GetString(ord_Libelle); }
            // IsNew
            theTDO.IsNew = false;
            return theTDO;
        }
    }
}
