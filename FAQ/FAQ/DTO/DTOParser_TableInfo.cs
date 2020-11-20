using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTOParser_TableInfo : DTOParser
    {
        public int ord_Name { get; set; }
        public int ord_Type { get; set; }

        public override void PopulateOrdinals(SqlDataReader reader)
        {
            ord_Name = reader.GetOrdinal("Name");
            ord_Type = reader.GetOrdinal("Type");
        }

        public override DTOBase PopulateDTO(SqlDataReader reader)
        {// On suppose que le reader possède des données et est déjà sur la ligne qui contient les données dont nous avons besoin.
         // Nous n'avons pas besoin d'appeler read.
         // En règle générale, on suppose que chaque champ doit être vérifié null.
         // Si un champ est null alors la valeur Nullvalue pour ce champ a déjà été fixée par le constructeur DTO, nous n'avons pas besoin de la changer.
            TableInfoDTO TableInfo = new TableInfoDTO();
            // Libelle
            if (!reader.IsDBNull(ord_Name)) { TableInfo.Name = reader.GetString(ord_Name); }
            // Id
            if (!reader.IsDBNull(ord_Type)) { TableInfo.Type = reader.GetString(ord_Type); }
            // IsNew
            TableInfo.IsNew = false;
            return TableInfo;
        }

    }
}
