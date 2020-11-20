using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
 
namespace DAL
{
    public class ThemeDb : DALBase
    {
        static string allField = @"
            t.Id,
            t.Libelle";
        static string allFieldSaveWithoutId = @"Libelle";
        static string allFieldSaveWithId = "Id," + allFieldSaveWithoutId;
        public static List<ThemeDTO> GetAll()
        {
            String request = $" select {allField} from Theme t";
            SqlCommand command = GetDbSQLCommand(request);
            return GetDTOList<ThemeDTO>(ref command);
        }

    }
}
