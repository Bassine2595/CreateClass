using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
 
namespace DAL
{
    public class AnswerDb : DALBase
    {
        static string allField = @"
            a.Id,
            a.IdQuestion,
            a.Libelle";
        static string allFieldSaveWithoutId = @"IdQuestion,Libelle";
        static string allFieldSaveWithId = "Id," + allFieldSaveWithoutId;    }
}
