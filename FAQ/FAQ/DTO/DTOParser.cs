using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DTO
{
    public abstract class DTOParser
    {
        abstract public DTOBase PopulateDTO(SqlDataReader reader);
        abstract public void PopulateOrdinals(SqlDataReader reader);
    }
}
