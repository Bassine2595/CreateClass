using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
 
namespace DAL
{
    public class QuestionDb : DALBase
    {
        static string allField = @"
            q.Id,
            q.IdTheme,
            q.Libelle";
        static string allFieldSaveWithoutId = @"IdTheme,Libelle";
        static string allFieldSaveWithId = "Id," + allFieldSaveWithoutId;    }
}
